using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Create.v1;
public sealed class CreateTransactionPaiementHandler(
    ILogger<CreateTransactionPaiementHandler> logger,
    [FromKeyedServices("taxe:transaction-paiements")] IRepository<TransactionPaiement> repository)
: IRequestHandler<CreateTransactionPaiementCommand, CreateTransactionPaiementResponse>
{
    public async Task<CreateTransactionPaiementResponse> Handle(CreateTransactionPaiementCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var transaction = TransactionPaiement.Create(
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
            request.Paiement
        );
        await repository.AddAsync(transaction, cancellationToken);
        logger.LogInformation("Transaction créée {transactionId}", transaction.Id);
        return new CreateTransactionPaiementResponse(transaction.Id);
    }
    
}
