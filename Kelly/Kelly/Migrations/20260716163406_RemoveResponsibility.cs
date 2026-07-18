using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kelly.Migrations
{
    /// <inheritdoc />
    public partial class RemoveResponsibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResumeExperienceItems_ResumePages_ResumePageId",
                table: "ResumeExperienceItems");

            migrationBuilder.DropIndex(
                name: "IX_ResumeExperienceItems_ResumePageId",
                table: "ResumeExperienceItems");

            migrationBuilder.DropColumn(
                name: "ResumePageId",
                table: "ResumeExperienceItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ResumePageId",
                table: "ResumeExperienceItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResumeExperienceItems_ResumePageId",
                table: "ResumeExperienceItems",
                column: "ResumePageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeExperienceItems_ResumePages_ResumePageId",
                table: "ResumeExperienceItems",
                column: "ResumePageId",
                principalTable: "ResumePages",
                principalColumn: "Id");
        }
    }
}
