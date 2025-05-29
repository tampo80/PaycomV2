using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;


namespace PayCom.WebApi.Taxe.Application.Communes.Update.v1;
public sealed class UpdateCommuneHandler(
    ILogger<UpdateCommuneHandler> logger,
    [FromKeyedServices("taxe:communes")] IRepository<Commune> repository,
    [FromKeyedServices("taxe:regions")] IRepository<Region> regionRepository) 
    : IRequestHandler<UpdateCommuneCommand, UpdateCommuneResponse>
{
    public async Task<UpdateCommuneResponse> Handle(UpdateCommuneCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        // Récupérer la commune existante
        var commune = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = commune ?? throw new CommuneNotFoundException(request.Id);
        
        // Récupérer l'ancienne région
        Region? ancienneRegion = null;
        if (commune.RegionId != Guid.Empty)
        {
            ancienneRegion = await regionRepository.GetByIdAsync(commune.RegionId, cancellationToken);
        }
        
        // Vérifier si la région existe si elle a changé
        Region? nouvelleRegion = null;
        if (commune.RegionId != request.RegionId)
        {
            nouvelleRegion = await regionRepository.GetByIdAsync(request.RegionId, cancellationToken);
            if (nouvelleRegion == null)
            {
                throw new ApplicationException($"La région avec l'ID {request.RegionId} n'existe pas.");
            }
        }
        else if (request.RegionId != Guid.Empty)
        {
            // Utiliser l'ancienne région si elle n'a pas changé
            nouvelleRegion = ancienneRegion;
        }
        
        // Mettre à jour la commune
        var updatedCommune = commune.Update(
            request.Nom,
            request.Type,
            request.Code,
            request.NombreSecteurs,
            request.NombreArrondissements,
            request.LogoUrl,
            request.AdresseSiege,
            request.Contact,
            request.Email,
            request.SiteWeb,
            request.RegionId,
            request.CodeTenant,
            request.NomCentreAdmin,
            request.AdresseCentreAdmin,
            request.ContactCentreAdmin,
            request.EmailCentreAdmin,
            request.ResponsableCentreAdmin
        );
        
        // Mettre à jour le type de chef-lieu si nécessaire
        updatedCommune.DefinirTypeChefLieu(request.TypeChefLieu);
        
        // Gérer les changements de région si nécessaire
        await GererChangementRegion(
            ancienneRegion, 
            nouvelleRegion,
            updatedCommune, 
            cancellationToken);
        
        // Persister les changements
        await repository.UpdateAsync(updatedCommune, cancellationToken);
        logger.LogInformation("Commune avec l'id: {CommuneId} mise à jour", updatedCommune.Id);
        return new UpdateCommuneResponse(updatedCommune.Id);
    }
    
    private async Task GererChangementRegion(
        Region? ancienneRegion,
        Region? nouvelleRegion, 
        Commune commune,
        CancellationToken cancellationToken)
    {
        bool regionChange = commune.RegionId != ancienneRegion?.Id;
        
        if (regionChange)
        {
            // Si la commune a changé de région
            if (ancienneRegion != null)
            {
                // Mettre à jour l'ancienne région si nécessaire
                await regionRepository.UpdateAsync(ancienneRegion, cancellationToken);
            }
            
            // Ajouter la commune à la nouvelle région
            if (nouvelleRegion != null)
            {
                nouvelleRegion.AjouterCommune(commune);
                await regionRepository.UpdateAsync(nouvelleRegion, cancellationToken);
            }
        }
    }
}
