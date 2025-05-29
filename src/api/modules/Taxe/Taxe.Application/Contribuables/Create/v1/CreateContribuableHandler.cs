using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Contribuables.Create.v1;
public sealed class CreateContribuableHandler(
    ILogger<CreateContribuableHandler> logger,
    [FromKeyedServices("taxe:contribuables")] IRepository<Contribuable> repository) :IRequestHandler<CreateContribuableCommand, CreateContribuableResponse>
{
    public async Task<CreateContribuableResponse> Handle(CreateContribuableCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var contribuable = Contribuable.Create(
            request.Nom, 
            request.Prenom, 
            request.DateNaissance, 
            request.NumeroIdentification,
            request.NomCommercial, 
            request.Adresse, 
            request.LocalisationGPS, 
            request.TypeActivite,
            request.ContactPrincipal, 
            request.ContactSecondaire, 
            request.DateEnregistrement,
            request.Statut, 
            request.Genre,
            request.TypeContribuable,
            request.NumeroRegistreCommerce,
            request.Email,
            request.UtilisateurId,
            request.AgentFiscalId,
            request.NIF,
            request.DateCreationEntreprise,
            request.SecteurActivite,
            request.CapitalSocial,
            request.FormeJuridique,
            request.RepresentantLegal);
            
        await repository.AddAsync(contribuable, cancellationToken);
        logger.LogInformation("Contribuable créé {contribuableId}", contribuable.Id);
        
        return new CreateContribuableResponse(
            contribuable.Id,
            contribuable.Nom, 
            contribuable.Prenom,
            contribuable.DateNaissance, 
            contribuable.Genre, 
            contribuable.NumeroIdentification,
            contribuable.NomCommercial, 
            contribuable.Adresse, 
            contribuable.LocalisationGPS,
            contribuable.TypeActivite, 
            contribuable.ContactPrincipal,
            contribuable.ContactSecondaire,
            contribuable.DateEnregistrement, 
            contribuable.Statut,
            contribuable.TypeContribuable,
            contribuable.NumeroRegistreCommerce,
            contribuable.Email,
            contribuable.UtilisateurId,
            contribuable.AgentFiscalId,
            contribuable.NIF,
            contribuable.DateCreationEntreprise,
            contribuable.SecteurActivite,
            contribuable.CapitalSocial,
            contribuable.FormeJuridique,
            contribuable.RepresentantLegal);
    }
}
