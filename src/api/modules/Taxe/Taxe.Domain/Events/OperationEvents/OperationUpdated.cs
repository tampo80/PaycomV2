using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.OperationEvents;

public sealed record OperationUpdated : DomainEvent
{
    public Operation? Operation { get; set; }
}
