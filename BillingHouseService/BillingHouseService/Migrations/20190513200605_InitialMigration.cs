using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BH.WebApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HomePageLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TypeOfMaterial = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionWorks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TypeOfWorks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyContactPhones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContactPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyContactPhones_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyConstructionMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    ConstructionMaterialId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyConstructionMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyConstructionMaterial_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyConstructionMaterial_ConstructionMaterial_ConstructionMaterialId",
                        column: x => x.ConstructionMaterialId,
                        principalTable: "ConstructionMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyConstructionWorks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PricePerSquareMeter = table.Column<decimal>(type: "decimal", nullable: false),
                    ConstructionWorksId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyConstructionWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyConstructionWorks_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyConstructionWorks_ConstructionWorks_ConstructionWorksId",
                        column: x => x.ConstructionWorksId,
                        principalTable: "ConstructionWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFeedbackAboutCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeedbackAboutCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFeedbackAboutCompany_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFeedbackAboutCompany_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProject_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyConstructionWorksConstructionMaterial",
                columns: table => new
                {
                    CompanyConstructionWorksId = table.Column<Guid>(nullable: false),
                    ConstructionMaterialId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyConstructionWorksConstructionMaterial", x => new { x.ConstructionMaterialId, x.CompanyConstructionWorksId });
                    table.ForeignKey(
                        name: "FK_CompanyConstructionWorksConstructionMaterial_CompanyConstructionWorks_CompanyConstructionWorksId",
                        column: x => x.CompanyConstructionWorksId,
                        principalTable: "CompanyConstructionWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyConstructionWorksConstructionMaterial_ConstructionMaterial_ConstructionMaterialId",
                        column: x => x.ConstructionMaterialId,
                        principalTable: "ConstructionMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectScheme",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    WallsArea = table.Column<decimal>(type: "decimal", nullable: true),
                    FloorArea = table.Column<decimal>(type: "decimal", nullable: true),
                    CeilingArea = table.Column<decimal>(type: "decimal", nullable: true),
                    CeilingPerimeter = table.Column<decimal>(type: "decimal", nullable: true),
                    FloorPerimeter = table.Column<decimal>(type: "decimal", nullable: true),
                    UserProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectScheme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectScheme_UserProject_UserProjectId",
                        column: x => x.UserProjectId,
                        principalTable: "UserProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchemeConstructionWorks",
                columns: table => new
                {
                    SchemeId = table.Column<Guid>(nullable: false),
                    ConstructionWorksId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeConstructionWorks", x => new { x.ConstructionWorksId, x.SchemeId });
                    table.ForeignKey(
                        name: "FK_SchemeConstructionWorks_ConstructionWorks_ConstructionWorksId",
                        column: x => x.ConstructionWorksId,
                        principalTable: "ConstructionWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchemeConstructionWorks_ProjectScheme_SchemeId",
                        column: x => x.SchemeId,
                        principalTable: "ProjectScheme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchemeWall",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Area = table.Column<decimal>(type: "decimal", nullable: false),
                    ProjectSchemeId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeWall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchemeWall_ProjectScheme_ProjectSchemeId",
                        column: x => x.ProjectSchemeId,
                        principalTable: "ProjectScheme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyConstructionMaterial_CompanyId",
                table: "CompanyConstructionMaterial",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyConstructionMaterial_ConstructionMaterialId",
                table: "CompanyConstructionMaterial",
                column: "ConstructionMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyConstructionWorks_CompanyId",
                table: "CompanyConstructionWorks",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyConstructionWorks_ConstructionWorksId",
                table: "CompanyConstructionWorks",
                column: "ConstructionWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyConstructionWorksConstructionMaterial_CompanyConstructionWorksId",
                table: "CompanyConstructionWorksConstructionMaterial",
                column: "CompanyConstructionWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContactPhones_CompanyId",
                table: "CompanyContactPhones",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectScheme_UserProjectId",
                table: "ProjectScheme",
                column: "UserProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemeConstructionWorks_SchemeId",
                table: "SchemeConstructionWorks",
                column: "SchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemeWall_ProjectSchemeId",
                table: "SchemeWall",
                column: "ProjectSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeedbackAboutCompany_CompanyId",
                table: "UserFeedbackAboutCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeedbackAboutCompany_UserId",
                table: "UserFeedbackAboutCompany",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_UserId",
                table: "UserProject",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyConstructionMaterial");

            migrationBuilder.DropTable(
                name: "CompanyConstructionWorksConstructionMaterial");

            migrationBuilder.DropTable(
                name: "CompanyContactPhones");

            migrationBuilder.DropTable(
                name: "SchemeConstructionWorks");

            migrationBuilder.DropTable(
                name: "SchemeWall");

            migrationBuilder.DropTable(
                name: "UserFeedbackAboutCompany");

            migrationBuilder.DropTable(
                name: "CompanyConstructionWorks");

            migrationBuilder.DropTable(
                name: "ConstructionMaterial");

            migrationBuilder.DropTable(
                name: "ProjectScheme");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "ConstructionWorks");

            migrationBuilder.DropTable(
                name: "UserProject");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
