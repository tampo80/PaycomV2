using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.TransactionCollecteEvents;
using Shared.Enums;
using FSH.Framework.Core.Domain.Events;

namespace PayCom.WebApi.Taxe.Domain;

public class TransactionCollecte : TransactionBase, IAggregateRoot
{
    public Guid EcheanceId { get; private set; }
    public virtual Echeance Echeance { get; private set; } = default!;
    
    public decimal MontantPercu { get; private set; }
    public ModePaiement ModePaiement { get; private set; }
    public string Commentaire { get; private set; } = string.Empty;
    public Guid? CollecteTerrainSessionId { get; private set; }
    public virtual CollecteTerrainSession? CollecteTerrainSession { get; private set; }
    public string ReferenceTransaction { get; private set; } = string.Empty;
    public DateTime HorodatageTransaction { get; private set; }
    public string LocalisationGPS { get; private set; } = string.Empty;
    public bool EstSynchronise { get; private set; }
    public string SignatureContribuable { get; private set; } = string.Empty; // Base64
    public string PhotoPreuve { get; private set; } = string.Empty; // URL ou Base64

    private TransactionCollecte() { }

    public TransactionCollecte(Guid id, DateTime date, decimal montant, string reference, 
                              Guid echeanceId, decimal montantPercu, ModePaiement modePaiement,
                              string commentaire, Guid? agentFiscalId, Guid? collecteTerrainSessionId,
                              StatutTransaction statut = StatutTransaction.EnAttente) 
        : base(id, date, montant, reference, statut, agentFiscalId)
    {
        if (montantPercu <= 0)
            throw new DomainException("Le montant perçu doit être supérieur à zéro.");
            
        EcheanceId = echeanceId;
        MontantPercu = montantPercu > 0 ? montantPercu : montant;
        ModePaiement = modePaiement;
        Commentaire = commentaire;
        CollecteTerrainSessionId = collecteTerrainSessionId;
        HorodatageTransaction = DateTime.UtcNow;
        EstSynchronise = false;
        
        QueueDomainEvent(new TransactionCollecteCreated { TransactionCollecte = this });
    }

    public static TransactionCollecte Create(DateTime date, decimal montant, string reference,
                                            Guid echeanceId, decimal montantPercu, ModePaiement modePaiement,
                                            string commentaire, Guid? agentFiscalId, Guid? collecteTerrainSessionId)
    {
        return new TransactionCollecte(Guid.NewGuid(), date, montant, reference, echeanceId,
                                      montantPercu, modePaiement, commentaire, agentFiscalId, collecteTerrainSessionId);
    }

    public TransactionCollecte Update(decimal montantPercu, string commentaire)
    {
        bool isUpdated = false;

        if (MontantPercu != montantPercu)
        {
            if (montantPercu <= 0)
                throw new DomainException("Le montant perçu doit être supérieur à zéro.");
                
            MontantPercu = montantPercu;
            Montant = montantPercu; // On met à jour aussi la propriété de base
            isUpdated = true;
        }

        if (Commentaire != commentaire)
        {
            Commentaire = commentaire;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new TransactionCollecteUpdated { TransactionCollecte = this });
        }
        
        return this;
    }

    public override void ChangerStatut(StatutTransaction nouveauStatut)
    {
        if (Statut != nouveauStatut)
        {
            var ancienStatut = Statut;
            Statut = nouveauStatut;
            
            QueueDomainEvent(new TransactionCollecteStatutChange {
                TransactionCollecte = this,
                AncienStatut = ancienStatut,
                NouveauStatut = nouveauStatut
            });
            
            // Mise à jour de la session de collecte si nécessaire
            if (nouveauStatut == StatutTransaction.Validee && CollecteTerrainSession != null)
            {
                // Avertissement : ceci peut créer des effets secondaires imprévisibles
                // En pratique, cette mise à jour devrait être gérée via un gestionnaire d'événement
            }
        }
    }

    public void MarquerSynchronisee()
    {
        if (!EstSynchronise)
        {
            EstSynchronise = true;
            QueueDomainEvent(new TransactionSynchronisee { Transaction = this });
        }
    }

    public string GenererRecu()
    {
        // Logique pour générer un reçu formaté
        return $"REÇU DE PAIEMENT\n" +
               $"Transaction: {Id}\n" +
               $"Date: {HorodatageTransaction}\n" +
               $"Montant: {MontantPercu}\n" +
               $"Mode: {ModePaiement}\n" +
               $"Référence: {ReferenceTransaction}";
    }

    public void SetLocalisation(string localisation)
    {
        LocalisationGPS = localisation;
    }

    public void MarquerCommeSynchronise()
    {
        EstSynchronise = true;
        QueueDomainEvent(new TransactionCollecteSynchronisee { TransactionCollecte = this });
    }

    public void AjouterSignature(string signature)
    {
        SignatureContribuable = signature;
    }

    public void AjouterPhotoPreuve(string photoUrl)
    {
        PhotoPreuve = photoUrl;
    }
} 
