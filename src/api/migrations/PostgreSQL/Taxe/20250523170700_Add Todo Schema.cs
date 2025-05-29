using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCom.WebApi.Migrations.PostgreSQL.Taxe
{
    /// <inheritdoc />
    public partial class AddTodoSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "taxe");

            migrationBuilder.CreateTable(
                name: "Configurations",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cle = table.Column<string>(type: "text", nullable: false),
                    Valeur = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contribuables",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "text", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Genre = table.Column<int>(type: "integer", nullable: false),
                    NumeroIdentification = table.Column<string>(type: "text", nullable: false),
                    NomCommercial = table.Column<string>(type: "text", nullable: false),
                    Adresse = table.Column<string>(type: "text", nullable: false),
                    LocalisationGPS = table.Column<string>(type: "text", nullable: false),
                    TypeActivite = table.Column<string>(type: "text", nullable: false),
                    ContactPrincipal = table.Column<string>(type: "text", nullable: false),
                    ContactSecondaire = table.Column<string>(type: "text", nullable: false),
                    DateEnregistrement = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Statut = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Echeanciers",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateEcheance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MontantDu = table.Column<double>(type: "double precision", nullable: false),
                    MontantPaye = table.Column<double>(type: "double precision", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Echeanciers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    DateEnvoi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Contenu = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paiements",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Montant = table.Column<double>(type: "double precision", nullable: false),
                    ModePaiement = table.Column<int>(type: "integer", nullable: false),
                    CodeTransaction = table.Column<string>(type: "text", nullable: false),
                    DateTransaction = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Statut = table.Column<int>(type: "integer", nullable: false),
                    FraisTransaction = table.Column<double>(type: "double precision", nullable: false),
                    InformationsSupplementaires = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prefectures",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefectures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxe",
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
                    table.PrimaryKey("PK_Taxe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeTaxe",
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
                    table.PrimaryKey("PK_TypeTaxe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDetail",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Villes",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionPaiements",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodeTransaction = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Montant = table.Column<double>(type: "double precision", nullable: false),
                    ModePaiement = table.Column<int>(type: "integer", nullable: false),
                    FournisseurPaiement = table.Column<string>(type: "text", nullable: false),
                    NumeroReference = table.Column<string>(type: "text", nullable: false),
                    Frais = table.Column<double>(type: "double precision", nullable: false),
                    Statut = table.Column<int>(type: "integer", nullable: false),
                    ReferenceBancaire = table.Column<string>(type: "text", nullable: false),
                    DonneesTechniques = table.Column<string>(type: "text", nullable: false),
                    PaiementId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionPaiements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionPaiements_Paiements_PaiementId",
                        column: x => x.PaiementId,
                        principalSchema: "taxe",
                        principalTable: "Paiements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Communes",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    LogoUrl = table.Column<string>(type: "text", nullable: false),
                    AdresseSiege = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    SiteWeb = table.Column<string>(type: "text", nullable: false),
                    EstActif = table.Column<bool>(type: "boolean", nullable: false),
                    PrefectureId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communes_Prefectures_PrefectureId",
                        column: x => x.PrefectureId,
                        principalSchema: "taxe",
                        principalTable: "Prefectures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Penalites",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateApplication = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Montant = table.Column<double>(type: "double precision", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TaxeConcerneeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penalites_Taxe_TaxeConcerneeId",
                        column: x => x.TaxeConcerneeId,
                        principalSchema: "taxe",
                        principalTable: "Taxe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UtilisateurId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_UserDetail_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalSchema: "taxe",
                        principalTable: "UserDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObligationFiscale",
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
                name: "ZoneCollecte",
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
                name: "Echeance",
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
                name: "AgentFiscals",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Identifiant = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LocalisationGPS = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DateEmbauche = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFinFonction = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Statut = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    ZoneCollecteId = table.Column<Guid>(type: "uuid", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentFiscals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentFiscals_ZoneCollecte_ZoneCollecteId",
                        column: x => x.ZoneCollecteId,
                        principalSchema: "taxe",
                        principalTable: "ZoneCollecte",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CollecteTerrainSession",
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
                name: "PaiementTerrains",
                schema: "taxe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AgentFiscalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContribuableId = table.Column<Guid>(type: "uuid", nullable: false),
                    EcheanceId = table.Column<Guid>(type: "uuid", nullable: false),
                    DatePaiement = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Montant = table.Column<double>(type: "double precision", nullable: false),
                    ModePaiement = table.Column<int>(type: "integer", nullable: false),
                    ReferenceRecue = table.Column<string>(type: "text", nullable: false),
                    NumeroQuittance = table.Column<string>(type: "text", nullable: false),
                    PhotoPreuve = table.Column<string>(type: "text", nullable: false),
                    SignatureContribuable = table.Column<string>(type: "text", nullable: false),
                    GeoLocalisation = table.Column<string>(type: "text", nullable: false),
                    EstSynchronise = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_PaiementTerrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaiementTerrains_AgentFiscals_AgentFiscalId",
                        column: x => x.AgentFiscalId,
                        principalSchema: "taxe",
                        principalTable: "AgentFiscals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaiementTerrains_Contribuables_ContribuableId",
                        column: x => x.ContribuableId,
                        principalSchema: "taxe",
                        principalTable: "Contribuables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaiementTerrains_Echeance_EcheanceId",
                        column: x => x.EcheanceId,
                        principalSchema: "taxe",
                        principalTable: "Echeance",
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
                name: "IX_AgentFiscals_ZoneCollecteId",
                schema: "taxe",
                table: "AgentFiscals",
                column: "ZoneCollecteId");

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
                name: "IX_Communes_PrefectureId",
                schema: "taxe",
                table: "Communes",
                column: "PrefectureId");

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
                name: "IX_Operations_UtilisateurId",
                schema: "taxe",
                table: "Operations",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_PaiementTerrains_AgentFiscalId",
                schema: "taxe",
                table: "PaiementTerrains",
                column: "AgentFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_PaiementTerrains_ContribuableId",
                schema: "taxe",
                table: "PaiementTerrains",
                column: "ContribuableId");

            migrationBuilder.CreateIndex(
                name: "IX_PaiementTerrains_EcheanceId",
                schema: "taxe",
                table: "PaiementTerrains",
                column: "EcheanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalites_TaxeConcerneeId",
                schema: "taxe",
                table: "Penalites",
                column: "TaxeConcerneeId");

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
                name: "IX_TransactionPaiements_PaiementId",
                schema: "taxe",
                table: "TransactionPaiements",
                column: "PaiementId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneCollecte_CommuneId",
                schema: "taxe",
                table: "ZoneCollecte",
                column: "CommuneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Echeanciers",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Operations",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "PaiementTerrains",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Penalites",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "TransactionCollecte",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "TransactionPaiements",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Villages",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Villes",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "UserDetail",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Taxe",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "CollecteTerrainSession",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Echeance",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Paiements",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "AgentFiscals",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "ObligationFiscale",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "ZoneCollecte",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Contribuables",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "TypeTaxe",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Communes",
                schema: "taxe");

            migrationBuilder.DropTable(
                name: "Prefectures",
                schema: "taxe");
        }
    }
}
