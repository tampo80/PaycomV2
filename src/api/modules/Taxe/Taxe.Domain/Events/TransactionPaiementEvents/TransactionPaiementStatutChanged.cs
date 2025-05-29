using FSH.Framework.Core.Domain.Events;
using Shared.Enums;

namespace  PayCom.WebApi.Taxe.Domain.Events.TransactionPaiementEvents;

public record TransactionPaiementStatutChanged : DomainEvent
{
    public TransactionPaiement TransactionPaiement { get; init; } = default!;
    public StatutPaiement AncienStatut { get; init; }
    public StatutPaiement NouveauStatut { get; init; }
} 
