using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Events.AgentFiscalEvents;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.EventHandlers;
public class AgentFiscalCreatedEventHandler(ILogger<AgentFiscalCreatedEventHandler> logger)
    : INotificationHandler<AgentFiscalCreated>
{
    public async Task Handle(AgentFiscalCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gestion de domaine d'evenement de agentFiscal créé..");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de domaine d'evenement de agentFiscal terminé..");
    }
}
