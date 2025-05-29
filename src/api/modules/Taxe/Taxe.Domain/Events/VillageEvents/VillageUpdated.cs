using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.VillageEvents;

public sealed record VillageUpdated : DomainEvent
{
    public Village? Village { get; set; }
}
