using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;

using PayCom.WebApi.Taxe.Domain.Events.CommuneEvents;

namespace PayCom.WebApi.Taxe.Application.Communes.EventHandlers;
public class CommuneCreatedEventHandler(ILogger<CommuneCreatedEventHandler> logger)
: INotificationHandler<CommuneCreated>
{
    public async Task Handle(CommuneCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gestion de domaine d'evenement de commune créé.. ");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de domaine d'evenement de commune terminé..");
    }
}
