using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.TransactionPaiementEvents;

public sealed record TransactionPaiementCreated : DomainEvent
{
    public TransactionPaiement? TransactionPaiement { get; set; }
}
