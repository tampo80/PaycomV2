using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.CollecteTerrainSessionEvents;

public record TransactionAjouteeSession : DomainEvent
{
    public CollecteTerrainSession Session { get; init; } = default!;
    public TransactionCollecte Transaction { get; init; } = default!;
} 
