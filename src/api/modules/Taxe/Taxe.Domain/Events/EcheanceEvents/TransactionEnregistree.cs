using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.EcheanceEvents;

public record TransactionEnregistree : DomainEvent
{
    public Echeance Echeance { get; init; } = default!;
    public TransactionCollecte Transaction { get; init; } = default!;
} 
