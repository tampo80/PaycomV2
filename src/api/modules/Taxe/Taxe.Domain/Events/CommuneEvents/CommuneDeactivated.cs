using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.CommuneEvents;

public record CommuneDeactivated : DomainEvent
{
    public Commune Commune { get; init; } = default!;
} 
