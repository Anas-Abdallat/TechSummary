using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TechSummary.Models;

public partial class TechSummaryContext : DbContext
{
    public TechSummaryContext()
    {
    }

    public TechSummaryContext(DbContextOptions<TechSummaryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Content> Contents { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LookupItem> LookupItems { get; set; }

    public virtual DbSet<LookupType> LookupTypes { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-E8UDJO1;Database=TechSummary;Trusted_Connection=True;TrustServerCertificate=True;User Id=sa;Password=NoworNever97@@;Integrated Security=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07CE52F71A");

            entity.ToTable("Category");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Categories)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Category__Create__440B1D61");
        });

        modelBuilder.Entity<Content>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Content__3214EC0788F513BC");

            entity.ToTable("Content");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Views).HasDefaultValue(0);

            entity.HasOne(d => d.ContentType).WithMany(p => p.Contents)
                .HasForeignKey(d => d.ContentTypeId)
                .HasConstraintName("FK__Content__Content__5441852A");

            entity.HasOne(d => d.Topic).WithMany(p => p.Contents)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__Content__TopicId__5535A963");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.Contents)
                .HasForeignKey(d => d.UploadedBy)
                .HasConstraintName("FK__Content__Uploade__5629CD9C");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Language__3214EC07261BC657");

            entity.ToTable("Language");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Languages)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Language__Catego__48CFD27E");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Languages)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Language__Create__49C3F6B7");
        });

        modelBuilder.Entity<LookupItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LookupIt__3214EC079D2F3E6D");

            entity.ToTable("LookupItem");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.LookupType).WithMany(p => p.LookupItems)
                .HasForeignKey(d => d.LookupTypeId)
                .HasConstraintName("FK__LookupIte__Looku__3A81B327");
        });

        modelBuilder.Entity<LookupType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LookupTy__3214EC072C70C8D9");

            entity.ToTable("LookupType");

            entity.HasIndex(e => e.Name, "UQ__LookupTy__737584F6F22B8C78").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rating__3214EC07AAD91529");

            entity.ToTable("Rating");

            entity.HasIndex(e => new { e.ContentId, e.UserId }, "UQ_Rating").IsUnique();

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Content).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.ContentId)
                .HasConstraintName("FK__Rating__ContentI__5CD6CB2B");

            entity.HasOne(d => d.User).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Rating__UserId__5DCAEF64");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Topic__3214EC079B4CFD23");

            entity.ToTable("Topic");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Topics)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Topic__CreatedBy__4F7CD00D");

            entity.HasOne(d => d.Language).WithMany(p => p.Topics)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK__Topic__LanguageI__4E88ABD4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07E51AAD46");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534BC8D4648").IsUnique();

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Gender).WithMany(p => p.UserGenders)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__User__GenderId__3E52440B");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleId__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
