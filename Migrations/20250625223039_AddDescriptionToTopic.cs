using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSummary.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToTopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
        name: "Description",
        table: "Topic",
        type: "nvarchar(200)",
        nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
