using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Application.EventHandlers;
using PayCom.WebApi.Taxe.Domain.Events.CommuneEvents;
using PayCom.WebApi.Taxe.Domain.Events.EntiteAdministrativeEvents;


namespace PayCom.WebApi.Taxe.Application.Extensions;
public static class EventHandlerExtensions
{
    public static IServiceCollection AddTaxeEventHandlers(this IServiceCollection services)
    {
        // Enregistrer les handlers d'événements
        services.AddTransient<MediatR.INotificationHandler<CommuneCreated>, CommuneCreatedHandler>();
        services.AddTransient<MediatR.INotificationHandler<CommuneUpdated>, CommuneUpdatedHandler>();
        services.AddTransient<MediatR.INotificationHandler<ChefLieuChanged>, ChefLieuChangedHandler>();
        // Vous pouvez ajouter d'autres handlers d'événements ici si nécessaire
        return services;
    }
}
