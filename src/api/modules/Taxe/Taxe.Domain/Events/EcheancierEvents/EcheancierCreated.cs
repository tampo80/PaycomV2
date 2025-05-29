using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.EcheancierEvents;

public sealed record EcheancierCreated : DomainEvent
{
    public Echeancier? Echeancier { get; set; }
}
