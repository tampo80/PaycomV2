using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Communes.Create.v1;
public sealed class CreateCommuneHandler(
    ILogger<CreateCommuneHandler> logger,
    [FromKeyedServices("taxe:communes")] IRepository<Commune> repository,
    [FromKeyedServices("taxe:regions")] IRepository<Region> regionRepository)
    : IRequestHandler<CreateCommuneCommand, CreateCommuneResponse>
{
    public async Task<CreateCommuneResponse> Handle(CreateCommuneCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        // Vérifier si la région existe
        var region = await regionRepository.GetByIdAsync(request.RegionId, cancellationToken);
        if (region == null)
        {
            throw new ApplicationException($"La région avec l'ID {request.RegionId} n'existe pas.");
        }
        // Créer la nouvelle commune
        var commune = Commune.Create(
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
            request.ResponsableCentreAdmin);
        
        // Définir le type de chef-lieu
        commune.DefinirTypeChefLieu(request.TypeChefLieu);
        
        // Ajouter la commune à la région
        region.AjouterCommune(commune);
        
        // Persister les changements
        await repository.AddAsync(commune, cancellationToken);
        await regionRepository.UpdateAsync(region, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        
        logger.LogInformation("Commune créée {CommuneId}", commune.Id);
        return new CreateCommuneResponse(commune.Id);
    }
}
