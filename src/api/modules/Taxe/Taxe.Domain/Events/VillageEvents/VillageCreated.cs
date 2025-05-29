using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.VillageEvents;

public sealed record VillageCreated : DomainEvent
{
    public Village? Village { get; set; }
}
