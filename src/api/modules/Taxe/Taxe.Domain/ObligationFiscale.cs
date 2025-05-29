using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.ObligationFiscaleEvents;


namespace  PayCom.WebApi.Taxe.Domain;

public class ObligationFiscale : AuditableEntity, IAggregateRoot
{
    public Guid ContribuableId { get; private set; }
    public virtual Contribuable Contribuable { get; private set; } = default!;
    
    public Guid TypeTaxeId { get; private set; }
    public virtual TypeTaxe TypeTaxe { get; private set; } = default!;
    
    public Guid CommuneId { get; private set; }
    public virtual Commune Commune { get; private set; } = default!;
    
    public DateTime DateDebut { get; private set; }
    public DateTime? DateFin { get; private set; }
    public string ReferenceProprieteBien { get; private set; } = string.Empty;
    public string LocalisationGPS { get; private set; } = string.Empty;
    public bool EstActif { get; private set; }

    // Navigation property pour les échéances
    private readonly List<Echeance> _echeances = new();
    public virtual IReadOnlyCollection<Echeance> Echeances => _echeances.AsReadOnly();

    private ObligationFiscale() { }

    public ObligationFiscale(Guid id, Guid contribuableId, Guid typeTaxeId, Guid communeId, DateTime dateDebut, 
                            DateTime? dateFin, string referenceProprieteBien, string localisationGPS, bool estActif)
    {
        Id = id;
        ContribuableId = contribuableId;
        TypeTaxeId = typeTaxeId;
        CommuneId = communeId;
        DateDebut = dateDebut;
        DateFin = dateFin;
        ReferenceProprieteBien = referenceProprieteBien;
        LocalisationGPS = localisationGPS;
        EstActif = estActif;
        
        QueueDomainEvent(new ObligationFiscaleCreated { ObligationFiscale = this });
    }

    public static ObligationFiscale Create(Guid contribuableId, Guid typeTaxeId, Guid communeId, DateTime dateDebut, 
                                         DateTime? dateFin, string referenceProprieteBien, string localisationGPS, bool estActif)
    {
        return new ObligationFiscale(Guid.NewGuid(), contribuableId, typeTaxeId, communeId, dateDebut, 
                                    dateFin, referenceProprieteBien, localisationGPS, estActif);
    }

    public ObligationFiscale Update(Guid contribuableId, Guid typeTaxeId, Guid communeId, DateTime dateDebut, 
                                  DateTime? dateFin, string referenceProprieteBien, string localisationGPS, bool estActif)
    {
        bool isUpdated = false;

        if (ContribuableId != contribuableId)
        {
            ContribuableId = contribuableId;
            isUpdated = true;
        }

        if (TypeTaxeId != typeTaxeId)
        {
            TypeTaxeId = typeTaxeId;
            isUpdated = true;
        }

        if (CommuneId != communeId)
        {
            CommuneId = communeId;
            isUpdated = true;
        }

        if (DateDebut != dateDebut)
        {
            DateDebut = dateDebut;
            isUpdated = true;
        }

        if (DateFin != dateFin)
        {
            DateFin = dateFin;
            isUpdated = true;
        }

        if (ReferenceProprieteBien != referenceProprieteBien)
        {
            ReferenceProprieteBien = referenceProprieteBien;
            isUpdated = true;
        }

        if (LocalisationGPS != localisationGPS)
        {
            LocalisationGPS = localisationGPS;
            isUpdated = true;
        }

        if (EstActif != estActif)
        {
            EstActif = estActif;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new ObligationFiscaleUpdated { ObligationFiscale = this });
        }

        return this;
    }

    public void Desactiver()
    {
        if (EstActif)
        {
            EstActif = false;
            DateFin = DateTime.UtcNow;
            QueueDomainEvent(new ObligationFiscaleDesactivee { ObligationFiscale = this });
        }
    }

    public void Reactiver()
    {
        if (!EstActif)
        {
            EstActif = true;
            DateFin = null;
            QueueDomainEvent(new ObligationFiscaleReactivee { ObligationFiscale = this });
        }
    }

    public void AjouterEcheance(Echeance echeance)
    {
        _echeances.Add(echeance);
    }
} 
