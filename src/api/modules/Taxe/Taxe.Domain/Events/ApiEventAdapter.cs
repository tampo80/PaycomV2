using FSH.Framework.Core.Domain.Events;
using MediatR;
using System;

namespace  PayCom.WebApi.Taxe.Domain.Events
{
    /// <summary>
    /// Adaptateur qui permet de gérer les conflits entre les événements de domaine définis comme records
    /// et les classes générées automatiquement dans l'API client.
    /// </summary>
    public static class ApiEventAdapter
    {
        /// <summary>
        /// Les événements de domaine sont définis comme des records dans le domaine, mais pour éviter les conflits 
        /// avec la classe DomainEvent générée par l'API client, cette méthode permet de créer un événement 
        /// compatible avec le client tout en conservant les propriétés de l'événement original.
        /// </summary>
        public static TEvent AdaptEventForApiClient<TEvent>(TEvent domainEvent) 
            where TEvent : DomainEvent
        {
            // Cette méthode peut être utilisée pour adapter les événements au besoin
            // lorsqu'ils doivent être transmis à travers l'API client
            return domainEvent;
        }
    }
} 
