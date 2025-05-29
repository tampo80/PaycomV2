using FSH.Framework.Core.Domain.Events;

namespace PayCom.WebApi.Taxe.Domain.Events.PrefectureEvents;

public sealed record PrefectureUpdated : DomainEvent
{
    public Prefecture? Prefecture { get; set; }
}
