using FSH.Framework.Core.Domain.Events;
using Shared.Enums;

namespace  PayCom.WebApi.Taxe.Domain.Events.AgentFiscalEvents;

public sealed record AgentFiscalStatutChange : DomainEvent
{
    public AgentFiscal? AgentFiscal { get; set; }
    public StatutAgent AncienStatut { get; set; }
    public StatutAgent NouveauStatut { get; set; }
} 
