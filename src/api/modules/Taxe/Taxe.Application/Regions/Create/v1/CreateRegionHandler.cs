using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Regions.Create.v1;
public sealed class CreateRegionHandler(
    [FromKeyedServices("taxe:regions")] IRepository<Region> repository,
    [FromKeyedServices("taxe:communes")] IRepository<Commune> communeRepository,
    ILogger<CreateRegionHandler> logger)
    : IRequestHandler<CreateRegionCommand, CreateRegionResponse>
{
    public async Task<CreateRegionResponse> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        // Vérifier si le chef-lieu existe
        Commune? chefLieu = null;
        string? nomChefLieu = null;
        if (request.ChefLieuId.HasValue)
        {
            chefLieu = await communeRepository.GetByIdAsync(request.ChefLieuId.Value, cancellationToken);
            if (chefLieu == null)
            {
                throw new ApplicationException($"La commune avec l'ID {request.ChefLieuId.Value} n'existe pas.");
            }
            nomChefLieu = chefLieu.Nom;
        }
        // Créer une nouvelle région en utilisant la méthode factory
        var region = Region.Create(
            request.Nom,
            request.Code ?? string.Empty);
            
        // Définir le chef-lieu si spécifié
        if (chefLieu != null)
            region.DefinirChefLieu(chefLieu);
        // Sauvegarder la nouvelle entité dans le repository
        await repository.AddAsync(region, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Région créée avec l'ID {RegionId}", region.Id);
        // Retourner la réponse avec les données de l'entité créée
        return new CreateRegionResponse(
            region.Id,
            region.Nom,
            region.Code,
            region.ChefLieuId,
            nomChefLieu);
    }
}
