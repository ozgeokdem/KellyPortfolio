using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kelly.Migrations
{
    /// <inheritdoc />
    public partial class PortfolioColums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageDescription",
                table: "PortfolioItems");

            migrationBuilder.DropColumn(
                name: "PageTitle",
                table: "PortfolioItems");

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

            migrationBuilder.AlterColumn<bool>(
                name: "AboutFreelance",
                table: "AboutPages",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "PortfolioPages");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "PortfolioPages");

            migrationBuilder.AddColumn<string>(
                name: "PageDescription",
                table: "PortfolioItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageTitle",
                table: "PortfolioItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AboutFreelance",
                table: "AboutPages",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
