using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.EcheanceEvents;

public record EcheanceCreated : DomainEvent
{
    public Echeance Echeance { get; init; } = default!;
} 
