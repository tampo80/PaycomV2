using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.PaiementTerrainEvents;
using Shared.Enums;


namespace  PayCom.WebApi.Taxe.Domain;

public class PaiementTerrain : AuditableEntity, IAggregateRoot
{
    public Guid AgentFiscalId { get; private set; }
    public virtual AgentFiscal Agent { get; private set; } = default!;
    
    public Guid ContribuableId { get; private set; }
    public virtual Contribuable Contribuable { get; private set; } = default!;
    
    public Guid EcheanceId { get; private set; }
    public virtual Echeance Echeance { get; private set; } = default!;
    
    public DateTime DatePaiement { get; private set; }
    public double Montant { get; private set; }
    public ModePaiement ModePaiement { get; private set; }
    public string ReferenceRecue { get; private set; } = string.Empty;
    public string NumeroQuittance { get; private set; } = string.Empty;
    public string PhotoPreuve { get; private set; } = string.Empty; // URL vers la photo
    public string SignatureContribuable { get; private set; } = string.Empty; // Base64 ou URL
    public string GeoLocalisation { get; private set; } = string.Empty; // Coordonnées GPS
    public bool EstSynchronise { get; private set; }
    public StatutPaiementTerrain Statut { get; private set; }
    
    private PaiementTerrain() { }
    
    public PaiementTerrain(
        Guid id, 
        Guid agentFiscalId, 
        Guid contribuableId, 
        Guid echeanceId, 
        DateTime datePaiement, 
        double montant,
        ModePaiement modePaiement,
        string referenceRecue,
        string numeroQuittance,
        string photoPreuve,
        string signatureContribuable,
        string geoLocalisation,
        bool estSynchronise,
        StatutPaiementTerrain statut)
    {
        Id = id;
        AgentFiscalId = agentFiscalId;
        ContribuableId = contribuableId;
        EcheanceId = echeanceId;
        DatePaiement = datePaiement;
        Montant = montant;
        ModePaiement = modePaiement;
        ReferenceRecue = referenceRecue;
        NumeroQuittance = numeroQuittance;
        PhotoPreuve = photoPreuve;
        SignatureContribuable = signatureContribuable;
        GeoLocalisation = geoLocalisation;
        EstSynchronise = estSynchronise;
        Statut = statut;
        
        QueueDomainEvent(new PaiementTerrainCreated { PaiementTerrain = this });
    }
    
    public static PaiementTerrain Create(
        Guid agentFiscalId, 
        Guid contribuableId, 
        Guid echeanceId, 
        DateTime datePaiement, 
        double montant,
        ModePaiement modePaiement,
        string referenceRecue,
        string numeroQuittance,
        string photoPreuve,
        string signatureContribuable,
        string geoLocalisation,
        bool estSynchronise,
        StatutPaiementTerrain statut)
    {
        return new PaiementTerrain(
            Guid.NewGuid(),
            agentFiscalId,
            contribuableId,
            echeanceId,
            datePaiement,
            montant,
            modePaiement,
            referenceRecue,
            numeroQuittance,
            photoPreuve,
            signatureContribuable,
            geoLocalisation,
            estSynchronise,
            statut
        );
    }
    
    public void Synchroniser()
    {
        if (!EstSynchronise)
        {
            EstSynchronise = true;
            QueueDomainEvent(new PaiementTerrainSynchronise { PaiementTerrain = this });
        }
    }
    
    public void ChangerStatut(StatutPaiementTerrain nouveauStatut)
    {
        if (Statut != nouveauStatut)
        {
            var ancienStatut = Statut;
            Statut = nouveauStatut;
            QueueDomainEvent(new PaiementTerrainStatutChange { 
                PaiementTerrain = this, 
                AncienStatut = ancienStatut, 
                NouveauStatut = nouveauStatut 
            });
        }
    }
} 
