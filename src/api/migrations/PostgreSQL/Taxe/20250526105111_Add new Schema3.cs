using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCom.WebApi.Migrations.PostgreSQL.Taxe
{
    /// <inheritdoc />
    public partial class AddnewSchema3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communes_Regions_RegionId1",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropForeignKey(
                name: "FK_Communes_Regions_RegionId2",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropForeignKey(
                name: "FK_Communes_Regions_RegionId3",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropForeignKey(
                name: "FK_Communes_Regions_RegionId4",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropForeignKey(
                name: "FK_Communes_Regions_RegionId5",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropForeignKey(
                name: "FK_Communes_Regions_RegionId6",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropIndex(
                name: "IX_Communes_RegionId1",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropIndex(
                name: "IX_Communes_RegionId2",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropIndex(
                name: "IX_Communes_RegionId3",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropIndex(
                name: "IX_Communes_RegionId4",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropIndex(
                name: "IX_Communes_RegionId5",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropIndex(
                name: "IX_Communes_RegionId6",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "RegionId1",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "RegionId2",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "RegionId3",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "RegionId4",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "RegionId5",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "RegionId6",
                schema: "taxe",
                table: "Communes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RegionId1",
                schema: "taxe",
                table: "Communes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RegionId2",
                schema: "taxe",
                table: "Communes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RegionId3",
                schema: "taxe",
                table: "Communes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RegionId4",
                schema: "taxe",
                table: "Communes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RegionId5",
                schema: "taxe",
                table: "Communes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RegionId6",
                schema: "taxe",
                table: "Communes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Communes_RegionId1",
                schema: "taxe",
                table: "Communes",
                column: "RegionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_RegionId2",
                schema: "taxe",
                table: "Communes",
                column: "RegionId2");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_RegionId3",
                schema: "taxe",
                table: "Communes",
                column: "RegionId3");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_RegionId4",
                schema: "taxe",
                table: "Communes",
                column: "RegionId4");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_RegionId5",
                schema: "taxe",
                table: "Communes",
                column: "RegionId5");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_RegionId6",
                schema: "taxe",
                table: "Communes",
                column: "RegionId6");

            migrationBuilder.AddForeignKey(
                name: "FK_Communes_Regions_RegionId1",
                schema: "taxe",
                table: "Communes",
                column: "RegionId1",
                principalSchema: "taxe",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communes_Regions_RegionId2",
                schema: "taxe",
                table: "Communes",
                column: "RegionId2",
                principalSchema: "taxe",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communes_Regions_RegionId3",
                schema: "taxe",
                table: "Communes",
                column: "RegionId3",
                principalSchema: "taxe",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communes_Regions_RegionId4",
                schema: "taxe",
                table: "Communes",
                column: "RegionId4",
                principalSchema: "taxe",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communes_Regions_RegionId5",
                schema: "taxe",
                table: "Communes",
                column: "RegionId5",
                principalSchema: "taxe",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communes_Regions_RegionId6",
                schema: "taxe",
                table: "Communes",
                column: "RegionId6",
                principalSchema: "taxe",
                principalTable: "Regions",
                principalColumn: "Id");
        }
    }
}
