using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSummary.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionAndImageToLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

           
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Language");
        }

    }
}
