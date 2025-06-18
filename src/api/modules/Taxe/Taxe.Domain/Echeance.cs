using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.EcheanceEvents;
using PayCom.WebApi.Taxe.Domain.BusinessRules;
using Shared.Enums;
using System.Linq;

namespace  PayCom.WebApi.Taxe.Domain;

public class Echeance : AuditableEntity, IAggregateRoot
{
    public Guid ObligationFiscaleId { get; private set; }
    public virtual ObligationFiscale ObligationFiscale { get; private set; } = default!;
    
    public int AnneeImposition { get; private set; }
    public int PeriodeImposition { get; private set; } // Numéro du trimestre, mois, etc.
    public DateTime DateEcheance { get; private set; }
    public decimal MontantBase { get; private set; }
    public decimal MontantPenalites { get; private set; }
    public decimal MontantTotal { get; private set; }
    public StatutEcheance Statut { get; private set; }

    // Navigation properties
    private readonly List<TransactionCollecte> _transactions = new();
    public virtual IReadOnlyCollection<TransactionCollecte> Transactions => _transactions.AsReadOnly();
    
    // Ajout de la collection des paiements
    private readonly List<Paiement> _paiements = new();
    public virtual IReadOnlyCollection<Paiement> Paiements => _paiements.AsReadOnly();

    private Echeance() { }

    public Echeance(Guid id, Guid obligationFiscaleId, int anneeImposition, int periodeImposition, 
                   DateTime dateEcheance, decimal montantBase, decimal montantPenalites, StatutEcheance statut)
    {
        // Validation des entrées
        if (dateEcheance <= DateTime.MinValue)
            throw new DomainException("La date d'échéance doit être valide.");
            
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
                                DateTime dateEcheance, decimal montantBase, decimal montantPenalites, StatutEcheance statut,
                                ObligationFiscale? obligationFiscale = null)
    {
        // Appliquer les règles métier avant la création
        EcheanceBusinessRules.ValidateCreateEcheance(
            obligationFiscaleId, anneeImposition, periodeImposition, 
            dateEcheance, montantBase, montantPenalites, statut, obligationFiscale);
        
        return new Echeance(Guid.NewGuid(), obligationFiscaleId, anneeImposition, periodeImposition, 
                           dateEcheance, montantBase, montantPenalites, statut);
    }

    public Echeance Update(Guid obligationFiscaleId, int anneeImposition, int periodeImposition, 
                          DateTime dateEcheance, decimal montantBase, decimal montantPenalites, StatutEcheance statut)
    {
        // Validation des entrées
        if (dateEcheance <= DateTime.MinValue)
            throw new DomainException("La date d'échéance doit être valide.");
            
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

    public void CalculerMontant(decimal tauxBase, decimal quantite, TypeTaxe? typeTaxe = null)
    {
        // Appliquer les règles métier pour le calcul
        EcheanceBusinessRules.ValidateCalculMontant(tauxBase, quantite, typeTaxe);
        
        MontantBase = tauxBase * quantite;
        MontantTotal = MontantBase + MontantPenalites;
        QueueDomainEvent(new MontantEcheanceCalcule { Echeance = this });
    }

    public void AppliquerPenalite(decimal montantPenalite, string motif = "Pénalité appliquée")
    {
        if (montantPenalite > 0)
        {
            // Appliquer les règles métier pour les pénalités
            EcheanceBusinessRules.ValidateApplyPenalite(this, montantPenalite, motif);
            
            MontantPenalites += montantPenalite;
            MontantTotal = MontantBase + MontantPenalites;
            QueueDomainEvent(new PenaliteAppliquee { Echeance = this, MontantPenalite = montantPenalite });
        }
    }

    public void EnregistrerTransaction(TransactionCollecte transaction)
    {
        _transactions.Add(transaction);
        MettreAJourStatut();
    }
    
    public void EnregistrerPaiement(Paiement paiement)
    {
        if (paiement.EcheanceId != Id)
            throw new DomainException("Ce paiement n'est pas associé à cette échéance.");
            
        _paiements.Add(paiement);
        MettreAJourStatut();
        
        QueueDomainEvent(new PaiementEnregistre { Echeance = this, Paiement = paiement });
    }
    
    private void MettreAJourStatut()
    {
        // Calculer le montant total payé (transactions + paiements)
        decimal totalTransactions = _transactions.Sum(t => t.MontantPercu);
        decimal totalPaiements = _paiements.Sum(p => p.Montant);
        decimal totalPaye = totalTransactions + totalPaiements;
        
        StatutEcheance ancienStatut = Statut;
        
        if (totalPaye >= MontantTotal)
        {
            Statut = StatutEcheance.Payee;
        }
        else if (totalPaye > 0)
        {
            Statut = StatutEcheance.PaiementPartiel;
        }
        
        /*  if (Statut != ancienStatut)
        {
            QueueDomainEvent(new EcheanceStatutChange { 
                Echeance = this,
                AncienStatut = ancienStatut,
                NouveauStatut = Statut
            });
        }*/
    }
} 

// Classe d'exception pour le domaine
public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
    }
} 
