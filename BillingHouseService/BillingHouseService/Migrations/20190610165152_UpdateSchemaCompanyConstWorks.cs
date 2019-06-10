using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BH.WebApi.Migrations
{
    public partial class UpdateSchemaCompanyConstWorks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SchemeConstructionWorks",
                table: "SchemeConstructionWorks");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SchemeConstructionWorks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchemeConstructionWorks",
                table: "SchemeConstructionWorks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SchemeConstructionWorks_CompanyConstructionWorksId",
                table: "SchemeConstructionWorks",
                column: "CompanyConstructionWorksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SchemeConstructionWorks",
                table: "SchemeConstructionWorks");

            migrationBuilder.DropIndex(
                name: "IX_SchemeConstructionWorks_CompanyConstructionWorksId",
                table: "SchemeConstructionWorks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SchemeConstructionWorks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchemeConstructionWorks",
                table: "SchemeConstructionWorks",
                columns: new[] { "CompanyConstructionWorksId", "SchemeId" });
        }
    }
}
