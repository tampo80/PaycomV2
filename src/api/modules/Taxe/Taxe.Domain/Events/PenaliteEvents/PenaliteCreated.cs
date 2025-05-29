using FSH.Framework.Core.Domain.Events;

namespace PayCom.WebApi.Taxe.Domain.Events.PenaliteEvents;

public sealed record PenaliteCreated : DomainEvent
{
    public Penalite? Penalite { get; set; }
}
