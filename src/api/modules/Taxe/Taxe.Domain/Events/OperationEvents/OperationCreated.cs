using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.OperationEvents;

public sealed record OperationCreated : DomainEvent
{
    public Operation? Operation { get; set; }
}
