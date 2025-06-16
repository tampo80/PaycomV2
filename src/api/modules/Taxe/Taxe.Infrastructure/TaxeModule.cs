using Carter;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;
using PayCom.WebApi.Taxe.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Application.Extensions;

namespace PayCom.WebApi.Taxe.Infrastructure;

public static class TaxeModule
{
    public class Endpoints : CarterModule
    {
        public Endpoints() : base("taxe") { }
        
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            // Groupes d'endpoints par fonctionnalité
            MapAgentFiscalEndpoints(app);
            MapCommuneEndpoints(app);
            MapZoneCollecteEndpoints(app);
            MapContribuableEndpoints(app);
            MapPenaliteEndpoints(app);
            MapPaiementEndpoints(app);
            MapNotificationEndpoints(app);
            MapOperationEndpoints(app);
            MapRegionEndpoints(app);
            MapTaxeEndpoints(app);
            MapTypeTaxeEndpoints(app);
            MapObligationFiscaleEndpoints(app);
            MapCollecteTerrainSessionEndpoints(app);
            MapTransactionCollecteEndpoints(app);
        }

        private static void MapAgentFiscalEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("agent-fiscals").WithTags("agent-fiscals");
            group.MapAgentFiscalCreationEndpoint();
            group.MapAgentFiscalGetEndpoint();
            group.MapAgentFiscalUpdateEndpoint();
            group.MapAgentFiscalDeleteEndpoint();
            group.MapAgentFiscalSearchEndpoint();
            group.MapAssocierUtilisateurAgentEndpoint();
            group.MapAgentFiscalGetByUserIdEndpoint();
        }

        private static void MapCommuneEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("communes").WithTags("communes");
            group.MapCommuneCreationEndpoint();
            group.MapCommuneGetEndpoint();
            group.MapCommuneGetAllEndpoint();
            group.MapCommuneSearchEndpoint();
            group.MapCommuneUpdateEndpoint();
            group.MapCommuneDeleteEndpoint();
        }

        private static void MapZoneCollecteEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("zones-collecte").WithTags("zones-collecte");
            group.MapZoneCollecteCreationEndpoint();
            group.MapZoneCollecteGetEndpoint();
            group.MapZoneCollecteSearchEndpoint();
            group.MapZoneCollecteUpdateEndpoint();
            group.MapZoneCollecteDeleteEndpoint();
            group.MapZoneCollecteGetByCommuneIdEndpoint();
        }

        private static void MapContribuableEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("contribuables").WithTags("contribuables");
            group.MapContribuableCreationEndpoint();
            group.MapContribuableGetEndpoint();
            group.MapContribuableSearchEndpoint();
            group.MapContribuableUpdateEndpoint();
            group.MapContribuableDeleteEndpoint();
            group.MapAssocierUtilisateurContribuableEndpoint();
            group.MapAssocierAgentFiscalContribuableEndpoint();
            group.MapContribuableGetByUserIdEndpoint();
        }

        private static void MapPenaliteEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("penalites").WithTags("penalites");
            group.MapPenaliteCreationEndpoint();
            group.MapPenaliteGetEndpoint();
            group.MapPenaliteSearchEndpoint();
            group.MapPenaliteUpdateEndpoint();
            group.MapPenaliteDeleteEndpoint();
        }

        private static void MapPaiementEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("paiements").WithTags("paiements");
            group.MapPaiementCreationEndpoint();
            group.MapPaiementGetEndpoint();
            group.MapPaiementSearchEndpoint();
            group.MapPaiementUpdateEndpoint();
            group.MapPaiementDeleteEndpoint();
        }

        private static void MapNotificationEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("notifications").WithTags("notifications");
            group.MapNotificationCreationEndpoint();
            group.MapNotificationDeleteEndpoint();
            group.MapNotificationGetEndpoint();
            group.MapNotificationSearchEndpoint();
            group.MapNotificationUpdateEndpoint();
            group.MapMarquerCommeLueEndpoint();
        }

        private static void MapOperationEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("operations").WithTags("operations");
            group.MapOperationCreationEndpoint();
            group.MapOperationGetEndpoint();
            group.MapOperationSearchEndpoint();
            group.MapOperationUpdateEndpoint();
            group.MapOperationDeleteEndpoint();
        }

        private static void MapRegionEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("regions").WithTags("regions");
            group.MapRegionCreationEndpoint();
            group.MapRegionGetEndpoint();
            group.MapRegionSearchEndpoint();
            group.MapRegionUpdateEndpoint();
            group.MapRegionDeleteEndpoint();
        }

        private static void MapTaxeEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("taxes").WithTags("taxes");
            group.MapTaxeCreationEndpoint();
            group.MapTaxeGetEndpoint();
            group.MapTaxeSearchEndpoint();
            group.MapTaxeUpdateEndpoint();
            group.MapTaxeDeleteEndpoint();
        }

        private static void MapTypeTaxeEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("type-taxes").WithTags("type-taxes");
            group.MapTypeTaxeCreationEndpoint();
            group.MapTypeTaxeGetEndpoint();
            group.MapTypeTaxeSearchEndpoint();
            group.MapTypeTaxeUpdateEndpoint();
            group.MapTypeTaxeDeleteEndpoint();
        }

        private static void MapObligationFiscaleEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("obligations-fiscales").WithTags("obligations-fiscales");
            group.MapObligationFiscaleCreationEndpoint();
            group.MapObligationFiscaleGetEndpoint();
            group.MapObligationFiscaleSearchEndpoint();
            group.MapObligationFiscaleUpdateEndpoint();
            group.MapObligationFiscaleDeleteEndpoint();
            group.MapDesactiverObligationFiscaleEndpoint();
            group.MapReactiverObligationFiscaleEndpoint();
            group.MapGenererEcheancesEndpoint();
        }

        private static void MapCollecteTerrainSessionEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("collecte-sessions").WithTags("collecte-sessions");
            group.MapCollecteTerrainSessionCreationEndpoint();
            group.MapCollecteTerrainSessionGetEndpoint();
            group.MapCollecteTerrainSessionSearchEndpoint();
            group.MapCollecteTerrainSessionUpdateEndpoint();
            group.MapCollecteTerrainSessionDeleteEndpoint();
            group.MapCloturerSessionEndpoint();
            group.MapCloseSessionEndpoint();
        }

        private static void MapTransactionCollecteEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("transactions").WithTags("transactions");
            group.MapTransactionCollecteCreationEndpoint();
            group.MapTransactionCollecteGetEndpoint();
            group.MapTransactionCollecteSearchEndpoint();
            group.MapTransactionCollecteUpdateEndpoint();
            group.MapTransactionCollecteDeleteEndpoint();
            group.MapSynchroniserTransactionEndpoint();
            group.MapGetPaiementsBySessionIdEndpoint();
            group.MapGetStatistiquesBySessionIdEndpoint();
            group.MapGetCurrentLocationEndpoint();
            group.MapGenerateReceiptEndpoint();
            group.MapCreatePaiementEndpoint();
        }
    }
    
    public static WebApplicationBuilder RegisterTaxeServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        
        // Configuration de la base de données
        builder.Services.BindDbContext<TaxeDbContext>();
        builder.Services.AddScoped<IDbInitializer, TaxeDbInitializer>();
        
        // Enregistrement des repositories
        RegisterRepositories(builder.Services);
        
        // Ajout des handlers d'événements
        builder.Services.AddTaxeEventHandlers();

        // Configuration de MediatR
        builder.Services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(TaxeModule).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(TransactionCollecte).Assembly);
        });
        
        return builder;
    }
    
    private static void RegisterRepositories(IServiceCollection services)
    {
        // Enregistrement des repositories sans clé
        RegisterRepositoriesWithoutKey(services);
        
        // Enregistrement des repositories avec clé
        RegisterRepositoriesWithKey(services);
    }
    
    private static void RegisterRepositoriesWithoutKey(IServiceCollection services)
    {
        services.AddScoped<IRepository<Region>, TaxeRepository<Region>>();
        services.AddScoped<IReadRepository<Region>, TaxeRepository<Region>>();
        
        services.AddScoped<IRepository<Prefecture>, TaxeRepository<Prefecture>>();
        services.AddScoped<IReadRepository<Prefecture>, TaxeRepository<Prefecture>>();
        
        services.AddScoped<IRepository<Ville>, TaxeRepository<Ville>>();
        services.AddScoped<IReadRepository<Ville>, TaxeRepository<Ville>>();
        
        services.AddScoped<IRepository<Village>, TaxeRepository<Village>>();
        services.AddScoped<IReadRepository<Village>, TaxeRepository<Village>>();
        
        services.AddScoped<IRepository<TypeTaxe>, TaxeRepository<TypeTaxe>>();
        services.AddScoped<IReadRepository<TypeTaxe>, TaxeRepository<TypeTaxe>>();
        
        services.AddScoped<IRepository<Domain.Taxe>, TaxeRepository<Domain.Taxe>>();
        services.AddScoped<IReadRepository<Domain.Taxe>, TaxeRepository<Domain.Taxe>>();
        
        services.AddScoped<IRepository<Contribuable>, TaxeRepository<Contribuable>>();
        services.AddScoped<IReadRepository<Contribuable>, TaxeRepository<Contribuable>>();
        
        services.AddScoped<IRepository<ObligationFiscale>, TaxeRepository<ObligationFiscale>>();
        services.AddScoped<IReadRepository<ObligationFiscale>, TaxeRepository<ObligationFiscale>>();
        
        services.AddScoped<IRepository<Echeance>, TaxeRepository<Echeance>>();
        services.AddScoped<IReadRepository<Echeance>, TaxeRepository<Echeance>>();
        
        services.AddScoped<IRepository<Paiement>, TaxeRepository<Paiement>>();
        services.AddScoped<IReadRepository<Paiement>, TaxeRepository<Paiement>>();
        
        services.AddScoped<IRepository<Commune>, TaxeRepository<Commune>>();
        services.AddScoped<IReadRepository<Commune>, TaxeRepository<Commune>>();
        
        services.AddScoped<IRepository<AgentFiscal>, TaxeRepository<AgentFiscal>>();
        services.AddScoped<IReadRepository<AgentFiscal>, TaxeRepository<AgentFiscal>>();
        
        services.AddScoped<IRepository<ZoneCollecte>, TaxeRepository<ZoneCollecte>>();
        services.AddScoped<IReadRepository<ZoneCollecte>, TaxeRepository<ZoneCollecte>>();
        
        services.AddScoped<IRepository<CollecteTerrainSession>, TaxeRepository<CollecteTerrainSession>>();
        services.AddScoped<IReadRepository<CollecteTerrainSession>, TaxeRepository<CollecteTerrainSession>>();
        
        services.AddScoped<IRepository<TransactionCollecte>, TaxeRepository<TransactionCollecte>>();
        services.AddScoped<IReadRepository<TransactionCollecte>, TaxeRepository<TransactionCollecte>>();
        
        services.AddScoped<IRepository<TransactionPaiement>, TaxeRepository<TransactionPaiement>>();
        services.AddScoped<IReadRepository<TransactionPaiement>, TaxeRepository<TransactionPaiement>>();
        
        services.AddScoped<IRepository<Penalite>, TaxeRepository<Penalite>>();
        services.AddScoped<IReadRepository<Penalite>, TaxeRepository<Penalite>>();
        
        services.AddScoped<IRepository<Operation>, TaxeRepository<Operation>>();
        services.AddScoped<IReadRepository<Operation>, TaxeRepository<Operation>>();
        
        services.AddScoped<IRepository<Notification>, TaxeRepository<Notification>>();
        services.AddScoped<IReadRepository<Notification>, TaxeRepository<Notification>>();
        
        services.AddScoped<IRepository<Echeancier>, TaxeRepository<Echeancier>>();
        services.AddScoped<IReadRepository<Echeancier>, TaxeRepository<Echeancier>>();
        
        services.AddScoped<IRepository<Configuration>, TaxeRepository<Configuration>>();
        services.AddScoped<IReadRepository<Configuration>, TaxeRepository<Configuration>>();
    }
    
    private static void RegisterRepositoriesWithKey(IServiceCollection services)
    {
        // Region
        services.AddKeyedScoped<IRepository<Region>, TaxeRepository<Region>>("taxe:regions");
        services.AddKeyedScoped<IReadRepository<Region>, TaxeRepository<Region>>("taxe:regions");
        
        // Prefecture
        services.AddKeyedScoped<IRepository<Prefecture>, TaxeRepository<Prefecture>>("taxe:prefectures");
        services.AddKeyedScoped<IReadRepository<Prefecture>, TaxeRepository<Prefecture>>("taxe:prefectures");
        
        // Ville
        services.AddKeyedScoped<IRepository<Ville>, TaxeRepository<Ville>>("taxe:villes");
        services.AddKeyedScoped<IReadRepository<Ville>, TaxeRepository<Ville>>("taxe:villes");
        
        // Village
        services.AddKeyedScoped<IRepository<Village>, TaxeRepository<Village>>("taxe:villages");
        services.AddKeyedScoped<IReadRepository<Village>, TaxeRepository<Village>>("taxe:villages");
        
        // TypeTaxe - différentes versions de clés possibles
        services.AddKeyedScoped<IRepository<TypeTaxe>, TaxeRepository<TypeTaxe>>("taxe:type-taxes");
        services.AddKeyedScoped<IReadRepository<TypeTaxe>, TaxeRepository<TypeTaxe>>("taxe:type-taxes");
        services.AddKeyedScoped<IRepository<TypeTaxe>, TaxeRepository<TypeTaxe>>("taxe:types-taxe");
        services.AddKeyedScoped<IReadRepository<TypeTaxe>, TaxeRepository<TypeTaxe>>("taxe:types-taxe");
        
        // Taxe
        services.AddKeyedScoped<IRepository<Domain.Taxe>, TaxeRepository<Domain.Taxe>>("taxe:taxes");
        services.AddKeyedScoped<IReadRepository<Domain.Taxe>, TaxeRepository<Domain.Taxe>>("taxe:taxes");
        
        // Contribuable
        services.AddKeyedScoped<IRepository<Contribuable>, TaxeRepository<Contribuable>>("taxe:contribuables");
        services.AddKeyedScoped<IReadRepository<Contribuable>, TaxeRepository<Contribuable>>("taxe:contribuables");
        
        // ObligationFiscale - différentes versions de clés possibles
        services.AddKeyedScoped<IRepository<ObligationFiscale>, TaxeRepository<ObligationFiscale>>("taxe:obligations-fiscales");
        services.AddKeyedScoped<IReadRepository<ObligationFiscale>, TaxeRepository<ObligationFiscale>>("taxe:obligations-fiscales");
        services.AddKeyedScoped<IRepository<ObligationFiscale>, TaxeRepository<ObligationFiscale>>("taxe:obligations");
        services.AddKeyedScoped<IReadRepository<ObligationFiscale>, TaxeRepository<ObligationFiscale>>("taxe:obligations");
        
        // Echeance
        services.AddKeyedScoped<IRepository<Echeance>, TaxeRepository<Echeance>>("taxe:echeances");
        services.AddKeyedScoped<IReadRepository<Echeance>, TaxeRepository<Echeance>>("taxe:echeances");
        
        // Paiement
        services.AddKeyedScoped<IRepository<Paiement>, TaxeRepository<Paiement>>("taxe:paiements");
        services.AddKeyedScoped<IReadRepository<Paiement>, TaxeRepository<Paiement>>("taxe:paiements");
        
        // Commune
        services.AddKeyedScoped<IRepository<Commune>, TaxeRepository<Commune>>("taxe:communes");
        services.AddKeyedScoped<IReadRepository<Commune>, TaxeRepository<Commune>>("taxe:communes");
        
        // AgentFiscal - différentes versions de clés possibles
        services.AddKeyedScoped<IRepository<AgentFiscal>, TaxeRepository<AgentFiscal>>("taxe:agents");
        services.AddKeyedScoped<IReadRepository<AgentFiscal>, TaxeRepository<AgentFiscal>>("taxe:agents");
        services.AddKeyedScoped<IRepository<AgentFiscal>, TaxeRepository<AgentFiscal>>("taxe:agent-fiscals");
        services.AddKeyedScoped<IReadRepository<AgentFiscal>, TaxeRepository<AgentFiscal>>("taxe:agent-fiscals");
        services.AddKeyedScoped<IRepository<AgentFiscal>, TaxeRepository<AgentFiscal>>("taxe:agentfiscals");
        services.AddKeyedScoped<IReadRepository<AgentFiscal>, TaxeRepository<AgentFiscal>>("taxe:agentfiscals");
        
        // ZoneCollecte - différentes versions de clés possibles
        services.AddKeyedScoped<IRepository<ZoneCollecte>, TaxeRepository<ZoneCollecte>>("taxe:zones-collecte");
        services.AddKeyedScoped<IReadRepository<ZoneCollecte>, TaxeRepository<ZoneCollecte>>("taxe:zones-collecte");
        services.AddKeyedScoped<IRepository<ZoneCollecte>, TaxeRepository<ZoneCollecte>>("taxe:zones");
        services.AddKeyedScoped<IReadRepository<ZoneCollecte>, TaxeRepository<ZoneCollecte>>("taxe:zones");
        
        // CollecteTerrainSession - différentes versions de clés possibles
        services.AddKeyedScoped<IRepository<CollecteTerrainSession>, TaxeRepository<CollecteTerrainSession>>("taxe:collecte-sessions");
        services.AddKeyedScoped<IReadRepository<CollecteTerrainSession>, TaxeRepository<CollecteTerrainSession>>("taxe:collecte-sessions");
        services.AddKeyedScoped<IRepository<CollecteTerrainSession>, TaxeRepository<CollecteTerrainSession>>("taxe:sessions");
        services.AddKeyedScoped<IReadRepository<CollecteTerrainSession>, TaxeRepository<CollecteTerrainSession>>("taxe:sessions");
        
        // TransactionCollecte
        services.AddKeyedScoped<IRepository<TransactionCollecte>, TaxeRepository<TransactionCollecte>>("taxe:transactions-collecte");
        services.AddKeyedScoped<IReadRepository<TransactionCollecte>, TaxeRepository<TransactionCollecte>>("taxe:transactions-collecte");
        services.AddKeyedScoped<IRepository<TransactionCollecte>, TaxeRepository<TransactionCollecte>>("taxe:transactions");
        services.AddKeyedScoped<IReadRepository<TransactionCollecte>, TaxeRepository<TransactionCollecte>>("taxe:transactions");
        
        // TransactionPaiement
        services.AddKeyedScoped<IRepository<TransactionPaiement>, TaxeRepository<TransactionPaiement>>("taxe:transaction-paiements");
        services.AddKeyedScoped<IReadRepository<TransactionPaiement>, TaxeRepository<TransactionPaiement>>("taxe:transaction-paiements");
        
        // Penalite
        services.AddKeyedScoped<IRepository<Penalite>, TaxeRepository<Penalite>>("taxe:penalites");
        services.AddKeyedScoped<IReadRepository<Penalite>, TaxeRepository<Penalite>>("taxe:penalites");
        
        // Operation
        services.AddKeyedScoped<IRepository<Operation>, TaxeRepository<Operation>>("taxe:operations");
        services.AddKeyedScoped<IReadRepository<Operation>, TaxeRepository<Operation>>("taxe:operations");
        
        // Notification
        services.AddKeyedScoped<IRepository<Notification>, TaxeRepository<Notification>>("taxe:notifications");
        services.AddKeyedScoped<IReadRepository<Notification>, TaxeRepository<Notification>>("taxe:notifications");
        
        // Echeancier
        services.AddKeyedScoped<IRepository<Echeancier>, TaxeRepository<Echeancier>>("taxe:echeanciers");
        services.AddKeyedScoped<IReadRepository<Echeancier>, TaxeRepository<Echeancier>>("taxe:echeanciers");
        
        // Configuration
        services.AddKeyedScoped<IRepository<Configuration>, TaxeRepository<Configuration>>("taxe:configurations");
        services.AddKeyedScoped<IReadRepository<Configuration>, TaxeRepository<Configuration>>("taxe:configurations");
    }
    
    public static WebApplication UseTaxeModule(this WebApplication app)
    {
        return app;
    }

   

   
}
