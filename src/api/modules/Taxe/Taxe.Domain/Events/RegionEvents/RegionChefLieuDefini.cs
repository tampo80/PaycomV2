using FSH.Framework.Core.Domain;

namespace PayCom.WebApi.Taxe.Domain.Events.RegionEvents;

public class RegionChefLieuDefini : TaxeDomainEventBase
{
    public Region Region { get; set; } = null!;
}
