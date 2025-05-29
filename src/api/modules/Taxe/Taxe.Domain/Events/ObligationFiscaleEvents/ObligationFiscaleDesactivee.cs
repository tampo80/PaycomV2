using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.ObligationFiscaleEvents;

public record ObligationFiscaleDesactivee : DomainEvent
{
    public ObligationFiscale ObligationFiscale { get; init; } = default!;
} 
