using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Taxes.Get.v1;
public class GetTaxeHandler(
    [FromKeyedServices("taxe:taxes")] IReadRepository<Taxe.Domain.Taxe> repository,
    ICacheService cache) : IRequestHandler<GetTaxeRequest, TaxeResponse>
{
    public async Task<TaxeResponse> Handle(GetTaxeRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"echeancier {request.Id}", async () =>
            {
                var echeancierItem = await repository.GetByIdAsync(request.Id);
                if (echeancierItem == null) throw new TaxeNotFoundException(request.Id);
                return new TaxeResponse(
                    echeancierItem.Id,
                    echeancierItem.AnneeImposition,
                    echeancierItem.Taux,
                    echeancierItem.DateEcheance,
                    echeancierItem.MontantDu,
                    echeancierItem.MontantPaye,
                    echeancierItem.SoldeRestant,
                    echeancierItem.PrixUnitaire,
                    echeancierItem.UniteMesure,
                    echeancierItem.Caracteristiques,
                    echeancierItem.DateCreation,
                    echeancierItem.DateDerniereModification
                );
            }, cancellationToken: cancellationToken);
        return item!;
    }
    
}
