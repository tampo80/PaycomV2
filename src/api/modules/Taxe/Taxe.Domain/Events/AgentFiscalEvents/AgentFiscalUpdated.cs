using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.AgentFiscalEvents;

public sealed record AgentFiscalUpdated : DomainEvent
{
    public AgentFiscal? AgentFiscal { get; set; }
}
