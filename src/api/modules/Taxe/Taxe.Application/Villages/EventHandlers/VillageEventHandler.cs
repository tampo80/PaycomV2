using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Events.VillageEvents;

namespace PayCom.WebApi.Taxe.Application.Villages.EventHandlers;
public class VillageEventHandler(ILogger<VillageEventHandler> logger)
: INotificationHandler<VillageCreated>
{
    public async Task Handle(VillageCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gestion de village créée..");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de village terminée..");
    }
    
}
