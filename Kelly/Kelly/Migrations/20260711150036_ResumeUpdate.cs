using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kelly.Migrations
{
    /// <inheritdoc />
    public partial class ResumeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Category",
                table: "PortfolioPages");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "PortfolioPages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "PortfolioPages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "PortfolioPages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
