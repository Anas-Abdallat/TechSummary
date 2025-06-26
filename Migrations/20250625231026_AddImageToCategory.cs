using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSummary.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                           name: "Image",
                           table: "Category",
                           type: "nvarchar(max)",
                           nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                           name: "Image",
                           table: "Category");
        }
    }
}
