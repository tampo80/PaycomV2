using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.TypeTaxeEvents;

public record TypeTaxeUpdated : DomainEvent
{
    public TypeTaxe TypeTaxe { get; init; } = default!;
} 
