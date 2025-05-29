using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Events.ConfigurationEvents;

namespace PayCom.WebApi.Taxe.Application.Configurations.EventHandlers;
public class ConfigurationCreateEventHandler(ILogger<ConfigurationCreateEventHandler> logger) : INotificationHandler<ConfigurationCreated>
{
    public async Task Handle(ConfigurationCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gestion de domaine d'evenement de configuration créée..");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de domaine d'evenement de configuration terminée..");
    }
}
