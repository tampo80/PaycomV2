using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.PrefectureEvent;

public sealed record PrefectureCreated : DomainEvent
{
    public Prefecture? Prefecture { get; set; }
}
