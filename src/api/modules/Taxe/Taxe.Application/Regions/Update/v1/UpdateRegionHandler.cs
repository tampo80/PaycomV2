using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Regions.Update.v1;
public sealed class UpdateRegionHandler(
    [FromKeyedServices("taxe:regions")] IRepository<Region> repository,
    [FromKeyedServices("taxe:communes")] IRepository<Commune> communeRepository,
    ILogger<UpdateRegionHandler> logger)
    : IRequestHandler<UpdateRegionCommand, UpdateRegionResponse>
{
    public async Task<UpdateRegionResponse> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        // Récupérer la région existante
        var region = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = region ?? throw new RegionNotFoundException(request.Id);
        
        // Vérifier si le chef-lieu a changé
        Commune? nouveauChefLieu = null;
        string? nomChefLieu = null;
        
        if (request.ChefLieuId != region.ChefLieuId)
        {
            if (request.ChefLieuId.HasValue)
            {
                nouveauChefLieu = await communeRepository.GetByIdAsync(request.ChefLieuId.Value, cancellationToken);
                if (nouveauChefLieu == null)
                {
                    throw new ApplicationException($"La commune avec l'ID {request.ChefLieuId.Value} n'existe pas.");
                }
                nomChefLieu = nouveauChefLieu.Nom;
            }
        }
        else if (region.ChefLieuId.HasValue)
        {
            // Récupérer le nom du chef-lieu actuel si nécessaire
            var chefLieuActuel = await communeRepository.GetByIdAsync(region.ChefLieuId.Value, cancellationToken);
            nomChefLieu = chefLieuActuel?.Nom;
        }
        
        // Mettre à jour les propriétés de la région
        region.Update(
            request.Nom, 
            request.Code);
        
        // Mettre à jour le chef-lieu si nécessaire
        if (nouveauChefLieu != null || (region.ChefLieuId.HasValue && !request.ChefLieuId.HasValue))
        {
            region.DefinirChefLieu(nouveauChefLieu);
        }
        
        // Sauvegarder les changements
        await repository.UpdateAsync(region, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Région {RegionId} mise à jour avec succès", region.Id);
        
        // Retourner l'entité mise à jour
        return new UpdateRegionResponse(
            region.Id,
            region.Nom,
            region.Code,
            region.ChefLieuId,
            nomChefLieu);
    }
}
