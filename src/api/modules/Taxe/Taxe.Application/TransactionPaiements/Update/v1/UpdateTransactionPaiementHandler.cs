using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;
using PayCom.WebApi.Taxe.Application.TransactionPaiements.Create;
using PayCom.WebApi.Taxe.Application.TransactionPaiements.Get.v1;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Update.v1;
public class UpdateTransactionPaiementHandler(
    ILogger<UpdateTransactionPaiementHandler> logger,
    [FromKeyedServices("taxe:transaction-paiements")]
    IRepository<TransactionPaiement> repository)
    : IRequestHandler<UpdateTransactionPaiementCommand, UpdateTransactionPaiementResponse>
{
    public async Task<UpdateTransactionPaiementResponse> Handle(UpdateTransactionPaiementCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var transaction = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = transaction ?? throw new TransactionPaiementNotFoundException(request.Id);
        var updateTaxe = transaction.Update(
            request.CodeTransaction,
            request.Date,
            request.Montant,
            request.ModePaiement,
            request.FournisseurPaiement,
            request.NumeroReference,
            request.Frais,
            request.Statut,
            request.ReferenceBancaire,
            request.DonneesTechniques,
            request.Paiement,
            transaction.BanqueEmettrice,
            transaction.NumeroCompte,
            transaction.DateVirement,
            transaction.ReferenceVirement,
            transaction.AgentCollecteurId,
            transaction.EstPaiementTerrain,
            transaction.LieuCollecte,
            transaction.SessionCollecteId
        );
        await repository.UpdateAsync(updateTaxe, cancellationToken);
        logger.LogInformation("Transaction mise à jour avec l'ID {transactionId}", transaction.Id);
        return new UpdateTransactionPaiementResponse(updateTaxe.Id);
    }
}
