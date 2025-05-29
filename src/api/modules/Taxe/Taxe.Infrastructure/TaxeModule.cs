using Carter;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Application.Extensions;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;
using PayCom.WebApi.Taxe.Infrastructure.Persistence;

namespace PayCom.WebApi.Taxe.Infrastructure;

public static class TaxeModuleExtensions
{
    public static WebApplicationBuilder RegisterTaxeServices(this WebApplicationBuilder builder)
    {
        // Enregistrez ici les services spécifiques au module Taxe
        builder.Services.AddTaxeModule();
        builder.Services.AddTaxeEventHandlers();
        return builder;
    }

    public static WebApplication UseTaxeModule(this WebApplication app)
    {
        // Configurez ici les middlewares spécifiques au module Taxe
        return app;
    }
}

public static class TaxeModule
{
    public class Endpoints : CarterModule
    {
        public Endpoints() : base("taxe") { }
        
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
           var agentFiscalGroup = app.MapGroup("agent-fiscals").WithTags("agent-fiscals");
           agentFiscalGroup.MapAgentFiscalCreationEndpoint();
           agentFiscalGroup.MapAgentFiscalGetEndpoint();
           agentFiscalGroup.MapAgentFiscalUpdateEndpoint();
           agentFiscalGroup.MapAgentFiscalDeleteEndpoint();
           agentFiscalGroup.MapAgentFiscalSearchEndpoint();
           agentFiscalGroup.MapAssocierUtilisateurAgentEndpoint();

           var communeGroup = app.MapGroup("communes").WithTags("communes");
           communeGroup.MapCommuneCreationEndpoint();
           communeGroup.MapCommuneGetEndpoint();
           communeGroup.MapCommuneSearchEndpoint();
           communeGroup.MapCommuneUpdateEndpoint();
           communeGroup.MapCommuneDeleteEndpoint();

           var contribuablesGroup = app.MapGroup("contribuables").WithTags("contribuables");
           contribuablesGroup.MapContribuableCreationEndpoint();
           contribuablesGroup.MapContribuableGetEndpoint();
           contribuablesGroup.MapContribuableSearchEndpoint();
           contribuablesGroup.MapContribuableUpdateEndpoint();
           contribuablesGroup.MapContribuableDeleteEndpoint();
           contribuablesGroup.MapAssocierUtilisateurContribuableEndpoint();
           contribuablesGroup.MapAssocierAgentFiscalContribuableEndpoint();
           
           var penaliteGroup = app.MapGroup("penalites").WithTags("penalites");
           penaliteGroup.MapPenaliteCreationEndpoint();
           penaliteGroup.MapPenaliteGetEndpoint();
           penaliteGroup.MapPenaliteSearchEndpoint();
           penaliteGroup.MapPenaliteUpdateEndpoint();
           penaliteGroup.MapPenaliteDeleteEndpoint();
           
           var paiementGroup = app.MapGroup("paiements").WithTags("paiements");
           paiementGroup.MapPaiementCreationEndpoint();
           paiementGroup.MapPaiementGetEndpoint();
           paiementGroup.MapPaiementSearchEndpoint();
           paiementGroup.MapPaiementUpdateEndpoint();
           paiementGroup.MapPaiementDeleteEndpoint();
           
           var notificationGroup = app.MapGroup("notifications").WithTags("notifications");
           notificationGroup.MapNotificationCreationEndpoint();
           notificationGroup.MapNotificationDeleteEndpoint();
           notificationGroup.MapNotificationGetEndpoint();
           notificationGroup.MapNotificationSearchEndpoint();
           notificationGroup.MapNotificationUpdateEndpoint();
           notificationGroup.MapMarquerCommeLueEndpoint();
           
           var operationGroup = app.MapGroup("operations").WithTags("operations");
           operationGroup.MapOperationCreationEndpoint();
           operationGroup.MapOperationGetEndpoint();
           operationGroup.MapOperationSearchEndpoint();
           operationGroup.MapOperationUpdateEndpoint();
           operationGroup.MapOperationDeleteEndpoint();
           
           var regionGroup = app.MapGroup("regions").WithTags("regions");
           regionGroup.MapRegionCreationEndpoint();
           regionGroup.MapRegionGetEndpoint();
           regionGroup.MapRegionSearchEndpoint();
           regionGroup.MapRegionUpdateEndpoint();
           regionGroup.MapRegionDeleteEndpoint();
           
           var taxeGroup = app.MapGroup("taxes").WithTags("taxes");
           taxeGroup.MapTaxeCreationEndpoint();
           taxeGroup.MapTaxeGetEndpoint();
           taxeGroup.MapTaxeSearchEndpoint();
           taxeGroup.MapTaxeUpdateEndpoint();
           taxeGroup.MapTaxeDeleteEndpoint();
           
           var typeTaxeGroup = app.MapGroup("type-taxes").WithTags("type-taxes");
           typeTaxeGroup.MapTypeTaxeCreationEndpoint();
           typeTaxeGroup.MapTypeTaxeGetEndpoint();
           typeTaxeGroup.MapTypeTaxeSearchEndpoint();
           typeTaxeGroup.MapTypeTaxeUpdateEndpoint();
           typeTaxeGroup.MapTypeTaxeDeleteEndpoint();
           
           var obligationFiscaleGroup = app.MapGroup("obligations-fiscales").WithTags("obligations-fiscales");
           obligationFiscaleGroup.MapObligationFiscaleCreationEndpoint();
           obligationFiscaleGroup.MapObligationFiscaleGetEndpoint();
           obligationFiscaleGroup.MapObligationFiscaleSearchEndpoint();
           obligationFiscaleGroup.MapObligationFiscaleUpdateEndpoint();
           obligationFiscaleGroup.MapObligationFiscaleDeleteEndpoint();
           
           var collecteTerrainSessionGroup = app.MapGroup("collecte-sessions").WithTags("collecte-sessions");
           collecteTerrainSessionGroup.MapCollecteTerrainSessionCreationEndpoint();
           collecteTerrainSessionGroup.MapCollecteTerrainSessionGetEndpoint();
           collecteTerrainSessionGroup.MapCollecteTerrainSessionSearchEndpoint();
           collecteTerrainSessionGroup.MapCollecteTerrainSessionUpdateEndpoint();
           collecteTerrainSessionGroup.MapCollecteTerrainSessionDeleteEndpoint();
           collecteTerrainSessionGroup.MapCloturerSessionEndpoint();
        }
    }

    public static IServiceCollection AddTaxeModule(this IServiceCollection services)
    {
        services.BindDbContext<TaxeDbContext>();
        services.AddScoped<IDbInitializer, TaxeDbInitializer>();
        
        // Enregistrements avec les clés correctes pour les repositories
        services.AddKeyedScoped<IRepository<AgentFiscal>, TaxeRepository<AgentFiscal>>("taxe:agentfiscals");
        services.AddKeyedScoped<IReadRepository<AgentFiscal>, TaxeRepository<AgentFiscal>>("taxe:agentfiscals");
        
        services.AddKeyedScoped<IRepository<Commune>, TaxeRepository<Commune>>("taxe:communes");
        services.AddKeyedScoped<IReadRepository<Commune>, TaxeRepository<Commune>>("taxe:communes");
        
      
        services.AddKeyedScoped<IRepository<Contribuable>, TaxeRepository<Contribuable>>("taxe:contribuables");
        services.AddKeyedScoped<IReadRepository<Contribuable>, TaxeRepository<Contribuable>>("taxe:contribuables");
        
        services.AddKeyedScoped<IRepository<Echeancier>, TaxeRepository<Echeancier>>("taxe:echeanciers");
        services.AddKeyedScoped<IReadRepository<Echeancier>, TaxeRepository<Echeancier>>("taxe:echeanciers");
        
        services.AddKeyedScoped<IRepository<Penalite>, TaxeRepository<Penalite>>("taxe:penalites");
        services.AddKeyedScoped<IReadRepository<Penalite>, TaxeRepository<Penalite>>("taxe:penalites");
        
        services.AddKeyedScoped<IRepository<Paiement>, TaxeRepository<Paiement>>("taxe:paiements");
        services.AddKeyedScoped<IReadRepository<Paiement>, TaxeRepository<Paiement>>("taxe:paiements");
        
        services.AddKeyedScoped<IRepository<Operation>, TaxeRepository<Operation>>("taxe:operations");
        services.AddKeyedScoped<IReadRepository<Operation>, TaxeRepository<Operation>>("taxe:operations");
        
        services.AddKeyedScoped<IRepository<Notification>, TaxeRepository<Notification>>("taxe:notifications");
        services.AddKeyedScoped<IReadRepository<Notification>, TaxeRepository<Notification>>("taxe:notifications");
        
        // Utilisation de Domain.Taxe au lieu de LaTaxe
        services.AddKeyedScoped<IRepository<Domain.Taxe>, TaxeRepository<Domain.Taxe>>("taxe:taxes");
        services.AddKeyedScoped<IReadRepository<Domain.Taxe>, TaxeRepository<Domain.Taxe>>("taxe:taxes");
        
        services.AddKeyedScoped<IRepository<Configuration>, TaxeRepository<Configuration>>("taxe:configurations");
        services.AddKeyedScoped<IReadRepository<Configuration>, TaxeRepository<Configuration>>("taxe:configurations");
        
        // Ajout des repositories manquants avec leurs clés correctes
        services.AddKeyedScoped<IRepository<Village>, TaxeRepository<Village>>("taxe:villages");
        services.AddKeyedScoped<IReadRepository<Village>, TaxeRepository<Village>>("taxe:villages");
        
        services.AddKeyedScoped<IRepository<ObligationFiscale>, TaxeRepository<ObligationFiscale>>("taxe:obligations-fiscales");
        services.AddKeyedScoped<IReadRepository<ObligationFiscale>, TaxeRepository<ObligationFiscale>>("taxe:obligations-fiscales");
        
        services.AddKeyedScoped<IRepository<CollecteTerrainSession>, TaxeRepository<CollecteTerrainSession>>("taxe:collecte-sessions");
        services.AddKeyedScoped<IReadRepository<CollecteTerrainSession>, TaxeRepository<CollecteTerrainSession>>("taxe:collecte-sessions");
        
        services.AddKeyedScoped<IRepository<TransactionCollecte>, TaxeRepository<TransactionCollecte>>("taxe:transactioncollectes");
        services.AddKeyedScoped<IReadRepository<TransactionCollecte>, TaxeRepository<TransactionCollecte>>("taxe:transactioncollectes");
        
        services.AddKeyedScoped<IRepository<TypeTaxe>, TaxeRepository<TypeTaxe>>("taxe:types-taxe");
        services.AddKeyedScoped<IReadRepository<TypeTaxe>, TaxeRepository<TypeTaxe>>("taxe:types-taxe");
        
        // Ajout des services manquants
        services.AddKeyedScoped<IRepository<Region>, TaxeRepository<Region>>("taxe:regions");
        services.AddKeyedScoped<IReadRepository<Region>, TaxeRepository<Region>>("taxe:regions");
        
        services.AddKeyedScoped<IRepository<Prefecture>, TaxeRepository<Prefecture>>("taxe:prefectures");
        services.AddKeyedScoped<IReadRepository<Prefecture>, TaxeRepository<Prefecture>>("taxe:prefectures");
        
        services.AddKeyedScoped<IRepository<Echeance>, TaxeRepository<Echeance>>("taxe:echeances");
        services.AddKeyedScoped<IReadRepository<Echeance>, TaxeRepository<Echeance>>("taxe:echeances");
        
        services.AddKeyedScoped<IRepository<TransactionPaiement>, TaxeRepository<TransactionPaiement>>("taxe:transaction-paiements");
        services.AddKeyedScoped<IReadRepository<TransactionPaiement>, TaxeRepository<TransactionPaiement>>("taxe:transaction-paiements");
        
        return services;
    }
}
