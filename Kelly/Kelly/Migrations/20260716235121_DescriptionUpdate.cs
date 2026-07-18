using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kelly.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Responsibility",
                table: "ResumeExperiences");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PortfolioItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PortfolioItems");

            migrationBuilder.AddColumn<string>(
                name: "Responsibility",
                table: "ResumeExperiences",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
