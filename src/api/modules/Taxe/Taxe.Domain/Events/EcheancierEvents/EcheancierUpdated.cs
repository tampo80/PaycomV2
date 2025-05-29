using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.EcheancierEvents;

public sealed record EcheancierUpdated : DomainEvent
{
    public Echeancier? Echeancier { get; set; }
}
