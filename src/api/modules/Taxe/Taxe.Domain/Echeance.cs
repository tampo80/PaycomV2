using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.EcheanceEvents;
using Shared.Enums;


namespace  PayCom.WebApi.Taxe.Domain;

public class Echeance : AuditableEntity, IAggregateRoot
{
    public Guid ObligationFiscaleId { get; private set; }
    public virtual ObligationFiscale ObligationFiscale { get; private set; } = default!;
    
    public int AnneeImposition { get; private set; }
    public int PeriodeImposition { get; private set; } // Numéro du trimestre, mois, etc.
    public DateTime DateEcheance { get; private set; }
    public double MontantBase { get; private set; }
    public double MontantPenalites { get; private set; }
    public double MontantTotal { get; private set; }
    public StatutEcheance Statut { get; private set; }

    // Navigation property pour les transactions
    private readonly List<TransactionCollecte> _transactions = new();
    public virtual IReadOnlyCollection<TransactionCollecte> Transactions => _transactions.AsReadOnly();

    private Echeance() { }

    public Echeance(Guid id, Guid obligationFiscaleId, int anneeImposition, int periodeImposition, 
                   DateTime dateEcheance, double montantBase, double montantPenalites, StatutEcheance statut)
    {
        Id = id;
        ObligationFiscaleId = obligationFiscaleId;
        AnneeImposition = anneeImposition;
        PeriodeImposition = periodeImposition;
        DateEcheance = dateEcheance;
        MontantBase = montantBase;
        MontantPenalites = montantPenalites;
        MontantTotal = montantBase + montantPenalites;
        Statut = statut;
        
        QueueDomainEvent(new EcheanceCreated { Echeance = this });
    }

    public static Echeance Create(Guid obligationFiscaleId, int anneeImposition, int periodeImposition, 
                                DateTime dateEcheance, double montantBase, double montantPenalites, StatutEcheance statut)
    {
        return new Echeance(Guid.NewGuid(), obligationFiscaleId, anneeImposition, periodeImposition, 
                           dateEcheance, montantBase, montantPenalites, statut);
    }

    public Echeance Update(Guid obligationFiscaleId, int anneeImposition, int periodeImposition, 
                          DateTime dateEcheance, double montantBase, double montantPenalites, StatutEcheance statut)
    {
        bool isUpdated = false;

        if (ObligationFiscaleId != obligationFiscaleId)
        {
            ObligationFiscaleId = obligationFiscaleId;
            isUpdated = true;
        }

        if (AnneeImposition != anneeImposition)
        {
            AnneeImposition = anneeImposition;
            isUpdated = true;
        }

        if (PeriodeImposition != periodeImposition)
        {
            PeriodeImposition = periodeImposition;
            isUpdated = true;
        }

        if (DateEcheance != dateEcheance)
        {
            DateEcheance = dateEcheance;
            isUpdated = true;
        }

        if (MontantBase != montantBase || MontantPenalites != montantPenalites)
        {
            MontantBase = montantBase;
            MontantPenalites = montantPenalites;
            MontantTotal = montantBase + montantPenalites;
            isUpdated = true;
        }

        if (Statut != statut)
        {
            Statut = statut;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new EcheanceUpdated { Echeance = this });
        }

        return this;
    }

    public void CalculerMontant(double tauxBase, double quantite)
    {
        MontantBase = tauxBase * quantite;
        MontantTotal = MontantBase + MontantPenalites;
        QueueDomainEvent(new MontantEcheanceCalcule { Echeance = this });
    }

    public void AppliquerPenalite(double montantPenalite)
    {
        if (montantPenalite > 0)
        {
            MontantPenalites += montantPenalite;
            MontantTotal = MontantBase + MontantPenalites;
            QueueDomainEvent(new PenaliteAppliquee { Echeance = this, MontantPenalite = montantPenalite });
        }
    }

    public void EnregistrerTransaction(TransactionCollecte transaction)
    {
        _transactions.Add(transaction);
        
        // Mettre à jour le statut en fonction du paiement
        double totalPaye = _transactions.Sum(t => t.MontantPercu);
        
        if (totalPaye >= MontantTotal)
        {
            Statut = StatutEcheance.Payee;
        }
        else if (totalPaye > 0)
        {
            Statut = StatutEcheance.PaiementPartiel;
        }
        
        QueueDomainEvent(new TransactionEnregistree { Echeance = this, Transaction = transaction });
    }
} 
