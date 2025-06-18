using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Notifications.Update.v1;
public class UpdateNotificationHandler(
    ILogger<UpdateNotificationHandler> logger,
    [FromKeyedServices("taxe:notifications")] IRepository<Notification> repository) 
    : IRequestHandler<UpdateNotificationCommand, UpdateNotificationResponse>
{
    public async Task<UpdateNotificationResponse> Handle(UpdateNotificationCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var notification = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = notification?? throw new NotificationNotFoundException(request.Id);
        var updateNotification = notification.Update(
            request.Type, 
            request.DateEnvoi, 
            request.Contenu,
            request.TypeDestinataire,
            request.ContribuableId,
            request.Titre,
            request.Priorite,
            request.DateExpiration);
        await repository.UpdateAsync(updateNotification, cancellationToken);
        logger.LogInformation("Notification avec l'id {notificationId} mis à jour.", notification.Id);
        return new UpdateNotificationResponse(notification.Id);
    }
}
