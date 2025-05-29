using FSH.Framework.Core.Domain.Events;

namespace PayCom.WebApi.Taxe.Domain.Events.RegionEvents;

public sealed record RegionCreated(
    Guid Id,
    string Nom,
    string Code) : DomainEvent;
