using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.AgentFiscalEvents;

public sealed record PortefeuilleAgentMisAJour : DomainEvent
{
    public AgentFiscal? AgentFiscal { get; set; }
    public double AncienSolde { get; set; }
    public double NouveauSolde { get; set; }
} 
