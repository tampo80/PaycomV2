using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Events.OperationEvents;

namespace PayCom.WebApi.Taxe.Application.Operations.EventHandlers;
public class OperationCreateEventHandler(ILogger<OperationCreateEventHandler> logger)
: INotificationHandler<OperationCreated>
{
    public async Task Handle(OperationCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gestion de domaine d'evement de operation créé..");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de domaine d'evement de operation terminée..");
    }
}
