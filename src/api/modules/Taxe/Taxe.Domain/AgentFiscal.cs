using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.AgentFiscalEvents;
using Shared.Enums;


namespace PayCom.WebApi.Taxe.Domain;

public class AgentFiscal : AuditableEntity, IAggregateRoot
{
    public string Nom { get; private set; } = string.Empty;
    public string Prenom { get; private set; } = string.Empty;
    public string Identifiant { get; private set; } = string.Empty;
    public string LocalisationGPS { get; private set; } = string.Empty;
    public DateTime DateEmbauche { get; private set; }
    public DateTime? DateFinFonction { get; private set; }
    public StatutAgent Statut { get; private set; } // Enum type
    public Guid? UtilisateurId { get; private set; } // Référence à l'utilisateur dans le système d'authentification
    public string Email { get; private set; } = string.Empty; // Email pour connexion
    public string Telephone { get; private set; } = string.Empty;
    
    // Propriétés pour la collecte sur le terrain
    public bool EstCollecteurTerrain { get; private set; }
    public double SoldePortefeuille { get; private set; } // Solde du portefeuille de l'agent collecteur

    private AgentFiscal() { }

    public AgentFiscal(Guid id, string nom, string prenom, string identifiant, string localisationGPS, 
        DateTime dateEmbauche, DateTime? dateFinFonction, StatutAgent statut, 
        Guid? utilisateurId, string email, string telephone, bool estCollecteurTerrain, double soldePortefeuille)
    {
        Id = id;
        Nom = nom;
        Prenom = prenom;
        Identifiant = identifiant;
        LocalisationGPS = localisationGPS;
        DateEmbauche = dateEmbauche;
        DateFinFonction = dateFinFonction;
        Statut = statut;
        UtilisateurId = utilisateurId;
        Email = email;
        Telephone = telephone;
        EstCollecteurTerrain = estCollecteurTerrain;
        SoldePortefeuille = soldePortefeuille;
        
        QueueDomainEvent(new AgentFiscalCreated{AgentFiscal = this});
    }

    public static AgentFiscal Create(string nom, string prenom, string identifiant, string localisationGPS, 
        DateTime dateEmbauche, DateTime? dateFinFonction, StatutAgent statut, 
        Guid? utilisateurId, string email, string telephone, bool estCollecteurTerrain, double soldePortefeuille = 0)
    {
        return new AgentFiscal(Guid.NewGuid(), nom, prenom, identifiant, localisationGPS, 
            dateEmbauche, dateFinFonction, statut, utilisateurId, email, telephone, estCollecteurTerrain, soldePortefeuille);
    }
    
    public static AgentFiscal CreateCollecteur(string nom, string prenom, string identifiant, string localisationGPS, 
        DateTime dateEmbauche, Guid? utilisateurId, string email, string telephone)
    {
        return new AgentFiscal(Guid.NewGuid(), nom, prenom, identifiant, localisationGPS, 
            dateEmbauche, null, StatutAgent.Actif, utilisateurId, email, telephone, true, 0);
    }
    
    public AgentFiscal Update(string nom, string prenom, string identifiant, string localisationGPS, 
        DateTime dateEmbauche, DateTime? dateFinFonction, StatutAgent statut, 
        Guid? utilisateurId, string email, string telephone, bool estCollecteurTerrain, double soldePortefeuille)
    {
        bool isUpdated = false;

        if (Nom != nom)
        {
            Nom = nom;
            isUpdated = true;
        }

        if (Prenom != prenom)
        {
            Prenom = prenom;
            isUpdated = true;
        }

        if (Identifiant != identifiant)
        {
            Identifiant = identifiant;
            isUpdated = true;
        }

        if (LocalisationGPS != localisationGPS)
        {
            LocalisationGPS = localisationGPS;
            isUpdated = true;
        }

        if (DateEmbauche != dateEmbauche)
        {
            DateEmbauche = dateEmbauche;
            isUpdated = true;
        }

        if (DateFinFonction != dateFinFonction)
        {
            DateFinFonction = dateFinFonction;
            isUpdated = true;
        }
        
        if (Statut != statut)
        {
            Statut = statut;
            isUpdated = true;
        }
        
        if (UtilisateurId != utilisateurId)
        {
            UtilisateurId = utilisateurId;
            isUpdated = true;
        }
        
        if (Email != email)
        {
            Email = email;
            isUpdated = true;
        }
        
        if (Telephone != telephone)
        {
            Telephone = telephone;
            isUpdated = true;
        }
        
        if (EstCollecteurTerrain != estCollecteurTerrain)
        {
            EstCollecteurTerrain = estCollecteurTerrain;
            isUpdated = true;
        }
        
        if (SoldePortefeuille != soldePortefeuille)
        {
            SoldePortefeuille = soldePortefeuille;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new AgentFiscalUpdated{AgentFiscal = this});
        }
        
        return this;
    }
    
    public void AssocierUtilisateur(Guid utilisateurId)
    {
        if (UtilisateurId != utilisateurId)
        {
            UtilisateurId = utilisateurId;
            QueueDomainEvent(new AgentFiscalUtilisateurAssocie { AgentFiscal = this });
        }
    }
    
    public void MettreAJourSoldePortefeuille(double nouveauSolde)
    {
        if (EstCollecteurTerrain && SoldePortefeuille != nouveauSolde)
        {
            double ancienSolde = SoldePortefeuille;
            SoldePortefeuille = nouveauSolde;
            QueueDomainEvent(new PortefeuilleAgentMisAJour { 
                AgentFiscal = this, 
                AncienSolde = ancienSolde, 
                NouveauSolde = nouveauSolde 
            });
        }
    }
    
    public void ChangerStatut(StatutAgent nouveauStatut)
    {
        if (Statut != nouveauStatut)
        {
            var ancienStatut = Statut;
            Statut = nouveauStatut;
            QueueDomainEvent(new AgentFiscalStatutChange { 
                AgentFiscal = this, 
                AncienStatut = ancienStatut,
                NouveauStatut = nouveauStatut
            });
        }
    }
}
