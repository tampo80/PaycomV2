using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCom.WebApi.Migrations.PostgreSQL.Taxe
{
    /// <inheritdoc />
    public partial class AddnewSchema212 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AgentFiscalId",
                schema: "taxe",
                table: "Contribuables",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contribuables_AgentFiscalId",
                schema: "taxe",
                table: "Contribuables",
                column: "AgentFiscalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contribuables_AgentsFiscaux_AgentFiscalId",
                schema: "taxe",
                table: "Contribuables",
                column: "AgentFiscalId",
                principalSchema: "taxe",
                principalTable: "AgentsFiscaux",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contribuables_AgentsFiscaux_AgentFiscalId",
                schema: "taxe",
                table: "Contribuables");

            migrationBuilder.DropIndex(
                name: "IX_Contribuables_AgentFiscalId",
                schema: "taxe",
                table: "Contribuables");

            migrationBuilder.DropColumn(
                name: "AgentFiscalId",
                schema: "taxe",
                table: "Contribuables");
        }
    }
}
