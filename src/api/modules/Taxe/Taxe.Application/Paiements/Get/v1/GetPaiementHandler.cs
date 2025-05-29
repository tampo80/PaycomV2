using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Paiements.Get.v1;
public sealed class GetPaiementHandler(
    [FromKeyedServices("taxe:paiements")] IReadRepository<Paiement> repository,
    ICacheService cache) : IRequestHandler<GetPaiementRequest, PaiementResponse>
{
    public async Task<PaiementResponse> Handle(GetPaiementRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"Paiement {request.Id}", async () =>
            {
                var paiementItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (paiementItem == null) throw new PaiementNotFoundException(request.Id);
                return new PaiementResponse(paiementItem.Id, paiementItem.Date, paiementItem.Montant,
                    paiementItem.ModePaiement,
                    paiementItem.CodeTransaction, paiementItem.DateTransaction, paiementItem.FraisTransaction,
                    paiementItem.InformationsSupplementaires, paiementItem.Statut);
            }, cancellationToken: cancellationToken);
        return item!;
    }
}
