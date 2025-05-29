using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCom.WebApi.Migrations.PostgreSQL.Taxe
{
    /// <inheritdoc />
    public partial class AddnewSchema2121 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CapitalSocial",
                schema: "taxe",
                table: "Contribuables",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreationEntreprise",
                schema: "taxe",
                table: "Contribuables",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormeJuridique",
                schema: "taxe",
                table: "Contribuables",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NIF",
                schema: "taxe",
                table: "Contribuables",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RepresentantLegal",
                schema: "taxe",
                table: "Contribuables",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecteurActivite",
                schema: "taxe",
                table: "Contribuables",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapitalSocial",
                schema: "taxe",
                table: "Contribuables");

            migrationBuilder.DropColumn(
                name: "DateCreationEntreprise",
                schema: "taxe",
                table: "Contribuables");

            migrationBuilder.DropColumn(
                name: "FormeJuridique",
                schema: "taxe",
                table: "Contribuables");

            migrationBuilder.DropColumn(
                name: "NIF",
                schema: "taxe",
                table: "Contribuables");

            migrationBuilder.DropColumn(
                name: "RepresentantLegal",
                schema: "taxe",
                table: "Contribuables");

            migrationBuilder.DropColumn(
                name: "SecteurActivite",
                schema: "taxe",
                table: "Contribuables");
        }
    }
}
