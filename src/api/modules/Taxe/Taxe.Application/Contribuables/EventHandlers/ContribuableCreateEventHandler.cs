using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Events.ContribuableEvents;

namespace PayCom.WebApi.Taxe.Application.Contribuables.EventHandlers;
public class ContribuableCreateEventHandler(ILogger<ContribuableCreateEventHandler> logger) : INotificationHandler<ContribuableCreated>
{
    public async Task Handle(ContribuableCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gestion de domaine d'evenement de contrbuable créée..");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de domaine d'evenement de contrbuable terminée..");
    }
}
