using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.PaiementEvents;

public sealed record PaiementCreated : DomainEvent
{
    public Paiement Paiement { get; init; } = default!;
}
