using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.VilleEvents;

public sealed record VilleUpdated : DomainEvent
{
    public Ville? Ville { get; set; }
}
