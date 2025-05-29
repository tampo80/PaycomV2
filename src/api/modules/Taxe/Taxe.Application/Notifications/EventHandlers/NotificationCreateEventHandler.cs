using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Events.NotificationEvents;

namespace PayCom.WebApi.Taxe.Application.Notifications.EventHandlers;
public class NotificationCreateEventHandler(ILogger<NotificationCreateEventHandler> logger)
    : INotificationHandler<NotificationCreated>
{
    public async Task Handle(NotificationCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gestion de domaine d'evement de notification créé..");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de domaine d'evement de notification terminé..");
    }
}
