using FSH.Framework.Core.Domain.Events;

namespace PayCom.WebApi.Taxe.Domain.Events.RegionEvents;

public sealed record ChefLieuChanged(
    string TypeEntite,
    Guid EntiteId,
    Guid? AncienChefLieuId,
    Guid? NouveauChefLieuId) : DomainEvent; 
