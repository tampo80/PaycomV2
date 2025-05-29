using FSH.Framework.Core.Domain.Events;
using MediatR;
using System;

namespace  PayCom.WebApi.Taxe.Domain.Events
{
    /// <summary>
    /// Interface pour tous les événements de domaine du module Taxe
    /// </summary>
    public interface ITaxeDomainEvent : IDomainEvent, INotification
    {
        DateTime RaisedOn { get; }
    }
} 
