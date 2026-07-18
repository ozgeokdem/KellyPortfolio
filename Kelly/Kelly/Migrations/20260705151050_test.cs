using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kelly.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutFacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutFacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutBirthday = table.Column<DateOnly>(type: "date", nullable: true),
                    AboutWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutAge = table.Column<byte>(type: "tinyint", nullable: true),
                    AboutDegree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutFreelance = table.Column<bool>(type: "bit", nullable: false),
                    SkillsUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillsTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactsUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactsTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestimonialsUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestimonialsTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YourName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card1IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card1Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card2IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card2Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card3IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card3Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumePages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumeSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicePages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ProjectUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditorContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioItems_PortfolioPages_PortfolioPageId",
                        column: x => x.PortfolioPageId,
                        principalTable: "PortfolioPages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResumeItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ResumeSectionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeItems_ResumeSections_ResumeSectionsId",
                        column: x => x.ResumeSectionsId,
                        principalTable: "ResumeSections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicePageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCards_ServicePages_ServicePageId",
                        column: x => x.ServicePageId,
                        principalTable: "ServicePages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PortfolioItemImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageAlt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioItemImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioItemImages_PortfolioItems_PortfolioItemId",
                        column: x => x.PortfolioItemId,
                        principalTable: "PortfolioItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResumeSubItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSubItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeSubItems_ResumeItems_ResumeItemsId",
                        column: x => x.ResumeItemsId,
                        principalTable: "ResumeItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItemImages_PortfolioItemId",
                table: "PortfolioItemImages",
                column: "PortfolioItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItems_PortfolioPageId",
                table: "PortfolioItems",
                column: "PortfolioPageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeItems_ResumeSectionsId",
                table: "ResumeItems",
                column: "ResumeSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSubItems_ResumeItemsId",
                table: "ResumeSubItems",
                column: "ResumeItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCards_ServicePageId",
                table: "ServiceCards",
                column: "ServicePageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutFacts");

            migrationBuilder.DropTable(
                name: "AboutPages");

            migrationBuilder.DropTable(
                name: "AboutSkills");

            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.DropTable(
                name: "ContactPages");

            migrationBuilder.DropTable(
                name: "HomePages");

            migrationBuilder.DropTable(
                name: "PortfolioItemImages");

            migrationBuilder.DropTable(
                name: "ResumePages");

            migrationBuilder.DropTable(
                name: "ResumeSubItems");

            migrationBuilder.DropTable(
                name: "ServiceCards");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "PortfolioItems");

            migrationBuilder.DropTable(
                name: "ResumeItems");

            migrationBuilder.DropTable(
                name: "ServicePages");

            migrationBuilder.DropTable(
                name: "PortfolioPages");

            migrationBuilder.DropTable(
                name: "ResumeSections");
        }
    }
}
