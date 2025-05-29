using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.EcheancierEvents;


namespace  PayCom.WebApi.Taxe.Domain;

public class Echeancier : AuditableEntity, IAggregateRoot
{
    public DateTime DateEcheance { get; private set; }
    public double MontantDu { get; private set; }
    public double MontantPaye { get; private set; }
    // public StatutEcheancier Statut { get; private set; } // Enum

    private Echeancier() { }

    public Echeancier(Guid id,DateTime dateEcheance, double montantDu, double montantPaye)
    {
        Id = id;
        DateEcheance = dateEcheance;
        MontantDu = montantDu;
        MontantPaye = montantPaye;
        
        QueueDomainEvent(new EcheancierCreated{Echeancier = this});
    }

    public static Echeancier Create(DateTime dateEcheance, double montantDu, double montantPaye)
    {
        return new Echeancier(Guid.NewGuid(),dateEcheance, montantDu, montantPaye);
    }
    
    public Echeancier Update(DateTime dateEcheance, double montantDu, double montantPaye)
    {
        bool isUpdated = false;

        if (DateEcheance != dateEcheance)
        {
            DateEcheance = dateEcheance;
            isUpdated = true;
        }

        if (MontantDu != montantDu)
        {
            MontantDu = montantDu;
            isUpdated = true;
        }

        if (MontantPaye != montantPaye)
        {
            MontantPaye = montantPaye;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new EcheancierUpdated{Echeancier = this});
        }
        return this;
    }

   
}
