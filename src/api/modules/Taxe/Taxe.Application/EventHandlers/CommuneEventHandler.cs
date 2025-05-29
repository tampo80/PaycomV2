using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events.CommuneEvents;

namespace PayCom.WebApi.Taxe.Application.EventHandlers;
public class CommuneCreatedHandler : INotificationHandler<CommuneCreated>
{
    private readonly ILogger<CommuneCreatedHandler> _logger;
    private readonly IRepository<Region> _regionRepository;
    public CommuneCreatedHandler(
        ILogger<CommuneCreatedHandler> logger,
        [FromKeyedServices("taxe:regions")] IRepository<Region> regionRepository)
    {
        _logger = logger;
        _regionRepository = regionRepository;
    }
    
    public async Task Handle(CommuneCreated notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Commune créée: {CommuneId} - {CommuneNom} dans la région {RegionId}",
            notification.Id, notification.Nom, notification.RegionId);
        // Mettre à jour les statistiques ou effectuer d'autres actions suite à la création d'une commune
        var region = await _regionRepository.GetByIdAsync(notification.RegionId, cancellationToken);
        if (region != null)
        {
            _logger.LogInformation("La région {RegionNom} a maintenant une nouvelle commune", region.Nom);
            // Ici, on pourrait mettre à jour des statistiques ou envoyer des notifications
        }
    }
}

public class CommuneUpdatedHandler : INotificationHandler<CommuneUpdated>
{
    private readonly ILogger<CommuneUpdatedHandler> _logger;
    
    public CommuneUpdatedHandler(ILogger<CommuneUpdatedHandler> logger)
    {
        _logger = logger;
    }
    
    public async Task Handle(CommuneUpdated notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Commune mise à jour: {CommuneId} - {CommuneNom} dans la région {RegionId}",
            notification.Id, notification.Nom, notification.RegionId);
        // Mettre à jour les statistiques ou effectuer d'autres actions suite à la mise à jour d'une commune
        _logger.LogInformation("La commune {CommuneNom} a été mise à jour", notification.Nom);
    }
}
