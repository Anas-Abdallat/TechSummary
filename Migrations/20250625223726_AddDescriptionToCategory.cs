using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSummary.Migrations
{
    public partial class AddDescriptionToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Category");
        }
    }
}
