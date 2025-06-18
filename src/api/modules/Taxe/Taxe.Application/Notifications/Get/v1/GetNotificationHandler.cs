using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Notifications.Get.v1;
public sealed class GetNotificationHandler(
    [FromKeyedServices("taxe:notifications")] IReadRepository<Notification> repository,
    ICacheService cache) : IRequestHandler<GetNotificationRequest, NotificationResponse>
{
    public async Task<NotificationResponse> Handle(GetNotificationRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"notification: {request.Id}", async () =>
            {
                var notificationItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (notificationItem == null) throw new NotificationNotFoundException(request.Id);
                return new NotificationResponse(
                    notificationItem.Id, 
                    notificationItem.Type, 
                    notificationItem.DateEnvoi, 
                    notificationItem.Contenu,
                    notificationItem.EstLue,
                    notificationItem.DateLecture,
                    notificationItem.Statut,
                    notificationItem.TypeDestinataire,
                    notificationItem.ContribuableId,
                    notificationItem.AgentFiscalId,
                    notificationItem.Titre,
                    notificationItem.Priorite,
                    notificationItem.DateExpiration,
                    notificationItem.EstArchivee);
            }, cancellationToken: cancellationToken);
        return item!;
    }
}
