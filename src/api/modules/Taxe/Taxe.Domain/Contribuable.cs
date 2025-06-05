using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.ContribuableEvents;
using Shared.Enums;

namespace  PayCom.WebApi.Taxe.Domain;

public class Contribuable : AuditableEntity, IAggregateRoot
{
    public string Nom { get; private set; } = string.Empty;
    public string Prenom { get; private set; } = string.Empty;
    public DateTime? DateNaissance { get; private set; }
    public Genre Genre { get; private set; } // Enum type
    public string NumeroIdentification { get; private set; } = string.Empty;
    public string NomCommercial { get; private set; } = string.Empty;
    public string Adresse { get; private set; } = string.Empty;
    public string LocalisationGPS { get; private set; } = string.Empty;
    public string TypeActivite { get; private set; } = string.Empty;
    //public Image PhotoPropriete { get; private set; } // Assuming Image is a custom class
    public string ContactPrincipal { get; private set; } = string.Empty;
    public string ContactSecondaire { get; private set; } = string.Empty;
    public DateTime? DateEnregistrement { get; private set; }
    public StatutContribuable Statut { get; private set; } // Enum type
    public TypeContribuable TypeContribuable { get; private set; } // Enum type pour distinguer personne physique et morale
    public string NumeroRegistreCommerce { get; private set; } = string.Empty; // Pour les personnes morales
    public string Email { get; private set; } = string.Empty; // Pour permettre la connexion
    public Guid? UtilisateurId { get; private set; } // Référence à l'utilisateur dans le système d'authentification
    public Guid? AgentFiscalId { get; private set; } // Référence à l'agent fiscal responsable
    public virtual AgentFiscal? AgentFiscal { get; private set; } // Propriété de navigation
    
    // Nouvelles propriétés pour les personnes morales
    public string NIF { get; private set; } = string.Empty; // Numéro d'Identification Fiscale
    public DateTime? DateCreationEntreprise { get; private set; } // Date de création de l'entreprise
    public string SecteurActivite { get; private set; } = string.Empty; // Secteur d'activité
    public decimal? CapitalSocial { get; private set; } // Capital social
    public string FormeJuridique { get; private set; } = string.Empty; // Forme juridique (SARL, SA, etc.)
    public string RepresentantLegal { get; private set; } = string.Empty; // Nom du représentant légal

    private Contribuable() { }

    public Contribuable(Guid id, string nom, string prenom, DateTime? dateNaissance, string numeroIdentification, string nomCommercial, string adresse, string localisationGPS, string typeActivite, string contactPrincipal, string contactSecondaire, DateTime? dateEnregistrement, StatutContribuable statut, Genre genre, TypeContribuable typeContribuable, string numeroRegistreCommerce, string email, Guid? utilisateurId, Guid? agentFiscalId = null, string nif = "", DateTime? dateCreationEntreprise = null, string secteurActivite = "", decimal? capitalSocial = null, string formeJuridique = "", string representantLegal = "")
    {
        Id = id;
        Nom = nom;
        Prenom = prenom;
        DateNaissance = dateNaissance;
        NumeroIdentification = numeroIdentification;
        NomCommercial = nomCommercial;
        Adresse = adresse;
        LocalisationGPS = localisationGPS;
        TypeActivite = typeActivite;
        ContactPrincipal = contactPrincipal;
        ContactSecondaire = contactSecondaire;
        DateEnregistrement = dateEnregistrement;
        Statut = statut;
        Genre = genre;
        TypeContribuable = typeContribuable;
        NumeroRegistreCommerce = numeroRegistreCommerce;
        Email = email;
        UtilisateurId = utilisateurId;
        AgentFiscalId = agentFiscalId;
        NIF = nif;
        DateCreationEntreprise = dateCreationEntreprise;
        SecteurActivite = secteurActivite;
        CapitalSocial = capitalSocial;
        FormeJuridique = formeJuridique;
        RepresentantLegal = representantLegal;
        QueueDomainEvent(new ContribuableCreated{Contribuable = this});
    }

    public static Contribuable Create(string nom, string prenom, DateTime? dateNaissance, string numeroIdentification, string nomCommercial, string adresse, string localisationGPS, string typeActivite, string contactPrincipal, string contactSecondaire, DateTime? dateEnregistrement, StatutContribuable statut, Genre genre, TypeContribuable typeContribuable, string numeroRegistreCommerce, string email, Guid? utilisateurId, Guid? agentFiscalId = null, string nif = "", DateTime? dateCreationEntreprise = null, string secteurActivite = "", decimal? capitalSocial = null, string formeJuridique = "", string representantLegal = "")
    {
        return new Contribuable(Guid.NewGuid(), nom, prenom, dateNaissance, numeroIdentification, nomCommercial, adresse, localisationGPS, typeActivite, contactPrincipal, contactSecondaire, dateEnregistrement, statut, genre, typeContribuable, numeroRegistreCommerce, email, utilisateurId, agentFiscalId, nif, dateCreationEntreprise, secteurActivite, capitalSocial, formeJuridique, representantLegal);
    }

    public Contribuable Update(string nom, string prenom, DateTime? dateNaissance, string numeroIdentification, string nomCommercial, string adresse, string localisationGPS, string typeActivite, string contactPrincipal, string contactSecondaire, DateTime? dateEnregistrement, StatutContribuable statut, Genre genre, TypeContribuable typeContribuable, string numeroRegistreCommerce, string email, Guid? utilisateurId, Guid? agentFiscalId = null, string nif = "", DateTime? dateCreationEntreprise = null, string secteurActivite = "", decimal? capitalSocial = null, string formeJuridique = "", string representantLegal = "")
    {
        if(nom != Nom){
            Nom = nom;
        }
        if(prenom != Prenom){
            Prenom = prenom;
        }
        if(dateNaissance != DateNaissance){
            DateNaissance = dateNaissance;
        }
        if(numeroIdentification != NumeroIdentification){
            NumeroIdentification = numeroIdentification;
        }
        if(nomCommercial != NomCommercial){
            NomCommercial = nomCommercial;
        }
        if(adresse != Adresse){
            Adresse = adresse;
        }
        if(localisationGPS != LocalisationGPS){
            LocalisationGPS = localisationGPS;
        }
        if(typeActivite != TypeActivite){
            TypeActivite = typeActivite;
        }
        if(contactPrincipal != ContactPrincipal){
            ContactPrincipal = contactPrincipal;
        }
        if(contactSecondaire != ContactSecondaire){
            ContactSecondaire = contactSecondaire;
        }
        if(dateEnregistrement != DateEnregistrement){
            DateEnregistrement = dateEnregistrement;
        }
        if(statut != Statut){
            Statut = statut;
        }
        if(genre != Genre){
            Genre = genre;
        }
        if(typeContribuable != TypeContribuable){
            TypeContribuable = typeContribuable;
        }
        if(numeroRegistreCommerce != NumeroRegistreCommerce){
            NumeroRegistreCommerce = numeroRegistreCommerce;
        }
        if(email != Email){
            Email = email;
        }
        if(utilisateurId != UtilisateurId){
            UtilisateurId = utilisateurId;
        }
        if(agentFiscalId != AgentFiscalId){
            AgentFiscalId = agentFiscalId;
        }
        // Mise à jour des nouvelles propriétés pour les personnes morales
        if(nif != NIF){
            NIF = nif;
        }
        if(dateCreationEntreprise != DateCreationEntreprise){
            DateCreationEntreprise = dateCreationEntreprise;
        }
        if(secteurActivite != SecteurActivite){
            SecteurActivite = secteurActivite;
        }
        if(capitalSocial != CapitalSocial){
            CapitalSocial = capitalSocial;
        }
        if(formeJuridique != FormeJuridique){
            FormeJuridique = formeJuridique;
        }
        if(representantLegal != RepresentantLegal){
            RepresentantLegal = representantLegal;
        }
        QueueDomainEvent(new ContribuableUpdated{Contribuable = this});
        return this;
    }

    public void AssocierUtilisateur(Guid utilisateurId)
    {
        if (UtilisateurId != utilisateurId)
        {
            UtilisateurId = utilisateurId;
            QueueDomainEvent(new ContribuableUtilisateurAssocie { Contribuable = this });
        }
    }
    
    public void AssocierAgentFiscal(Guid agentFiscalId)
    {
        if (AgentFiscalId != agentFiscalId)
        {
            AgentFiscalId = agentFiscalId;
            QueueDomainEvent(new ContribuableAgentFiscalAssocie { Contribuable = this });
        }
    }
    
    /// <summary>
    /// Dissocie l'utilisateur associé au contribuable
    /// </summary>
    public void DissocierUtilisateur()
    {
        if (UtilisateurId != null)
        {
            var ancienUtilisateurId = UtilisateurId.Value;
            UtilisateurId = null;
            QueueDomainEvent(new ContribuableUtilisateurDissocie
            {
                Contribuable = this,
                UtilisateurId = ancienUtilisateurId
            });
        }
    }
}
