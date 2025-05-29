using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.TaxeEvents
{
    public sealed record TaxeUpdated : DomainEvent
    {
        public Domain.Taxe? Taxe { get; set; }
    }
}
