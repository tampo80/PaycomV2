using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Framework.Core.Identity.Users.Dtos;
using PayCom.WebApi.Taxe.Domain.Events.OperationEvents;


namespace  PayCom.WebApi.Taxe.Domain;

public class Operation : AuditableEntity, IAggregateRoot
{
    public DateTime Date { get; private set; }
    // public TypeOperation Type { get; private set; } // Enum
    public string Description { get; private set; } = string.Empty;
    public UserDetail Utilisateur { get; private set; } = default!;

    private Operation() { }

    public Operation(Guid id,DateTime date, string description, UserDetail utilisateur)
    {
        Id = id;
        Date = date;
        Description = description;
        Utilisateur = utilisateur;
        QueueDomainEvent( new OperationCreated{Operation = this});
    }

    public static Operation Create(DateTime date, string description, UserDetail utilisateur)
    {
        return new Operation(Guid.NewGuid(),date, description, utilisateur);
    }
    
    public Operation Update(DateTime date, string description, UserDetail utilisateur)
    {
        bool isUpdated = false;

        if (Date != date)
        {
            Date = date;
            isUpdated = true;
        }

        if (Description != description)
        {
            Description = description;
            isUpdated = true;
        }

        if (Utilisateur != utilisateur)
        {
            Utilisateur = utilisateur;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new OperationUpdated{Operation = this});
        }
        return this;
    }
}
