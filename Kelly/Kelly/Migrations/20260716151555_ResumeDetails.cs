using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kelly.Migrations
{
    /// <inheritdoc />
    public partial class ResumeDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResumeSumaries_ResumePageId",
                table: "ResumeSumaries");

            migrationBuilder.CreateTable(
                name: "ResumeExperienceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Responsibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResumePageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeExperienceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeExperienceItems_ResumeExperiences_ResumeExperienceId",
                        column: x => x.ResumeExperienceId,
                        principalTable: "ResumeExperiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResumeExperienceItems_ResumePages_ResumePageId",
                        column: x => x.ResumePageId,
                        principalTable: "ResumePages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSumaries_ResumePageId",
                table: "ResumeSumaries",
                column: "ResumePageId",
                unique: true,
                filter: "[ResumePageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeExperienceItems_ResumeExperienceId",
                table: "ResumeExperienceItems",
                column: "ResumeExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeExperienceItems_ResumePageId",
                table: "ResumeExperienceItems",
                column: "ResumePageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumeExperienceItems");

            migrationBuilder.DropIndex(
                name: "IX_ResumeSumaries_ResumePageId",
                table: "ResumeSumaries");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSumaries_ResumePageId",
                table: "ResumeSumaries",
                column: "ResumePageId");
        }
    }
}
