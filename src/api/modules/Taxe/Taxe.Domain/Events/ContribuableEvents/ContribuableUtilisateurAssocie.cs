using FSH.Framework.Core.Domain.Events;

namespace  PayCom.WebApi.Taxe.Domain.Events.ContribuableEvents;

public sealed record ContribuableUtilisateurAssocie : DomainEvent
{
    public Contribuable? Contribuable { get; set; }
} 
