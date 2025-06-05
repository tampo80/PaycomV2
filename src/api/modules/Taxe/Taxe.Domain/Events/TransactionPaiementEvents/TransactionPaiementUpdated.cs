using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.TransactionPaiementEvents;

public sealed record TransactionPaiementUpdated : DomainEvent
{
    public TransactionPaiement TransactionPaiement { get; init; } = default!;
}
