using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCom.WebApi.Migrations.PostgreSQL.Taxe
{
    /// <inheritdoc />
    public partial class AddnewSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentFiscals_ZoneCollecte_ZoneCollecteId",
                schema: "taxe",
                table: "AgentFiscals");

            migrationBuilder.DropForeignKey(
                name: "FK_Communes_Prefectures_PrefectureId",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropForeignKey(
                name: "FK_PaiementTerrains_Echeance_EcheanceId",
                schema: "taxe",
                table: "PaiementTerrains");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalites_Taxe_TaxeConcerneeId",
                schema: "taxe",
                table: "Penalites");

            migrationBuilder.DropTable(
                name: "Taxe",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "TransactionCollecte",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "CollecteTerrainSession",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Echeance",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "ZoneCollecte",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "ObligationFiscale",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "TypeTaxe",
                schema: "taxe");

            migrationBuilder.RenameColumn(
                name: "PrefectureId",
                schema: "taxe",
                table: "Communes",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Communes_PrefectureId",
                schema: "taxe",
                table: "Communes",
                newName: "IX_Communes_RegionId");

            migrationBuilder.AddColumn<string>(
                name: "AdresseSiege",
                schema: "taxe",
                table: "Regions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ChefLieuId",
                schema: "taxe",
                table: "Regions",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "NombreArrondissements",
                schema: "taxe",
                table: "Communes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NombreSecteurs",
                schema: "taxe",
                table: "Communes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId",
                schema: "taxe",
                table: "Communes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId1",
                schema: "taxe",
                table: "Communes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId2",
                schema: "taxe",
                table: "Communes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "taxe",
                table: "Communes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeChefLieu",
                schema: "taxe",
                table: "Communes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Provinces",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LogoUrl = table.Column<string>(type: "text", nullable: false),
                    AdresseSiege = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    SiteWeb = table.Column<string>(type: "text", nullable: false),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChefLieuId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Taxes",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnneeImposition = table.Column<int>(type: "integer", nullable: false),
                    Taux = table.Column<double>(type: "double precision", nullable: false),
                    DateEcheance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MontantDu = table.Column<double>(type: "double precision", nullable: false),
                    MontantPaye = table.Column<double>(type: "double precision", nullable: false),
                    SoldeRestant = table.Column<double>(type: "double precision", nullable: false),
                    PrixUnitaire = table.Column<double>(type: "double precision", nullable: false),
                    UniteMesure = table.Column<string>(type: "text", nullable: false),
                    Caracteristiques = table.Column<string>(type: "text", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeTaxes",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EstPeriodique = table.Column<bool>(type: "boolean", nullable: false),
                    FrequencePaiement = table.Column<int>(type: "integer", nullable: false),
                    TauxBase = table.Column<double>(type: "double precision", nullable: false),
                    UniteMesure = table.Column<string>(type: "text", nullable: false),
                    NecessiteInspection = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTaxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZoneCollectes",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    CommuneId = table.Column<Guid>(type: "uuid", nullable: false),
                    DelimitationGeoJSON = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneCollectes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZoneCollectes_Communes_CommuneId",
                        column: x => x.CommuneId,
                        principalSchema: "taxe",
                        principalTable: "Communes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObligationFiscales",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContribuableId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeTaxeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CommuneId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReferenceProprieteBien = table.Column<string>(type: "text", nullable: false),
                    LocalisationGPS = table.Column<string>(type: "text", nullable: false),
                    EstActif = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObligationFiscales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObligationFiscales_Communes_CommuneId",
                        column: x => x.CommuneId,
                        principalSchema: "taxe",
                        principalTable: "Communes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObligationFiscales_Contribuables_ContribuableId",
                        column: x => x.ContribuableId,
                        principalSchema: "taxe",
                        principalTable: "Contribuables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObligationFiscales_TypeTaxes_TypeTaxeId",
                        column: x => x.TypeTaxeId,
                        principalSchema: "taxe",
                        principalTable: "TypeTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollecteTerrainSessions",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AgentFiscalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ZoneCollecteId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Statut = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollecteTerrainSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollecteTerrainSessions_AgentFiscals_AgentFiscalId",
                        column: x => x.AgentFiscalId,
                        principalSchema: "taxe",
                        principalTable: "AgentFiscals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollecteTerrainSessions_ZoneCollectes_ZoneCollecteId",
                        column: x => x.ZoneCollecteId,
                        principalSchema: "taxe",
                        principalTable: "ZoneCollectes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Echeances",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ObligationFiscaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnneeImposition = table.Column<int>(type: "integer", nullable: false),
                    PeriodeImposition = table.Column<int>(type: "integer", nullable: false),
                    DateEcheance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MontantBase = table.Column<double>(type: "double precision", nullable: false),
                    MontantPenalites = table.Column<double>(type: "double precision", nullable: false),
                    MontantTotal = table.Column<double>(type: "double precision", nullable: false),
                    Statut = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Echeances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Echeances_ObligationFiscales_ObligationFiscaleId",
                        column: x => x.ObligationFiscaleId,
                        principalSchema: "taxe",
                        principalTable: "ObligationFiscales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCollectes",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CollecteTerrainSessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    EcheanceId = table.Column<Guid>(type: "uuid", nullable: false),
                    MontantPercu = table.Column<double>(type: "double precision", nullable: false),
                    ModePaiement = table.Column<int>(type: "integer", nullable: false),
                    ReferenceTransaction = table.Column<string>(type: "text", nullable: false),
                    HorodatageTransaction = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LocalisationGPS = table.Column<string>(type: "text", nullable: false),
                    EstSynchronise = table.Column<bool>(type: "boolean", nullable: false),
                    SignatureContribuable = table.Column<string>(type: "text", nullable: false),
                    PhotoPreuve = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCollectes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionCollectes_CollecteTerrainSessions_CollecteTerrai~",
                        column: x => x.CollecteTerrainSessionId,
                        principalSchema: "taxe",
                        principalTable: "CollecteTerrainSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionCollectes_Echeances_EcheanceId",
                        column: x => x.EcheanceId,
                        principalSchema: "taxe",
                        principalTable: "Echeances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ChefLieuId",
                schema: "taxe",
                table: "Regions",
                column: "ChefLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_ProvinceId",
                schema: "taxe",
                table: "Communes",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_ProvinceId1",
                schema: "taxe",
                table: "Communes",
                column: "ProvinceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_ProvinceId2",
                schema: "taxe",
                table: "Communes",
                column: "ProvinceId2");

            migrationBuilder.CreateIndex(
                name: "IX_CollecteTerrainSessions_AgentFiscalId",
                schema: "taxe",
                table: "CollecteTerrainSessions",
                column: "AgentFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_CollecteTerrainSessions_ZoneCollecteId",
                schema: "taxe",
                table: "CollecteTerrainSessions",
                column: "ZoneCollecteId");

            migrationBuilder.CreateIndex(
                name: "IX_Echeances_ObligationFiscaleId",
                schema: "taxe",
                table: "Echeances",
                column: "ObligationFiscaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ObligationFiscales_CommuneId",
                schema: "taxe",
                table: "ObligationFiscales",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_ObligationFiscales_ContribuableId",
                schema: "taxe",
                table: "ObligationFiscales",
                column: "ContribuableId");

            migrationBuilder.CreateIndex(
                name: "IX_ObligationFiscales_TypeTaxeId",
                schema: "taxe",
                table: "ObligationFiscales",
                column: "TypeTaxeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCollectes_CollecteTerrainSessionId",
                schema: "taxe",
                table: "TransactionCollectes",
                column: "CollecteTerrainSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCollectes_EcheanceId",
                schema: "taxe",
                table: "TransactionCollectes",
                column: "EcheanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneCollectes_CommuneId",
                schema: "taxe",
                table: "ZoneCollectes",
                column: "CommuneId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentFiscals_ZoneCollectes_ZoneCollecteId",
                schema: "taxe",
                table: "AgentFiscals",
                column: "ZoneCollecteId",
                principalSchema: "taxe",
                principalTable: "ZoneCollectes",
                principalColumn: "Id");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentFiscals_ZoneCollectes_ZoneCollecteId",
                schema: "taxe",
                table: "AgentFiscals");

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

            migrationBuilder.DropTable(
                name: "Provinces",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Taxes",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "TransactionCollectes",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "CollecteTerrainSessions",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Echeances",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "ZoneCollectes",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "ObligationFiscales",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "TypeTaxes",
                schema: "taxe");

            migrationBuilder.DropIndex(
                name: "IX_Regions_ChefLieuId",
                schema: "taxe",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Communes_ProvinceId",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropIndex(
                name: "IX_Communes_ProvinceId1",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropIndex(
                name: "IX_Communes_ProvinceId2",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "AdresseSiege",
                schema: "taxe",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "ChefLieuId",
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
                name: "NombreArrondissements",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "NombreSecteurs",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "ProvinceId1",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "ProvinceId2",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "TypeChefLieu",
                schema: "taxe",
                table: "Communes");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                schema: "taxe",
                table: "Communes",
                newName: "PrefectureId");

            migrationBuilder.RenameIndex(
                name: "IX_Communes_RegionId",
                schema: "taxe",
                table: "Communes",
                newName: "IX_Communes_PrefectureId");

            migrationBuilder.CreateTable(
                name: "Taxe",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnneeImposition = table.Column<int>(type: "integer", nullable: false),
                    Caracteristiques = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateDerniereModification = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEcheance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    MontantDu = table.Column<double>(type: "double precision", nullable: false),
                    MontantPaye = table.Column<double>(type: "double precision", nullable: false),
                    PrixUnitaire = table.Column<double>(type: "double precision", nullable: false),
                    SoldeRestant = table.Column<double>(type: "double precision", nullable: false),
                    Taux = table.Column<double>(type: "double precision", nullable: false),
                    UniteMesure = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeTaxe",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EstPeriodique = table.Column<bool>(type: "boolean", nullable: false),
                    FrequencePaiement = table.Column<int>(type: "integer", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    NecessiteInspection = table.Column<bool>(type: "boolean", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    TauxBase = table.Column<double>(type: "double precision", nullable: false),
                    UniteMesure = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTaxe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZoneCollecte",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CommuneId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DelimitationGeoJSON = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Nom = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneCollecte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZoneCollecte_Communes_CommuneId",
                        column: x => x.CommuneId,
                        principalSchema: "taxe",
                        principalTable: "Communes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObligationFiscale",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CommuneId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContribuableId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeTaxeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    EstActif = table.Column<bool>(type: "boolean", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LocalisationGPS = table.Column<string>(type: "text", nullable: false),
                    ReferenceProprieteBien = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObligationFiscale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObligationFiscale_Communes_CommuneId",
                        column: x => x.CommuneId,
                        principalSchema: "taxe",
                        principalTable: "Communes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObligationFiscale_Contribuables_ContribuableId",
                        column: x => x.ContribuableId,
                        principalSchema: "taxe",
                        principalTable: "Contribuables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObligationFiscale_TypeTaxe_TypeTaxeId",
                        column: x => x.TypeTaxeId,
                        principalSchema: "taxe",
                        principalTable: "TypeTaxe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollecteTerrainSession",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AgentFiscalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ZoneCollecteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    Statut = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollecteTerrainSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollecteTerrainSession_AgentFiscals_AgentFiscalId",
                        column: x => x.AgentFiscalId,
                        principalSchema: "taxe",
                        principalTable: "AgentFiscals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollecteTerrainSession_ZoneCollecte_ZoneCollecteId",
                        column: x => x.ZoneCollecteId,
                        principalSchema: "taxe",
                        principalTable: "ZoneCollecte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Echeance",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ObligationFiscaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnneeImposition = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DateEcheance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    MontantBase = table.Column<double>(type: "double precision", nullable: false),
                    MontantPenalites = table.Column<double>(type: "double precision", nullable: false),
                    MontantTotal = table.Column<double>(type: "double precision", nullable: false),
                    PeriodeImposition = table.Column<int>(type: "integer", nullable: false),
                    Statut = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Echeance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Echeance_ObligationFiscale_ObligationFiscaleId",
                        column: x => x.ObligationFiscaleId,
                        principalSchema: "taxe",
                        principalTable: "ObligationFiscale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCollecte",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CollecteTerrainSessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    EcheanceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    EstSynchronise = table.Column<bool>(type: "boolean", nullable: false),
                    HorodatageTransaction = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LocalisationGPS = table.Column<string>(type: "text", nullable: false),
                    ModePaiement = table.Column<int>(type: "integer", nullable: false),
                    MontantPercu = table.Column<double>(type: "double precision", nullable: false),
                    PhotoPreuve = table.Column<string>(type: "text", nullable: false),
                    ReferenceTransaction = table.Column<string>(type: "text", nullable: false),
                    SignatureContribuable = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCollecte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionCollecte_CollecteTerrainSession_CollecteTerrainS~",
                        column: x => x.CollecteTerrainSessionId,
                        principalSchema: "taxe",
                        principalTable: "CollecteTerrainSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionCollecte_Echeance_EcheanceId",
                        column: x => x.EcheanceId,
                        principalSchema: "taxe",
                        principalTable: "Echeance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollecteTerrainSession_AgentFiscalId",
                schema: "taxe",
                table: "CollecteTerrainSession",
                column: "AgentFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_CollecteTerrainSession_ZoneCollecteId",
                schema: "taxe",
                table: "CollecteTerrainSession",
                column: "ZoneCollecteId");

            migrationBuilder.CreateIndex(
                name: "IX_Echeance_ObligationFiscaleId",
                schema: "taxe",
                table: "Echeance",
                column: "ObligationFiscaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ObligationFiscale_CommuneId",
                schema: "taxe",
                table: "ObligationFiscale",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_ObligationFiscale_ContribuableId",
                schema: "taxe",
                table: "ObligationFiscale",
                column: "ContribuableId");

            migrationBuilder.CreateIndex(
                name: "IX_ObligationFiscale_TypeTaxeId",
                schema: "taxe",
                table: "ObligationFiscale",
                column: "TypeTaxeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCollecte_CollecteTerrainSessionId",
                schema: "taxe",
                table: "TransactionCollecte",
                column: "CollecteTerrainSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCollecte_EcheanceId",
                schema: "taxe",
                table: "TransactionCollecte",
                column: "EcheanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneCollecte_CommuneId",
                schema: "taxe",
                table: "ZoneCollecte",
                column: "CommuneId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentFiscals_ZoneCollecte_ZoneCollecteId",
                schema: "taxe",
                table: "AgentFiscals",
                column: "ZoneCollecteId",
                principalSchema: "taxe",
                principalTable: "ZoneCollecte",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communes_Prefectures_PrefectureId",
                schema: "taxe",
                table: "Communes",
                column: "PrefectureId",
                principalSchema: "taxe",
                principalTable: "Prefectures",
                principalColumn: "Id");

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
        }
    }
}
