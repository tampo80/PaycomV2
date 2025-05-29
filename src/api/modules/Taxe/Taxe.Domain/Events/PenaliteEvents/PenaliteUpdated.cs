using FSH.Framework.Core.Domain.Events;

namespace PayCom.WebApi.Taxe.Domain.Events.PenaliteEvents;

public sealed record PenaliteUpdated : DomainEvent
{
    public Penalite? Penalite { get; set; }
}
