using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BH.WebApi.Migrations
{
    public partial class AddSchemaCompanyConstWorks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchemeConstructionWorks_ConstructionWorks_ConstructionWorksId",
                table: "SchemeConstructionWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchemeConstructionWorks",
                table: "SchemeConstructionWorks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConstructionWorksId",
                table: "SchemeConstructionWorks",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyConstructionWorksId",
                table: "SchemeConstructionWorks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchemeConstructionWorks",
                table: "SchemeConstructionWorks",
                columns: new[] { "CompanyConstructionWorksId", "SchemeId" });

            migrationBuilder.CreateIndex(
                name: "IX_SchemeConstructionWorks_ConstructionWorksId",
                table: "SchemeConstructionWorks",
                column: "ConstructionWorksId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchemeConstructionWorks_CompanyConstructionWorks_CompanyConstructionWorksId",
                table: "SchemeConstructionWorks",
                column: "CompanyConstructionWorksId",
                principalTable: "CompanyConstructionWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchemeConstructionWorks_ConstructionWorks_ConstructionWorksId",
                table: "SchemeConstructionWorks",
                column: "ConstructionWorksId",
                principalTable: "ConstructionWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchemeConstructionWorks_CompanyConstructionWorks_CompanyConstructionWorksId",
                table: "SchemeConstructionWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_SchemeConstructionWorks_ConstructionWorks_ConstructionWorksId",
                table: "SchemeConstructionWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchemeConstructionWorks",
                table: "SchemeConstructionWorks");

            migrationBuilder.DropIndex(
                name: "IX_SchemeConstructionWorks_ConstructionWorksId",
                table: "SchemeConstructionWorks");

            migrationBuilder.DropColumn(
                name: "CompanyConstructionWorksId",
                table: "SchemeConstructionWorks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConstructionWorksId",
                table: "SchemeConstructionWorks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchemeConstructionWorks",
                table: "SchemeConstructionWorks",
                columns: new[] { "ConstructionWorksId", "SchemeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SchemeConstructionWorks_ConstructionWorks_ConstructionWorksId",
                table: "SchemeConstructionWorks",
                column: "ConstructionWorksId",
                principalTable: "ConstructionWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
