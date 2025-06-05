using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.TransactionCollecteEvents;

public record TransactionCollecteUpdated : DomainEvent
{
    public TransactionCollecte TransactionCollecte { get; init; } = default!;
} 
