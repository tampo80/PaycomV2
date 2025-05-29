using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Events.EcheancierEvents;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.EventHandler;
public class EcheancierCreateEventHandler(
    ILogger<EcheancierCreateEventHandler> logger) : INotificationHandler<EcheancierCreated>
{
    public async Task Handle(EcheancierCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gestion de domaine d'evenement de echeancier créé..");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de domaine d'évenement de echeancier terminé..");
    }
}
