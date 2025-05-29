using System;

namespace  PayCom.WebApi.Taxe.Domain.Events
{
    /// <summary>
    /// Classe de base pour les événements de domaine du module Taxe.
    /// Implémente ITaxeDomainEvent sans hériter directement de DomainEvent.
    /// </summary>
    public abstract class TaxeDomainEventBase : ITaxeDomainEvent
    {
        public DateTime RaisedOn { get; } = DateTime.UtcNow;
    }
} 
