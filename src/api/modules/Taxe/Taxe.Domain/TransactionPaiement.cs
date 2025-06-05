using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.TransactionPaiementEvents;
using Shared.Enums;


namespace  PayCom.WebApi.Taxe.Domain;

public class TransactionPaiement : AuditableEntity, IAggregateRoot
{
    public string CodeTransaction { get; private set; } = string.Empty;
    public DateTime Date { get; private set; }
    public decimal Montant { get; private set; }
    public ModePaiement ModePaiement { get; private set; } 
    public string FournisseurPaiement { get; private set; } = string.Empty; // Orange, MTN, Visa, Mastercard, etc.
    public string NumeroReference { get; private set; } = string.Empty; // Numéro de téléphone, 4 derniers chiffres de carte, etc.
    public decimal Frais { get; private set; }
    public StatutPaiement Statut { get; private set; }
    public string ReferenceBancaire { get; private set; } = string.Empty; // Référence du côté de la banque/opérateur
    public string DonneesTechniques { get; private set; } = string.Empty; // JSON avec données techniques (API response)
    public Paiement Paiement { get; private set; } = default!;
    
    // Nouvelles propriétés pour les virements bancaires
    public string BanqueEmettrice { get; private set; } = string.Empty;
    public string NumeroCompte { get; private set; } = string.Empty;
    public DateTime? DateVirement { get; private set; }
    public string ReferenceVirement { get; private set; } = string.Empty;
    
    // Pour les paiements en espèces
    public Guid? AgentCollecteurId { get; private set; }
    public bool EstPaiementTerrain { get; private set; }
    public string LieuCollecte { get; private set; } = string.Empty;
    public Guid? SessionCollecteId { get; private set; }

    private TransactionPaiement() { }

    public TransactionPaiement(Guid id, string codeTransaction, DateTime date, decimal montant, 
        ModePaiement modePaiement, string fournisseurPaiement, string numeroReference,
        decimal frais, StatutPaiement statut, string referenceBancaire, string donneesTechniques, Paiement paiement,
        string banqueEmettrice, string numeroCompte, DateTime? dateVirement, string referenceVirement,
        Guid? agentCollecteurId, bool estPaiementTerrain, string lieuCollecte, Guid? sessionCollecteId)
    {
        Id = id;
        CodeTransaction = codeTransaction;
        Date = date;
        Montant = montant;
        ModePaiement = modePaiement;
        FournisseurPaiement = fournisseurPaiement;
        NumeroReference = numeroReference;
        Frais = frais;
        Statut = statut;
        ReferenceBancaire = referenceBancaire;
        DonneesTechniques = donneesTechniques;
        Paiement = paiement;
        BanqueEmettrice = banqueEmettrice;
        NumeroCompte = numeroCompte;
        DateVirement = dateVirement;
        ReferenceVirement = referenceVirement;
        AgentCollecteurId = agentCollecteurId;
        EstPaiementTerrain = estPaiementTerrain;
        LieuCollecte = lieuCollecte;
        SessionCollecteId = sessionCollecteId;
        QueueDomainEvent(new TransactionPaiementCreated{TransactionPaiement = this});
    }

    public static TransactionPaiement Create(string codeTransaction, DateTime date, decimal montant, 
        ModePaiement modePaiement, string fournisseurPaiement, string numeroReference,
        decimal frais, StatutPaiement statut, string referenceBancaire, string donneesTechniques, Paiement paiement,
        string banqueEmettrice = "", string numeroCompte = "", DateTime? dateVirement = null, string referenceVirement = "",
        Guid? agentCollecteurId = null, bool estPaiementTerrain = false, string lieuCollecte = "", Guid? sessionCollecteId = null)
    {
        return new TransactionPaiement(
            Guid.NewGuid(), codeTransaction, date, montant, modePaiement, fournisseurPaiement,
            numeroReference, frais, statut, referenceBancaire, donneesTechniques, paiement,
            banqueEmettrice, numeroCompte, dateVirement, referenceVirement,
            agentCollecteurId, estPaiementTerrain, lieuCollecte, sessionCollecteId);
    }
    
    public static TransactionPaiement CreateVirementBancaire(string codeTransaction, DateTime date, decimal montant,
        string fournisseurPaiement, string numeroReference, decimal frais, string referenceBancaire, Paiement paiement,
        string banqueEmettrice, string numeroCompte, DateTime dateVirement, string referenceVirement)
    {
        return new TransactionPaiement(
            Guid.NewGuid(), codeTransaction, date, montant, ModePaiement.Virement, fournisseurPaiement,
            numeroReference, frais, StatutPaiement.EnAttente, referenceBancaire, "", paiement,
            banqueEmettrice, numeroCompte, dateVirement, referenceVirement,
            null, false, "", null);
    }
    
    public static TransactionPaiement CreatePaiementEspeces(string codeTransaction, DateTime date, decimal montant,
        string numeroReference, decimal frais, Paiement paiement,
        Guid agentCollecteurId, string lieuCollecte, Guid sessionCollecteId)
    {
        return new TransactionPaiement(
            Guid.NewGuid(), codeTransaction, date, montant, ModePaiement.Especes, "",
            numeroReference, frais, StatutPaiement.Reussi, "", "", paiement,
            "", "", null, "",
            agentCollecteurId, true, lieuCollecte, sessionCollecteId);
    }
    
    public TransactionPaiement Update(string codeTransaction, DateTime date, decimal montant, 
        ModePaiement modePaiement, string fournisseurPaiement, string numeroReference,
        decimal frais, StatutPaiement statut, string referenceBancaire, string donneesTechniques, Paiement paiement,
        string banqueEmettrice, string numeroCompte, DateTime? dateVirement, string referenceVirement,
        Guid? agentCollecteurId, bool estPaiementTerrain, string lieuCollecte, Guid? sessionCollecteId)
    {
        bool isUpdated = false;

        if (CodeTransaction != codeTransaction)
        {
            CodeTransaction = codeTransaction;
            isUpdated = true;
        }

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

        if (ModePaiement != modePaiement)
        {
            ModePaiement = modePaiement;
            isUpdated = true;
        }

        if (FournisseurPaiement != fournisseurPaiement)
        {
            FournisseurPaiement = fournisseurPaiement;
            isUpdated = true;
        }

        if (NumeroReference != numeroReference)
        {
            NumeroReference = numeroReference;
            isUpdated = true;
        }

        if (Frais != frais)
        {
            Frais = frais;
            isUpdated = true;
        }

        if (Statut != statut)
        {
            Statut = statut;
            isUpdated = true;
        }

        if (ReferenceBancaire != referenceBancaire)
        {
            ReferenceBancaire = referenceBancaire;
            isUpdated = true;
        }

        if (DonneesTechniques != donneesTechniques)
        {
            DonneesTechniques = donneesTechniques;
            isUpdated = true;
        }

        if (Paiement != paiement)
        {
            Paiement = paiement;
            isUpdated = true;
        }
        
        if (BanqueEmettrice != banqueEmettrice)
        {
            BanqueEmettrice = banqueEmettrice;
            isUpdated = true;
        }
        
        if (NumeroCompte != numeroCompte)
        {
            NumeroCompte = numeroCompte;
            isUpdated = true;
        }
        
        if (DateVirement != dateVirement)
        {
            DateVirement = dateVirement;
            isUpdated = true;
        }
        
        if (ReferenceVirement != referenceVirement)
        {
            ReferenceVirement = referenceVirement;
            isUpdated = true;
        }
        
        if (AgentCollecteurId != agentCollecteurId)
        {
            AgentCollecteurId = agentCollecteurId;
            isUpdated = true;
        }
        
        if (EstPaiementTerrain != estPaiementTerrain)
        {
            EstPaiementTerrain = estPaiementTerrain;
            isUpdated = true;
        }
        
        if (LieuCollecte != lieuCollecte)
        {
            LieuCollecte = lieuCollecte;
            isUpdated = true;
        }
        
        if (SessionCollecteId != sessionCollecteId)
        {
            SessionCollecteId = sessionCollecteId;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new TransactionPaiementUpdated { TransactionPaiement = this });
        }

        return this;
    }

    public void SetStatut(StatutPaiement nouveauStatut)
    {
        if (Statut != nouveauStatut)
        {
            var ancienStatut = Statut;
            Statut = nouveauStatut;
            QueueDomainEvent(new TransactionPaiementStatutChanged { 
                TransactionPaiement = this, 
                AncienStatut = ancienStatut,
                NouveauStatut = nouveauStatut
            });
        }
    }
}
