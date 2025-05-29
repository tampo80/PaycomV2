using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.ConfigurationEvents;

public sealed record ConfigurationCreated : DomainEvent
{
    public Configuration? Configuration { get; set; }
}
