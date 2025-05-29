using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Notifications.Delete.v1;
public class DeleteNotificationHandler(
    ILogger<DeleteNotificationHandler> logger,
    [FromKeyedServices("taxe:notifications")]
    IRepository<Notification> repository) : IRequestHandler<DeleteNotificationCommand>
{
    public async Task Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var notification = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = notification ?? throw new NotificationNotFoundException(request.Id);
        await repository.DeleteAsync(notification, cancellationToken);
        logger.LogInformation("Notification avec l'id {notificationId} supprimée.", notification.Id);
    }
}
