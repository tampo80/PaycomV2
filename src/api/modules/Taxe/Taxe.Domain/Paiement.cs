using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.PaiementEvents;
using PayCom.WebApi.Taxe.Domain.BusinessRules;
using Shared.Enums;


namespace  PayCom.WebApi.Taxe.Domain;
public class Paiement : AuditableEntity, IAggregateRoot
{
    public DateTime Date { get; private set; }
    public decimal Montant { get; private set; }
    public ModePaiement ModePaiement { get; private set; } // Enum type
    public string CodeTransaction { get; private set; } = string.Empty;
    public DateTime DateTransaction { get; private set; }
    public StatutPaiement Statut { get; private set; } // Enum type
    public decimal FraisTransaction { get; private set; }
    public string InformationsSupplementaires { get; private set; } = string.Empty;
    
    // CORRECTION CRITIQUE : Relations obligatoires et optionnelles
    public Guid ContribuableId { get; private set; } // NOUVEAU - OBLIGATOIRE
    public virtual Contribuable Contribuable { get; private set; } = default!; // NOUVEAU
    
    public Guid? EcheanceId { get; private set; } // OPTIONNEL pour paiements libres
    public virtual Echeance? Echeance { get; private set; } = default!;
    
    public Guid? AgentFiscalId { get; private set; } // NOUVEAU - OPTIONNEL pour paiements par agent
    public virtual AgentFiscal? AgentFiscal { get; private set; } = default!; // NOUVEAU

    private Paiement() { }

    public Paiement(Guid id, DateTime date, decimal montant, ModePaiement modePaiement, 
        string codeTransaction, DateTime dateTransaction, StatutPaiement statut,
        decimal fraisTransaction, string informationsSupplementaires, 
        Guid contribuableId, Guid? echeanceId, Guid? agentFiscalId = null)
    {
        Id = id;
        Date = date;
        Montant = montant;
        ModePaiement = modePaiement;
        CodeTransaction = codeTransaction;
        DateTransaction = dateTransaction;
        Statut = statut;
        FraisTransaction = fraisTransaction;
        InformationsSupplementaires = informationsSupplementaires;
        ContribuableId = contribuableId; // NOUVEAU
        EcheanceId = echeanceId;
        AgentFiscalId = agentFiscalId; // NOUVEAU
        
        QueueDomainEvent(new PaiementCreated{Paiement = this});
    }

    public static Paiement Create(DateTime date, decimal montant, ModePaiement modePaiement,
        string codeTransaction, DateTime dateTransaction, StatutPaiement statut,
        decimal fraisTransaction, string informationsSupplementaires, 
        Guid contribuableId, Guid? echeanceId, Guid? agentFiscalId = null,
        Echeance? echeance = null, AgentFiscal? agent = null)
    {
        // Appliquer les règles métier avant la création
        PaiementBusinessRules.ValidateCreatePaiement(
            montant, modePaiement, statut, contribuableId, echeance, agent);
        
        PaiementBusinessRules.ValidatePaymentLimits(montant, modePaiement, agent);
        PaiementBusinessRules.ValidatePaymentSpecificInfo(modePaiement, informationsSupplementaires);
        
        return new Paiement(Guid.NewGuid(), date, montant, modePaiement, codeTransaction, 
            dateTransaction, statut, fraisTransaction, informationsSupplementaires, 
            contribuableId, echeanceId, agentFiscalId);
    }

    public Paiement Update(DateTime date, decimal montant, string codeTransaction, 
        DateTime dateTransaction, decimal fraisTransaction, string informationsSupplementaires)
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

    public void ChangerStatut(StatutPaiement nouveauStatut)
    {
        if (Statut != nouveauStatut)
        {
            // Appliquer les règles métier pour la mise à jour
            PaiementBusinessRules.ValidateUpdatePaiement(this, nouveauStatut);
            
            var ancienStatut = Statut;
            Statut = nouveauStatut;
            QueueDomainEvent(new PaiementStatutChange { 
                Paiement = this, 
                AncienStatut = ancienStatut,
                NouveauStatut = nouveauStatut
            });
        }
    }
}
