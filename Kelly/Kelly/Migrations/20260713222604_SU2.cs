using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kelly.Migrations
{
    /// <inheritdoc />
    public partial class SU2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResumeEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartYear = table.Column<DateOnly>(type: "date", nullable: false),
                    EndYear = table.Column<DateOnly>(type: "date", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumePageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeEducations_ResumePages_ResumePageId",
                        column: x => x.ResumePageId,
                        principalTable: "ResumePages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResumeExperiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartYear = table.Column<DateOnly>(type: "date", nullable: false),
                    EndYear = table.Column<DateOnly>(type: "date", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumePageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeExperiences_ResumePages_ResumePageId",
                        column: x => x.ResumePageId,
                        principalTable: "ResumePages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResumeSumaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumePageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSumaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeSumaries_ResumePages_ResumePageId",
                        column: x => x.ResumePageId,
                        principalTable: "ResumePages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEducations_ResumePageId",
                table: "ResumeEducations",
                column: "ResumePageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeExperiences_ResumePageId",
                table: "ResumeExperiences",
                column: "ResumePageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSumaries_ResumePageId",
                table: "ResumeSumaries",
                column: "ResumePageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumeEducations");

            migrationBuilder.DropTable(
                name: "ResumeExperiences");

            migrationBuilder.DropTable(
                name: "ResumeSumaries");
        }
    }
}
