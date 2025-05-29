using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.PaiementEvents;
using Shared.Enums;


namespace  PayCom.WebApi.Taxe.Domain;
public class Paiement : AuditableEntity, IAggregateRoot
{
    public DateTime Date { get; private set; }
    public double Montant { get; private set; }
     public ModePaiement ModePaiement { get; private set; } // Enum type
    public string CodeTransaction { get; private set; } = string.Empty;
    public DateTime DateTransaction { get; private set; }
    public StatutPaiement Statut { get; private set; } // Enum type
    public double FraisTransaction { get; private set; }
    public string InformationsSupplementaires { get; private set; } = string.Empty;

    private Paiement() { }

    public Paiement(Guid id, DateTime date, double montant, string codeTransaction, DateTime dateTransaction, double fraisTransaction, string informationsSupplementaires)
    {
        Id = id;
        Date = date;
        Montant = montant;
        CodeTransaction = codeTransaction;
        DateTransaction = dateTransaction;
        FraisTransaction = fraisTransaction;
        InformationsSupplementaires = informationsSupplementaires;
        
        QueueDomainEvent( new PaiementCreated{Paiement = this});
    }

    public static Paiement Create(DateTime date, double montant, string codeTransaction, DateTime dateTransaction, double fraisTransaction, string informationsSupplementaires)
    {
        return new Paiement(Guid.NewGuid(),date, montant, codeTransaction, dateTransaction, fraisTransaction, informationsSupplementaires);
    }

    public Paiement Update(DateTime date, double montant, string codeTransaction, DateTime dateTransaction, double fraisTransaction, string informationsSupplementaires)
    {
        bool isUpdated = false;

        if (Date != date)
        {
            Date = date;
            isUpdated = true;
        }

        if (Montant != montant)
        {
            Montant = montant;
            isUpdated = true;
        }

        if (CodeTransaction != codeTransaction)
        {
            CodeTransaction = codeTransaction;
            isUpdated = true;
        }

        if (DateTransaction != dateTransaction)
        {
            DateTransaction = dateTransaction;
            isUpdated = true;
        }

        if (FraisTransaction != fraisTransaction)
        {
            FraisTransaction = fraisTransaction;
            isUpdated = true;
        }

        if (InformationsSupplementaires != informationsSupplementaires)
        {
            InformationsSupplementaires = informationsSupplementaires;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new PaiementUpdated{Paiement = this});
        }
        return this;
    }

   
}
