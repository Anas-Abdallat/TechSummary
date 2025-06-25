using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSummary.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionAndImageToLanguage_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookupType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LookupTy__3214EC072C70C8D9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LookupIt__3214EC079D2F3E6D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__LookupIte__Looku__3A81B327",
                        column: x => x.LookupTypeId,
                        principalTable: "LookupType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__3214EC07E51AAD46", x => x.Id);
                    table.ForeignKey(
                        name: "FK__User__GenderId__3E52440B",
                        column: x => x.GenderId,
                        principalTable: "LookupItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__User__RoleId__3F466844",
                        column: x => x.RoleId,
                        principalTable: "LookupItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3214EC07CE52F71A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Category__Create__440B1D61",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Language__3214EC07261BC657", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Language__Catego__48CFD27E",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Language__Create__49C3F6B7",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Topic__3214EC079B4CFD23", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Topic__CreatedBy__4F7CD00D",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Topic__LanguageI__4E88ABD4",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContentTypeId = table.Column<int>(type: "int", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: true),
                    UploadedBy = table.Column<int>(type: "int", nullable: true),
                    Views = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Content__3214EC0788F513BC", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Content__Content__5441852A",
                        column: x => x.ContentTypeId,
                        principalTable: "LookupItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Content__TopicId__5535A963",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Content__Uploade__5629CD9C",
                        column: x => x.UploadedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RateAmount = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rating__3214EC07AAD91529", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Rating__ContentI__5CD6CB2B",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Rating__UserId__5DCAEF64",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_CreatedBy",
                table: "Category",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Content_ContentTypeId",
                table: "Content",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_TopicId",
                table: "Content",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_UploadedBy",
                table: "Content",
                column: "UploadedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Language_CategoryId",
                table: "Language",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Language_CreatedBy",
                table: "Language",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LookupItem_LookupTypeId",
                table: "LookupItem",
                column: "LookupTypeId");

            migrationBuilder.CreateIndex(
                name: "UQ__LookupTy__737584F6F22B8C78",
                table: "LookupType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ_Rating",
                table: "Rating",
                columns: new[] { "ContentId", "UserId" },
                unique: true,
                filter: "[ContentId] IS NOT NULL AND [UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_CreatedBy",
                table: "Topic",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_LanguageId",
                table: "Topic",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GenderId",
                table: "User",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UQ__User__A9D10534BC8D4648",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "LookupItem");

            migrationBuilder.DropTable(
                name: "LookupType");
        }
    }
}
