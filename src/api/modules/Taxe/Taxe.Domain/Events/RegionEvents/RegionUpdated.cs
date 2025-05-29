using FSH.Framework.Core.Domain.Events;

namespace PayCom.WebApi.Taxe.Domain.Events.RegionEvents;

public sealed record RegionUpdated(
    Guid Id,
    string Nom,
    string Code) : DomainEvent;
