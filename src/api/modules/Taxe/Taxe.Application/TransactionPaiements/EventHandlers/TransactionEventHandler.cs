using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Events.TransactionPaiementEvents;
using PayCom.WebApi.Taxe.Application.TransactionPaiements.Delete.v1;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.EventHandlers;
public class TransactionEventHandler(
    ILogger<DeleteTransactionPaiementHandler> logger) : INotificationHandler<TransactionPaiementCreated>
{
    public async Task Handle(TransactionPaiementCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gestion de transaction créee..");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de transaction terminéee..");
    }
}
