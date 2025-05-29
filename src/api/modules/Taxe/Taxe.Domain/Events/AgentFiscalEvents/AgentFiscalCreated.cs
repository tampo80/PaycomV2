using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.AgentFiscalEvents;

public sealed record AgentFiscalCreated : DomainEvent
{
    public AgentFiscal? AgentFiscal { get; set; }
}
