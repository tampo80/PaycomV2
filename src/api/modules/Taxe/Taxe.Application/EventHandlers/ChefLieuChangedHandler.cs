using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events.EntiteAdministrativeEvents;

namespace PayCom.WebApi.Taxe.Application.EventHandlers;
public class ChefLieuChangedHandler : INotificationHandler<ChefLieuChanged>
{
    private readonly ILogger<ChefLieuChangedHandler> _logger;
    private readonly IRepository<Commune> _communeRepository;
    private readonly IRepository<Region> _regionRepository;
    public ChefLieuChangedHandler(
        ILogger<ChefLieuChangedHandler> logger,
        [FromKeyedServices("taxe:communes")] IRepository<Commune> communeRepository,
        [FromKeyedServices("taxe:regions")] IRepository<Region> regionRepository)
    {
        _logger = logger;
        _communeRepository = communeRepository;
        _regionRepository = regionRepository;
    }
    public async Task Handle(ChefLieuChanged notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Chef-lieu changé pour {TypeEntite} {EntiteId}: ancien chef-lieu {AncienChefLieuId}, nouveau chef-lieu {NouveauChefLieuId}",
            notification.TypeEntite, notification.EntiteId, notification.AncienChefLieuId, notification.NouveauChefLieuId);
        // Selon le type d'entité, effectuer des actions spécifiques
        switch (notification.TypeEntite)
        {
            case "Region":
                await HandleRegionChefLieuChanged(notification, cancellationToken);
                break;
            default:
                _logger.LogWarning("Type d'entité non reconnu: {TypeEntite}", notification.TypeEntite);
                break;
        }
    }
    
    private async Task HandleRegionChefLieuChanged(ChefLieuChanged notification, CancellationToken cancellationToken)
    {
        // Mettre à jour les statistiques ou envoyer des notifications pour le changement de chef-lieu de région
        if (notification.NouveauChefLieuId.HasValue)
        {
            var commune = await _communeRepository.GetByIdAsync(notification.NouveauChefLieuId.Value, cancellationToken);
            if (commune != null)
            {
                _logger.LogInformation("La commune {CommuneNom} est maintenant chef-lieu de région", commune.Nom);
                // Ici, on pourrait mettre à jour des statistiques ou envoyer des notifications
            }
        }
    }
}
