using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.TransactionCollecteEvents;

public record TransactionSynchronisee : DomainEvent
{
    public TransactionCollecte Transaction { get; init; } = default!;
} 
