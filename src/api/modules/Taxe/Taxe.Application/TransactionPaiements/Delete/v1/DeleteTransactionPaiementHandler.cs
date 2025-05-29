using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Delete.v1;
public class DeleteTransactionPaiementHandler(ILogger<DeleteTransactionPaiementHandler> logger,
    [FromKeyedServices("taxe:transaction-paiements")] IRepository<TransactionPaiement> repository) : IRequestHandler<DeleteTransactionPaiementCommand>
{
    public async Task Handle(DeleteTransactionPaiementCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var transactionPaiement = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = transactionPaiement?? throw new TransactionPaiementNotFoundException(request.Id);
        await repository.DeleteAsync(transactionPaiement, cancellationToken);
        logger.LogInformation("TransactionPaiement avec l'id: {Id} supprimée.", request.Id);
    }
}
