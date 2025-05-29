using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.PenaliteEvents;


namespace PayCom.WebApi.Taxe.Domain;

public class Penalite : AuditableEntity, IAggregateRoot
{
    public DateTime DateApplication { get; private set; }
    public double Montant { get; private set; }
    public string Type { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Taxe TaxeConcernee { get; private set; } = default!;

    private Penalite() { }

    public Penalite(Guid id,DateTime dateApplication, double montant, string type, string description, Taxe taxeConcernee)
    {
        Id = id;
        DateApplication = dateApplication;
        Montant = montant;
        Type = type;
        Description = description;
        TaxeConcernee = taxeConcernee;
        QueueDomainEvent( new PenaliteCreated{Penalite = this});
    }

    public static Penalite Create(DateTime dateApplication, double montant, string type, string description, Taxe taxeConcernee)
    {
        return new Penalite(Guid.NewGuid(),dateApplication, montant, type, description, taxeConcernee);
    }
    
    public Penalite Update(DateTime dateApplication, double montant, string type, string description, Taxe taxeConcernee)
    {
        bool isUpdated = false;

        if (DateApplication != dateApplication)
        {
            DateApplication = dateApplication;
            isUpdated = true;
        }

        if (Montant != montant)
        {
            Montant = montant;
            isUpdated = true;
        }

        if (Type != type)
        {
            Type = type;
            isUpdated = true;
        }

        if (Description != description)
        {
            Description = description;
            isUpdated = true;
        }

        if (TaxeConcernee != taxeConcernee)
        {
            TaxeConcernee = taxeConcernee;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new PenaliteUpdated{Penalite = this});
        }
        return this;
    }
}

