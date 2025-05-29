using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Events.TaxeEvents;

namespace PayCom.WebApi.Taxe.Application.Taxes.EventHandlers;
public class TaxeEventHandler(ILogger<TaxeEventHandler> logger)
: INotificationHandler<TaxeCreated>
{
    public async Task Handle(TaxeCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gestion de taxe créée..");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de taxe terminée..");
    }
    
}
