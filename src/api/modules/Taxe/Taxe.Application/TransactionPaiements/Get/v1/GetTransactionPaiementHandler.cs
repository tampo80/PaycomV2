using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Get.v1;
public class GetTransactionPaiementHandler(
    [FromKeyedServices("taxe:transaction-paiements")] IReadRepository<TransactionPaiement> repository,
    ICacheService cache) : IRequestHandler<GetTransactionPaiementRequest, TransactionPaiementResponse>
{
    public async Task<TransactionPaiementResponse> Handle(GetTransactionPaiementRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"taxe {request.Id}", async () =>
            {
                var taxeItem = await repository.GetByIdAsync(request.Id);
                if (taxeItem == null) throw new TransactionPaiementNotFoundException(request.Id);
                return new TransactionPaiementResponse(
                    taxeItem.Id,
                    taxeItem.CodeTransaction,
                    taxeItem.Date,
                    taxeItem.Montant,
                    taxeItem.ModePaiement,
                    taxeItem.Frais,
                    taxeItem.Statut,
                    taxeItem.Paiement?.Echeance?.ObligationFiscale?.ContribuableId ?? Guid.Empty,
                    taxeItem.Paiement?.Echeance?.ObligationFiscale?.Contribuable?.Nom ?? "N/A",
                    taxeItem.AgentCollecteurId,
                    "N/A", // NomAgent
                    taxeItem.DonneesTechniques,
                    taxeItem.LieuCollecte,
                    taxeItem.SessionCollecteId,
                    "", // NotesSession
                    taxeItem.Created.DateTime,
                    taxeItem.LastModified.DateTime,
                    taxeItem.Paiement?.Echeance?.ObligationFiscaleId,
                    taxeItem.EstPaiementTerrain,
                    taxeItem.FournisseurPaiement,
                    taxeItem.Paiement
                );
            }, cancellationToken: cancellationToken);
        return item!;
    }
    
}
