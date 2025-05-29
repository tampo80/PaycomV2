using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.PaiementEvents;

public sealed record PaiementUpdated : DomainEvent
{
    public Paiement? Paiement { get; set; }
}
