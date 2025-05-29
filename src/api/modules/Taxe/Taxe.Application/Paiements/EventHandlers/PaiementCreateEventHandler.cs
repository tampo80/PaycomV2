using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Events.PaiementEvents;

namespace PayCom.WebApi.Taxe.Application.Paiements.EventHandlers;
public class PaiementCreateEventHandler(ILogger<PaiementCreateEventHandler> logger)
    : INotificationHandler<PaiementCreated>
{
    public async Task Handle(PaiementCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gestion de paiement créé...");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de paiement terminée..");
    }
}
