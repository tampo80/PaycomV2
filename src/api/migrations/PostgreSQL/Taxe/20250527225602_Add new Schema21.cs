using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCom.WebApi.Migrations.PostgreSQL.Taxe
{
    /// <inheritdoc />
    public partial class AddnewSchema21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_PaiementTerrains_AgentFiscals_AgentFiscalId",
                schema: "taxe",
                table: "PaiementTerrains");

            migrationBuilder.DropForeignKey(
                name: "FK_PaiementTerrains_Echeance_EcheanceId",
                schema: "taxe",
                table: "PaiementTerrains");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalites_Taxe_TaxeConcerneeId",
                schema: "taxe",
                table: "Penalites");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgentFiscals",
                schema: "taxe",
                table: "AgentFiscals");

            migrationBuilder.RenameTable(
                name: "ZoneCollecte",
                schema: "taxe",
                newName: "ZonesCollecte",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "TypeTaxe",
                schema: "taxe",
                newName: "TypesTaxe",
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
                newName: "ObligationsFiscales",
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

            migrationBuilder.RenameTable(
                name: "AgentFiscals",
                schema: "taxe",
                newName: "AgentsFiscaux",
                newSchema: "taxe");

            migrationBuilder.RenameIndex(
                name: "IX_ZoneCollecte_CommuneId",
                schema: "taxe",
                table: "ZonesCollecte",
                newName: "IX_ZonesCollecte_CommuneId");

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
                table: "ObligationsFiscales",
                newName: "IX_ObligationsFiscales_TypeTaxeId");

            migrationBuilder.RenameIndex(
                name: "IX_ObligationFiscale_ContribuableId",
                schema: "taxe",
                table: "ObligationsFiscales",
                newName: "IX_ObligationsFiscales_ContribuableId");

            migrationBuilder.RenameIndex(
                name: "IX_ObligationFiscale_CommuneId",
                schema: "taxe",
                table: "ObligationsFiscales",
                newName: "IX_ObligationsFiscales_CommuneId");

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

            migrationBuilder.RenameIndex(
                name: "IX_AgentFiscals_ZoneCollecteId",
                schema: "taxe",
                table: "AgentsFiscaux",
                newName: "IX_AgentsFiscaux_ZoneCollecteId");

            migrationBuilder.AddColumn<Guid>(
                name: "AgentCollecteurId",
                schema: "taxe",
                table: "TransactionPaiements",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BanqueEmettrice",
                schema: "taxe",
                table: "TransactionPaiements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateVirement",
                schema: "taxe",
                table: "TransactionPaiements",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstPaiementTerrain",
                schema: "taxe",
                table: "TransactionPaiements",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LieuCollecte",
                schema: "taxe",
                table: "TransactionPaiements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroCompte",
                schema: "taxe",
                table: "TransactionPaiements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceVirement",
                schema: "taxe",
                table: "TransactionPaiements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SessionCollecteId",
                schema: "taxe",
                table: "TransactionPaiements",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLecture",
                schema: "taxe",
                table: "Notifications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstLue",
                schema: "taxe",
                table: "Notifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "taxe",
                table: "Contribuables",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroRegistreCommerce",
                schema: "taxe",
                table: "Contribuables",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TypeContribuable",
                schema: "taxe",
                table: "Contribuables",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UtilisateurId",
                schema: "taxe",
                table: "Contribuables",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFinFonction",
                schema: "taxe",
                table: "AgentsFiscaux",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "taxe",
                table: "AgentsFiscaux",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EstCollecteurTerrain",
                schema: "taxe",
                table: "AgentsFiscaux",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "SoldePortefeuille",
                schema: "taxe",
                table: "AgentsFiscaux",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                schema: "taxe",
                table: "AgentsFiscaux",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UtilisateurId",
                schema: "taxe",
                table: "AgentsFiscaux",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZonesCollecte",
                schema: "taxe",
                table: "ZonesCollecte",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypesTaxe",
                schema: "taxe",
                table: "TypesTaxe",
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
                name: "PK_ObligationsFiscales",
                schema: "taxe",
                table: "ObligationsFiscales",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgentsFiscaux",
                schema: "taxe",
                table: "AgentsFiscaux",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentsFiscaux_ZonesCollecte_ZoneCollecteId",
                schema: "taxe",
                table: "AgentsFiscaux",
                column: "ZoneCollecteId",
                principalSchema: "taxe",
                principalTable: "ZonesCollecte",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollecteTerrainSessions_AgentsFiscaux_AgentFiscalId",
                schema: "taxe",
                table: "CollecteTerrainSessions",
                column: "AgentFiscalId",
                principalSchema: "taxe",
                principalTable: "AgentsFiscaux",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollecteTerrainSessions_ZonesCollecte_ZoneCollecteId",
                schema: "taxe",
                table: "CollecteTerrainSessions",
                column: "ZoneCollecteId",
                principalSchema: "taxe",
                principalTable: "ZonesCollecte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Echeances_ObligationsFiscales_ObligationFiscaleId",
                schema: "taxe",
                table: "Echeances",
                column: "ObligationFiscaleId",
                principalSchema: "taxe",
                principalTable: "ObligationsFiscales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObligationsFiscales_Communes_CommuneId",
                schema: "taxe",
                table: "ObligationsFiscales",
                column: "CommuneId",
                principalSchema: "taxe",
                principalTable: "Communes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObligationsFiscales_Contribuables_ContribuableId",
                schema: "taxe",
                table: "ObligationsFiscales",
                column: "ContribuableId",
                principalSchema: "taxe",
                principalTable: "Contribuables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObligationsFiscales_TypesTaxe_TypeTaxeId",
                schema: "taxe",
                table: "ObligationsFiscales",
                column: "TypeTaxeId",
                principalSchema: "taxe",
                principalTable: "TypesTaxe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaiementTerrains_AgentsFiscaux_AgentFiscalId",
                schema: "taxe",
                table: "PaiementTerrains",
                column: "AgentFiscalId",
                principalSchema: "taxe",
                principalTable: "AgentsFiscaux",
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
                name: "FK_ZonesCollecte_Communes_CommuneId",
                schema: "taxe",
                table: "ZonesCollecte",
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
                name: "FK_AgentsFiscaux_ZonesCollecte_ZoneCollecteId",
                schema: "taxe",
                table: "AgentsFiscaux");

            migrationBuilder.DropForeignKey(
                name: "FK_CollecteTerrainSessions_AgentsFiscaux_AgentFiscalId",
                schema: "taxe",
                table: "CollecteTerrainSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_CollecteTerrainSessions_ZonesCollecte_ZoneCollecteId",
                schema: "taxe",
                table: "CollecteTerrainSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Echeances_ObligationsFiscales_ObligationFiscaleId",
                schema: "taxe",
                table: "Echeances");

            migrationBuilder.DropForeignKey(
                name: "FK_ObligationsFiscales_Communes_CommuneId",
                schema: "taxe",
                table: "ObligationsFiscales");

            migrationBuilder.DropForeignKey(
                name: "FK_ObligationsFiscales_Contribuables_ContribuableId",
                schema: "taxe",
                table: "ObligationsFiscales");

            migrationBuilder.DropForeignKey(
                name: "FK_ObligationsFiscales_TypesTaxe_TypeTaxeId",
                schema: "taxe",
                table: "ObligationsFiscales");

            migrationBuilder.DropForeignKey(
                name: "FK_PaiementTerrains_AgentsFiscaux_AgentFiscalId",
                schema: "taxe",
                table: "PaiementTerrains");

            migrationBuilder.DropForeignKey(
                name: "FK_PaiementTerrains_Echeances_EcheanceId",
                schema: "taxe",
                table: "PaiementTerrains");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalites_Taxes_TaxeConcerneeId",
                schema: "taxe",
                table: "Penalites");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionCollectes_CollecteTerrainSessions_CollecteTerrai~",
                schema: "taxe",
                table: "TransactionCollectes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionCollectes_Echeances_EcheanceId",
                schema: "taxe",
                table: "TransactionCollectes");

            migrationBuilder.DropForeignKey(
                name: "FK_ZonesCollecte_Communes_CommuneId",
                schema: "taxe",
                table: "ZonesCollecte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZonesCollecte",
                schema: "taxe",
                table: "ZonesCollecte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypesTaxe",
                schema: "taxe",
                table: "TypesTaxe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionCollectes",
                schema: "taxe",
                table: "TransactionCollectes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Taxes",
                schema: "taxe",
                table: "Taxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObligationsFiscales",
                schema: "taxe",
                table: "ObligationsFiscales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Echeances",
                schema: "taxe",
                table: "Echeances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollecteTerrainSessions",
                schema: "taxe",
                table: "CollecteTerrainSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgentsFiscaux",
                schema: "taxe",
                table: "AgentsFiscaux");

            migrationBuilder.DropColumn(
                name: "AgentCollecteurId",
                schema: "taxe",
                table: "TransactionPaiements");

            migrationBuilder.DropColumn(
                name: "BanqueEmettrice",
                schema: "taxe",
                table: "TransactionPaiements");

            migrationBuilder.DropColumn(
                name: "DateVirement",
                schema: "taxe",
                table: "TransactionPaiements");

            migrationBuilder.DropColumn(
                name: "EstPaiementTerrain",
                schema: "taxe",
                table: "TransactionPaiements");

            migrationBuilder.DropColumn(
                name: "LieuCollecte",
                schema: "taxe",
                table: "TransactionPaiements");

            migrationBuilder.DropColumn(
                name: "NumeroCompte",
                schema: "taxe",
                table: "TransactionPaiements");

            migrationBuilder.DropColumn(
                name: "ReferenceVirement",
                schema: "taxe",
                table: "TransactionPaiements");

            migrationBuilder.DropColumn(
                name: "SessionCollecteId",
                schema: "taxe",
                table: "TransactionPaiements");

            migrationBuilder.DropColumn(
                name: "DateLecture",
                schema: "taxe",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "EstLue",
                schema: "taxe",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "taxe",
                table: "Contribuables");

            migrationBuilder.DropColumn(
                name: "NumeroRegistreCommerce",
                schema: "taxe",
                table: "Contribuables");

            migrationBuilder.DropColumn(
                name: "TypeContribuable",
                schema: "taxe",
                table: "Contribuables");

            migrationBuilder.DropColumn(
                name: "UtilisateurId",
                schema: "taxe",
                table: "Contribuables");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "taxe",
                table: "AgentsFiscaux");

            migrationBuilder.DropColumn(
                name: "EstCollecteurTerrain",
                schema: "taxe",
                table: "AgentsFiscaux");

            migrationBuilder.DropColumn(
                name: "SoldePortefeuille",
                schema: "taxe",
                table: "AgentsFiscaux");

            migrationBuilder.DropColumn(
                name: "Telephone",
                schema: "taxe",
                table: "AgentsFiscaux");

            migrationBuilder.DropColumn(
                name: "UtilisateurId",
                schema: "taxe",
                table: "AgentsFiscaux");

            migrationBuilder.RenameTable(
                name: "ZonesCollecte",
                schema: "taxe",
                newName: "ZoneCollecte",
                newSchema: "taxe");

            migrationBuilder.RenameTable(
                name: "TypesTaxe",
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
                name: "ObligationsFiscales",
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

            migrationBuilder.RenameTable(
                name: "AgentsFiscaux",
                schema: "taxe",
                newName: "AgentFiscals",
                newSchema: "taxe");

            migrationBuilder.RenameIndex(
                name: "IX_ZonesCollecte_CommuneId",
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
                name: "IX_ObligationsFiscales_TypeTaxeId",
                schema: "taxe",
                table: "ObligationFiscale",
                newName: "IX_ObligationFiscale_TypeTaxeId");

            migrationBuilder.RenameIndex(
                name: "IX_ObligationsFiscales_ContribuableId",
                schema: "taxe",
                table: "ObligationFiscale",
                newName: "IX_ObligationFiscale_ContribuableId");

            migrationBuilder.RenameIndex(
                name: "IX_ObligationsFiscales_CommuneId",
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

            migrationBuilder.RenameIndex(
                name: "IX_AgentsFiscaux_ZoneCollecteId",
                schema: "taxe",
                table: "AgentFiscals",
                newName: "IX_AgentFiscals_ZoneCollecteId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFinFonction",
                schema: "taxe",
                table: "AgentFiscals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgentFiscals",
                schema: "taxe",
                table: "AgentFiscals",
                column: "Id");

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
                name: "FK_PaiementTerrains_AgentFiscals_AgentFiscalId",
                schema: "taxe",
                table: "PaiementTerrains",
                column: "AgentFiscalId",
                principalSchema: "taxe",
                principalTable: "AgentFiscals",
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
    }
}
