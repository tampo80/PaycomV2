using FSH.Framework.Core.Domain.Events;

namespace PayCom.WebApi.Catalog.Domain.Events;
public sealed record ProductUpdated : DomainEvent
{
    public Product? Product { get; set; }
}
