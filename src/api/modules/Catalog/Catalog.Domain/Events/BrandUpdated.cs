using FSH.Framework.Core.Domain.Events;

namespace PayCom.WebApi.Catalog.Domain.Events;
public sealed record BrandUpdated : DomainEvent
{
    public Brand? Brand { get; set; }
}
