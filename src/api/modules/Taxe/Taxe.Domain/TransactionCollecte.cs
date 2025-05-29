using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.TransactionCollecteEvents;
using Shared.Enums;


namespace  PayCom.WebApi.Taxe.Domain;

public class TransactionCollecte : AuditableEntity, IAggregateRoot
{
    public Guid CollecteTerrainSessionId { get; private set; }
    public virtual CollecteTerrainSession Session { get; private set; } = default!;
    
    public Guid EcheanceId { get; private set; }
    public virtual Echeance Echeance { get; private set; } = default!;
    
    public double MontantPercu { get; private set; }
    public ModePaiement ModePaiement { get; private set; }
    public string ReferenceTransaction { get; private set; } = string.Empty;
    public DateTime HorodatageTransaction { get; private set; }
    public string LocalisationGPS { get; private set; } = string.Empty;
    public bool EstSynchronise { get; private set; }
    public string SignatureContribuable { get; private set; } = string.Empty; // Base64
    public string PhotoPreuve { get; private set; } = string.Empty; // URL ou Base64

    private TransactionCollecte() { }

    public TransactionCollecte(Guid id, Guid collecteTerrainSessionId, Guid echeanceId, double montantPercu, 
                              ModePaiement modePaiement, string referenceTransaction, DateTime horodatageTransaction, 
                              string localisationGPS, bool estSynchronise, string signatureContribuable, string photoPreuve)
    {
        Id = id;
        CollecteTerrainSessionId = collecteTerrainSessionId;
        EcheanceId = echeanceId;
        MontantPercu = montantPercu;
        ModePaiement = modePaiement;
        ReferenceTransaction = referenceTransaction;
        HorodatageTransaction = horodatageTransaction;
        LocalisationGPS = localisationGPS;
        EstSynchronise = estSynchronise;
        SignatureContribuable = signatureContribuable;
        PhotoPreuve = photoPreuve;
        
        QueueDomainEvent(new TransactionCollecteCreated { Transaction = this });
    }

    public static TransactionCollecte Create(Guid collecteTerrainSessionId, Guid echeanceId, double montantPercu, 
                                           ModePaiement modePaiement, string referenceTransaction, 
                                           string localisationGPS, string signatureContribuable, string photoPreuve)
    {
        return new TransactionCollecte(
            Guid.NewGuid(), 
            collecteTerrainSessionId, 
            echeanceId, 
            montantPercu, 
            modePaiement, 
            referenceTransaction, 
            DateTime.UtcNow, 
            localisationGPS, 
            false, // Non synchronisé par défaut
            signatureContribuable, 
            photoPreuve
        );
    }

    public TransactionCollecte Update(Guid collecteTerrainSessionId, Guid echeanceId, double montantPercu, 
                                    ModePaiement modePaiement, string referenceTransaction, DateTime horodatageTransaction, 
                                    string localisationGPS, bool estSynchronise, string signatureContribuable, string photoPreuve)
    {
        bool isUpdated = false;

        if (CollecteTerrainSessionId != collecteTerrainSessionId)
        {
            CollecteTerrainSessionId = collecteTerrainSessionId;
            isUpdated = true;
        }

        if (EcheanceId != echeanceId)
        {
            EcheanceId = echeanceId;
            isUpdated = true;
        }

        if (MontantPercu != montantPercu)
        {
            MontantPercu = montantPercu;
            isUpdated = true;
        }

        if (ModePaiement != modePaiement)
        {
            ModePaiement = modePaiement;
            isUpdated = true;
        }

        if (ReferenceTransaction != referenceTransaction)
        {
            ReferenceTransaction = referenceTransaction;
            isUpdated = true;
        }

        if (HorodatageTransaction != horodatageTransaction)
        {
            HorodatageTransaction = horodatageTransaction;
            isUpdated = true;
        }

        if (LocalisationGPS != localisationGPS)
        {
            LocalisationGPS = localisationGPS;
            isUpdated = true;
        }

        if (EstSynchronise != estSynchronise)
        {
            EstSynchronise = estSynchronise;
            isUpdated = true;
        }

        if (SignatureContribuable != signatureContribuable)
        {
            SignatureContribuable = signatureContribuable;
            isUpdated = true;
        }

        if (PhotoPreuve != photoPreuve)
        {
            PhotoPreuve = photoPreuve;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new TransactionCollecteUpdated { Transaction = this });
        }

        return this;
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
} 
