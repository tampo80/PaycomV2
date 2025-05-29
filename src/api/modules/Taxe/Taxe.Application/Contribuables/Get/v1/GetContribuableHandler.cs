using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Application.Configurations.Get.v1;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Contribuables.Get.v1;
public sealed class GetContribuableHandler(
    [FromKeyedServices("taxe:contribuables")] IReadRepository<Contribuable> repository,
    ICacheService cache) : IRequestHandler<GetContribuableRequest, ContribuableResponse>
{
    public async Task<ContribuableResponse> Handle(GetContribuableRequest request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"contribuable: {request.Id}", async () =>
            {
                var contribuableItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (contribuableItem == null) throw new ContribuableNotFoundException(request.Id);
                return new ContribuableResponse(
                    contribuableItem.Id, 
                    contribuableItem.Nom, 
                    contribuableItem.Prenom,
                    contribuableItem.DateNaissance, 
                    contribuableItem.Genre, 
                    contribuableItem.NumeroIdentification,
                    contribuableItem.NomCommercial, 
                    contribuableItem.Adresse, 
                    contribuableItem.LocalisationGPS,
                    contribuableItem.TypeActivite, 
                    contribuableItem.ContactPrincipal,
                    contribuableItem.ContactSecondaire,
                    contribuableItem.DateEnregistrement, 
                    contribuableItem.Statut,
                    contribuableItem.TypeContribuable,
                    contribuableItem.NumeroRegistreCommerce,
                    contribuableItem.Email,
                    contribuableItem.UtilisateurId,
                    contribuableItem.AgentFiscalId,
                    contribuableItem.NIF,
                    contribuableItem.DateCreationEntreprise,
                    contribuableItem.SecteurActivite,
                    contribuableItem.CapitalSocial,
                    contribuableItem.FormeJuridique,
                    contribuableItem.RepresentantLegal);
            }, cancellationToken: cancellationToken);
        return item!;
    }
}
