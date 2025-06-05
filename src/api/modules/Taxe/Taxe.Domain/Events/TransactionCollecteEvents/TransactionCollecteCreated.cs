using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.TransactionCollecteEvents;

public record TransactionCollecteCreated : DomainEvent
{
    public TransactionCollecte TransactionCollecte { get; init; } = default!;
} 
