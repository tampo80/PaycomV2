using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCom.WebApi.Migrations.PostgreSQL.Taxe
{
    /// <inheritdoc />
    public partial class AddnewSchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentFiscals_ZoneCollectes_ZoneCollecteId",
                schema: "taxe",
                table: "AgentFiscals");

            migrationBuilder.DropForeignKey(
                name: "FK_CollecteTerrainSessions_AgentFiscals_AgentFiscalId",
                schema: "taxe",
                table: "CollecteTerrainSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_CollecteTerrainSessions_ZoneCollectes_ZoneCollecteId",
                schema: "taxe",
                table: "CollecteTerrainSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Communes_Provinces_ProvinceId",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropForeignKey(
                name: "FK_Communes_Provinces_ProvinceId1",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropForeignKey(
                name: "FK_Communes_Provinces_ProvinceId2",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropForeignKey(
                name: "FK_Communes_Regions_RegionId",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropForeignKey(
                name: "FK_Echeances_ObligationFiscales_ObligationFiscaleId",
                schema: "taxe",
                table: "Echeances");

            migrationBuilder.DropForeignKey(
                name: "FK_ObligationFiscales_Communes_CommuneId",
                schema: "taxe",
                table: "ObligationFiscales");

            migrationBuilder.DropForeignKey(
                name: "FK_ObligationFiscales_Contribuables_ContribuableId",
                schema: "taxe",
                table: "ObligationFiscales");

            migrationBuilder.DropForeignKey(
                name: "FK_ObligationFiscales_TypeTaxes_TypeTaxeId",
                schema: "taxe",
                table: "ObligationFiscales");

            migrationBuilder.DropForeignKey(
                name: "FK_PaiementTerrains_Echeances_EcheanceId",
                schema: "taxe",
                table: "PaiementTerrains");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalites_Taxes_TaxeConcerneeId",
                schema: "taxe",
                table: "Penalites");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Communes_ChefLieuId",
                schema: "taxe",
                table: "Regions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionCollectes_CollecteTerrainSessions_CollecteTerrai~",
                schema: "taxe",
                table: "TransactionCollectes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionCollectes_Echeances_EcheanceId",
                schema: "taxe",
                table: "TransactionCollectes");

            migrationBuilder.DropForeignKey(
                name: "FK_ZoneCollectes_Communes_CommuneId",
                schema: "taxe",
                table: "ZoneCollectes");

            migrationBuilder.DropTable(
                name: "Provinces",
                schema: "taxe");

            migrationBuilder.DropIndex(
                name: "IX_Communes_ProvinceId",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZoneCollectes",
                schema: "taxe",
                table: "ZoneCollectes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeTaxes",
                schema: "taxe",
                table: "TypeTaxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionCollectes",
                schema: "taxe",
                table: "TransactionCollectes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Taxes",
                schema: "taxe",
                table: "Taxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObligationFiscales",
                schema: "taxe",
                table: "ObligationFiscales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Echeances",
                schema: "taxe",
                table: "Echeances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollecteTerrainSessions",
                schema: "taxe",
                table: "CollecteTerrainSessions");

            migrationBuilder.DropColumn(
                name: "AdresseSiege",
                schema: "taxe",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Contact",
                schema: "taxe",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "taxe",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                schema: "taxe",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "SiteWeb",
                schema: "taxe",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.RenameTable(
                name: "ZoneCollectes",
                schema: "taxe",
                newName: "ZoneCollecte",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "TypeTaxes",
                schema: "taxe",
                newName: "TypeTaxe",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "TransactionCollectes",
                schema: "taxe",
                newName: "TransactionCollecte",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "Taxes",
                schema: "taxe",
                newName: "Taxe",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "ObligationFiscales",
                schema: "taxe",
                newName: "ObligationFiscale",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "Echeances",
                schema: "taxe",
                newName: "Echeance",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "CollecteTerrainSessions",
                schema: "taxe",
                newName: "CollecteTerrainSession",
                newSchema: "taxe");

            migrationBuilder.RenameColumn(
                name: "ProvinceId2",
                schema: "taxe",
                table: "Communes",
                newName: "RegionId6");

            migrationBuilder.RenameColumn(
                name: "ProvinceId1",
                schema: "taxe",
                table: "Communes",
                newName: "RegionId5");

            migrationBuilder.RenameIndex(
                name: "IX_Communes_ProvinceId2",
                schema: "taxe",
                table: "Communes",
                newName: "IX_Communes_RegionId6");

            migrationBuilder.RenameIndex(
                name: "IX_Communes_ProvinceId1",
                schema: "taxe",
                table: "Communes",
                newName: "IX_Communes_RegionId5");

            migrationBuilder.RenameIndex(
                name: "IX_ZoneCollectes_CommuneId",
                schema: "taxe",
                table: "ZoneCollecte",
                newName: "IX_ZoneCollecte_CommuneId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionCollectes_EcheanceId",
                schema: "taxe",
                table: "TransactionCollecte",
                newName: "IX_TransactionCollecte_EcheanceId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionCollectes_CollecteTerrainSessionId",
                schema: "taxe",
                table: "TransactionCollecte",
                newName: "IX_TransactionCollecte_CollecteTerrainSessionId");

            migrationBuilder.RenameIndex(
                name: "IX_ObligationFiscales_TypeTaxeId",
                schema: "taxe",
                table: "ObligationFiscale",
                newName: "IX_ObligationFiscale_TypeTaxeId");

            migrationBuilder.RenameIndex(
                name: "IX_ObligationFiscales_ContribuableId",
                schema: "taxe",
                table: "ObligationFiscale",
                newName: "IX_ObligationFiscale_ContribuableId");

            migrationBuilder.RenameIndex(
                name: "IX_ObligationFiscales_CommuneId",
                schema: "taxe",
                table: "ObligationFiscale",
                newName: "IX_ObligationFiscale_CommuneId");

            migrationBuilder.RenameIndex(
                name: "IX_Echeances_ObligationFiscaleId",
                schema: "taxe",
                table: "Echeance",
                newName: "IX_Echeance_ObligationFiscaleId");

            migrationBuilder.RenameIndex(
                name: "IX_CollecteTerrainSessions_ZoneCollecteId",
                schema: "taxe",
                table: "CollecteTerrainSession",
                newName: "IX_CollecteTerrainSession_ZoneCollecteId");

            migrationBuilder.RenameIndex(
                name: "IX_CollecteTerrainSessions_AgentFiscalId",
                schema: "taxe",
                table: "CollecteTerrainSession",
                newName: "IX_CollecteTerrainSession_AgentFiscalId");

            migrationBuilder.AlterColumn<Guid>(
                name: "RegionId",
                schema: "taxe",
                table: "Communes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdresseCentreAdmin",
                schema: "taxe",
                table: "Communes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodeTenant",
                schema: "taxe",
                table: "Communes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactCentreAdmin",
                schema: "taxe",
                table: "Communes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailCentreAdmin",
                schema: "taxe",
                table: "Communes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EstTenantActif",
                schema: "taxe",
                table: "Communes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NomCentreAdmin",
                schema: "taxe",
                table: "Communes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Population",
                schema: "taxe",
                table: "Communes",
                type: "integer",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "ResponsableCentreAdmin",
                schema: "taxe",
                table: "Communes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Superficie",
                schema: "taxe",
                table: "Communes",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZoneCollecte",
                schema: "taxe",
                table: "ZoneCollecte",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeTaxe",
                schema: "taxe",
                table: "TypeTaxe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionCollecte",
                schema: "taxe",
                table: "TransactionCollecte",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Taxe",
                schema: "taxe",
                table: "Taxe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObligationFiscale",
                schema: "taxe",
                table: "ObligationFiscale",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Echeance",
                schema: "taxe",
                table: "Echeance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollecteTerrainSession",
                schema: "taxe",
                table: "CollecteTerrainSession",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AgentFiscals_ZoneCollecte_ZoneCollecteId",
                schema: "taxe",
                table: "AgentFiscals",
                column: "ZoneCollecteId",
                principalSchema: "taxe",
                principalTable: "ZoneCollecte",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollecteTerrainSession_AgentFiscals_AgentFiscalId",
                schema: "taxe",
                table: "CollecteTerrainSession",
                column: "AgentFiscalId",
                principalSchema: "taxe",
                principalTable: "AgentFiscals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollecteTerrainSession_ZoneCollecte_ZoneCollecteId",
                schema: "taxe",
                table: "CollecteTerrainSession",
                column: "ZoneCollecteId",
                principalSchema: "taxe",
                principalTable: "ZoneCollecte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Communes_Regions_RegionId",
                schema: "taxe",
                table: "Communes",
                column: "RegionId",
                principalSchema: "taxe",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Echeance_ObligationFiscale_ObligationFiscaleId",
                schema: "taxe",
                table: "Echeance",
                column: "ObligationFiscaleId",
                principalSchema: "taxe",
                principalTable: "ObligationFiscale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObligationFiscale_Communes_CommuneId",
                schema: "taxe",
                table: "ObligationFiscale",
                column: "CommuneId",
                principalSchema: "taxe",
                principalTable: "Communes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObligationFiscale_Contribuables_ContribuableId",
                schema: "taxe",
                table: "ObligationFiscale",
                column: "ContribuableId",
                principalSchema: "taxe",
                principalTable: "Contribuables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObligationFiscale_TypeTaxe_TypeTaxeId",
                schema: "taxe",
                table: "ObligationFiscale",
                column: "TypeTaxeId",
                principalSchema: "taxe",
                principalTable: "TypeTaxe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaiementTerrains_Echeance_EcheanceId",
                schema: "taxe",
                table: "PaiementTerrains",
                column: "EcheanceId",
                principalSchema: "taxe",
                principalTable: "Echeance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Penalites_Taxe_TaxeConcerneeId",
                schema: "taxe",
                table: "Penalites",
                column: "TaxeConcerneeId",
                principalSchema: "taxe",
                principalTable: "Taxe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Communes_ChefLieuId",
                schema: "taxe",
                table: "Regions",
                column: "ChefLieuId",
                principalSchema: "taxe",
                principalTable: "Communes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionCollecte_CollecteTerrainSession_CollecteTerrainS~",
                schema: "taxe",
                table: "TransactionCollecte",
                column: "CollecteTerrainSessionId",
                principalSchema: "taxe",
                principalTable: "CollecteTerrainSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionCollecte_Echeance_EcheanceId",
                schema: "taxe",
                table: "TransactionCollecte",
                column: "EcheanceId",
                principalSchema: "taxe",
                principalTable: "Echeance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneCollecte_Communes_CommuneId",
                schema: "taxe",
                table: "ZoneCollecte",
                column: "CommuneId",
                principalSchema: "taxe",
                principalTable: "Communes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentFiscals_ZoneCollecte_ZoneCollecteId",
                schema: "taxe",
                table: "AgentFiscals");

            migrationBuilder.DropForeignKey(
                name: "FK_CollecteTerrainSession_AgentFiscals_AgentFiscalId",
                schema: "taxe",
                table: "CollecteTerrainSession");

            migrationBuilder.DropForeignKey(
                name: "FK_CollecteTerrainSession_ZoneCollecte_ZoneCollecteId",
                schema: "taxe",
                table: "CollecteTerrainSession");

            migrationBuilder.DropForeignKey(
                name: "FK_Communes_Regions_RegionId",
                schema: "taxe",
                table: "Communes");

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

            migrationBuilder.DropForeignKey(
                name: "FK_Echeance_ObligationFiscale_ObligationFiscaleId",
                schema: "taxe",
                table: "Echeance");

            migrationBuilder.DropForeignKey(
                name: "FK_ObligationFiscale_Communes_CommuneId",
                schema: "taxe",
                table: "ObligationFiscale");

            migrationBuilder.DropForeignKey(
                name: "FK_ObligationFiscale_Contribuables_ContribuableId",
                schema: "taxe",
                table: "ObligationFiscale");

            migrationBuilder.DropForeignKey(
                name: "FK_ObligationFiscale_TypeTaxe_TypeTaxeId",
                schema: "taxe",
                table: "ObligationFiscale");

            migrationBuilder.DropForeignKey(
                name: "FK_PaiementTerrains_Echeance_EcheanceId",
                schema: "taxe",
                table: "PaiementTerrains");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalites_Taxe_TaxeConcerneeId",
                schema: "taxe",
                table: "Penalites");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Communes_ChefLieuId",
                schema: "taxe",
                table: "Regions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionCollecte_CollecteTerrainSession_CollecteTerrainS~",
                schema: "taxe",
                table: "TransactionCollecte");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionCollecte_Echeance_EcheanceId",
                schema: "taxe",
                table: "TransactionCollecte");

            migrationBuilder.DropForeignKey(
                name: "FK_ZoneCollecte_Communes_CommuneId",
                schema: "taxe",
                table: "ZoneCollecte");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZoneCollecte",
                schema: "taxe",
                table: "ZoneCollecte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeTaxe",
                schema: "taxe",
                table: "TypeTaxe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionCollecte",
                schema: "taxe",
                table: "TransactionCollecte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Taxe",
                schema: "taxe",
                table: "Taxe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObligationFiscale",
                schema: "taxe",
                table: "ObligationFiscale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Echeance",
                schema: "taxe",
                table: "Echeance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollecteTerrainSession",
                schema: "taxe",
                table: "CollecteTerrainSession");

            migrationBuilder.DropColumn(
                name: "AdresseCentreAdmin",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "CodeTenant",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "ContactCentreAdmin",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "EmailCentreAdmin",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "EstTenantActif",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "NomCentreAdmin",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "Population",
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
                name: "ResponsableCentreAdmin",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "Superficie",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.RenameTable(
                name: "ZoneCollecte",
                schema: "taxe",
                newName: "ZoneCollectes",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "TypeTaxe",
                schema: "taxe",
                newName: "TypeTaxes",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "TransactionCollecte",
                schema: "taxe",
                newName: "TransactionCollectes",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "Taxe",
                schema: "taxe",
                newName: "Taxes",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "ObligationFiscale",
                schema: "taxe",
                newName: "ObligationFiscales",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "Echeance",
                schema: "taxe",
                newName: "Echeances",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "CollecteTerrainSession",
                schema: "taxe",
                newName: "CollecteTerrainSessions",
                newSchema: "taxe");

            migrationBuilder.RenameColumn(
                name: "RegionId6",
                schema: "taxe",
                table: "Communes",
                newName: "ProvinceId2");

            migrationBuilder.RenameColumn(
                name: "RegionId5",
                schema: "taxe",
                table: "Communes",
                newName: "ProvinceId1");

            migrationBuilder.RenameIndex(
                name: "IX_Communes_RegionId6",
                schema: "taxe",
                table: "Communes",
                newName: "IX_Communes_ProvinceId2");

            migrationBuilder.RenameIndex(
                name: "IX_Communes_RegionId5",
                schema: "taxe",
                table: "Communes",
                newName: "IX_Communes_ProvinceId1");

            migrationBuilder.RenameIndex(
                name: "IX_ZoneCollecte_CommuneId",
                schema: "taxe",
                table: "ZoneCollectes",
                newName: "IX_ZoneCollectes_CommuneId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionCollecte_EcheanceId",
                schema: "taxe",
                table: "TransactionCollectes",
                newName: "IX_TransactionCollectes_EcheanceId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionCollecte_CollecteTerrainSessionId",
                schema: "taxe",
                table: "TransactionCollectes",
                newName: "IX_TransactionCollectes_CollecteTerrainSessionId");

            migrationBuilder.RenameIndex(
                name: "IX_ObligationFiscale_TypeTaxeId",
                schema: "taxe",
                table: "ObligationFiscales",
                newName: "IX_ObligationFiscales_TypeTaxeId");

            migrationBuilder.RenameIndex(
                name: "IX_ObligationFiscale_ContribuableId",
                schema: "taxe",
                table: "ObligationFiscales",
                newName: "IX_ObligationFiscales_ContribuableId");

            migrationBuilder.RenameIndex(
                name: "IX_ObligationFiscale_CommuneId",
                schema: "taxe",
                table: "ObligationFiscales",
                newName: "IX_ObligationFiscales_CommuneId");

            migrationBuilder.RenameIndex(
                name: "IX_Echeance_ObligationFiscaleId",
                schema: "taxe",
                table: "Echeances",
                newName: "IX_Echeances_ObligationFiscaleId");

            migrationBuilder.RenameIndex(
                name: "IX_CollecteTerrainSession_ZoneCollecteId",
                schema: "taxe",
                table: "CollecteTerrainSessions",
                newName: "IX_CollecteTerrainSessions_ZoneCollecteId");

            migrationBuilder.RenameIndex(
                name: "IX_CollecteTerrainSession_AgentFiscalId",
                schema: "taxe",
                table: "CollecteTerrainSessions",
                newName: "IX_CollecteTerrainSessions_AgentFiscalId");

            migrationBuilder.AddColumn<string>(
                name: "AdresseSiege",
                schema: "taxe",
                table: "Regions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                schema: "taxe",
                table: "Regions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "taxe",
                table: "Regions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                schema: "taxe",
                table: "Regions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SiteWeb",
                schema: "taxe",
                table: "Regions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "RegionId",
                schema: "taxe",
                table: "Communes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId",
                schema: "taxe",
                table: "Communes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZoneCollectes",
                schema: "taxe",
                table: "ZoneCollectes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeTaxes",
                schema: "taxe",
                table: "TypeTaxes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionCollectes",
                schema: "taxe",
                table: "TransactionCollectes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Taxes",
                schema: "taxe",
                table: "Taxes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObligationFiscales",
                schema: "taxe",
                table: "ObligationFiscales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Echeances",
                schema: "taxe",
                table: "Echeances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollecteTerrainSessions",
                schema: "taxe",
                table: "CollecteTerrainSessions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Provinces",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChefLieuId = table.Column<Guid>(type: "uuid", nullable: true),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdresseSiege = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LogoUrl = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SiteWeb = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Communes_ChefLieuId",
                        column: x => x.ChefLieuId,
                        principalSchema: "taxe",
                        principalTable: "Communes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Provinces_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "taxe",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Communes_ProvinceId",
                schema: "taxe",
                table: "Communes",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_ChefLieuId",
                schema: "taxe",
                table: "Provinces",
                column: "ChefLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_RegionId",
                schema: "taxe",
                table: "Provinces",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentFiscals_ZoneCollectes_ZoneCollecteId",
                schema: "taxe",
                table: "AgentFiscals",
                column: "ZoneCollecteId",
                principalSchema: "taxe",
                principalTable: "ZoneCollectes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollecteTerrainSessions_AgentFiscals_AgentFiscalId",
                schema: "taxe",
                table: "CollecteTerrainSessions",
                column: "AgentFiscalId",
                principalSchema: "taxe",
                principalTable: "AgentFiscals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollecteTerrainSessions_ZoneCollectes_ZoneCollecteId",
                schema: "taxe",
                table: "CollecteTerrainSessions",
                column: "ZoneCollecteId",
                principalSchema: "taxe",
                principalTable: "ZoneCollectes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Communes_Provinces_ProvinceId",
                schema: "taxe",
                table: "Communes",
                column: "ProvinceId",
                principalSchema: "taxe",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Communes_Provinces_ProvinceId1",
                schema: "taxe",
                table: "Communes",
                column: "ProvinceId1",
                principalSchema: "taxe",
                principalTable: "Provinces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communes_Provinces_ProvinceId2",
                schema: "taxe",
                table: "Communes",
                column: "ProvinceId2",
                principalSchema: "taxe",
                principalTable: "Provinces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communes_Regions_RegionId",
                schema: "taxe",
                table: "Communes",
                column: "RegionId",
                principalSchema: "taxe",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Echeances_ObligationFiscales_ObligationFiscaleId",
                schema: "taxe",
                table: "Echeances",
                column: "ObligationFiscaleId",
                principalSchema: "taxe",
                principalTable: "ObligationFiscales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObligationFiscales_Communes_CommuneId",
                schema: "taxe",
                table: "ObligationFiscales",
                column: "CommuneId",
                principalSchema: "taxe",
                principalTable: "Communes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObligationFiscales_Contribuables_ContribuableId",
                schema: "taxe",
                table: "ObligationFiscales",
                column: "ContribuableId",
                principalSchema: "taxe",
                principalTable: "Contribuables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObligationFiscales_TypeTaxes_TypeTaxeId",
                schema: "taxe",
                table: "ObligationFiscales",
                column: "TypeTaxeId",
                principalSchema: "taxe",
                principalTable: "TypeTaxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaiementTerrains_Echeances_EcheanceId",
                schema: "taxe",
                table: "PaiementTerrains",
                column: "EcheanceId",
                principalSchema: "taxe",
                principalTable: "Echeances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Penalites_Taxes_TaxeConcerneeId",
                schema: "taxe",
                table: "Penalites",
                column: "TaxeConcerneeId",
                principalSchema: "taxe",
                principalTable: "Taxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Communes_ChefLieuId",
                schema: "taxe",
                table: "Regions",
                column: "ChefLieuId",
                principalSchema: "taxe",
                principalTable: "Communes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionCollectes_CollecteTerrainSessions_CollecteTerrai~",
                schema: "taxe",
                table: "TransactionCollectes",
                column: "CollecteTerrainSessionId",
                principalSchema: "taxe",
                principalTable: "CollecteTerrainSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionCollectes_Echeances_EcheanceId",
                schema: "taxe",
                table: "TransactionCollectes",
                column: "EcheanceId",
                principalSchema: "taxe",
                principalTable: "Echeances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneCollectes_Communes_CommuneId",
                schema: "taxe",
                table: "ZoneCollectes",
                column: "CommuneId",
                principalSchema: "taxe",
                principalTable: "Communes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
