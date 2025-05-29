using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Events.PenaliteEvents;

namespace PayCom.WebApi.Taxe.Application.Penalites.EventHandlers;
public class PenaliteCreateEventHandler(ILogger<PenaliteCreateEventHandler> logger)
:INotificationHandler<PenaliteCreated>
{
    public async Task Handle(PenaliteCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gestion de penalité créée..");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de penalite terminéé..");
    }
}
