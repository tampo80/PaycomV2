using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.ObligationFiscaleEvents;

public record ObligationFiscaleReactivee : DomainEvent
{
    public ObligationFiscale ObligationFiscale { get; init; } = default!;
} 
