using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Application.Configurations.Create.v1;
using PayCom.WebApi.Taxe.Application.Contribuables.Create.v1;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Notifications.Create.v1;
public sealed class CreateNotificationHandler(
    ILogger<CreateNotificationHandler> logger,
    [FromKeyedServices("taxe:notifications")] IRepository<Notification> repository)
    : IRequestHandler<CreateNotificationCommand, CreateNotificationResponse>
{
    public async Task<CreateNotificationResponse> Handle(CreateNotificationCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var notification = Notification.Create(
            request.Type, 
            request.DateEnvoi, 
            request.Contenu,
            request.TypeDestinataire,
            request.ContribuableId,
            request.AgentFiscalId,
            request.Titre,
            request.Priorite,
            request.DateExpiration);
        await repository.AddAsync(notification, cancellationToken);
        logger.LogInformation("Notification créé {notificationId} pour {typeDestinataire}", 
            notification.Id, request.TypeDestinataire);
        return new CreateNotificationResponse(notification.Id);
    }
}
