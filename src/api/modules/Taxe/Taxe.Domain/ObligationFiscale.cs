using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.ObligationFiscaleEvents;
using PayCom.WebApi.Taxe.Domain.ValueObjects;
using Shared.Enums;


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
        // Validation des entrées
        ValiderDates(dateDebut, dateFin);
        
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
        // Validation des entrées
        ValiderDates(dateDebut, dateFin);
        
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
            
            // Mettre à jour la date de fin si on désactive
            if (!estActif && DateFin == null)
            {
                DateFin = DateTime.UtcNow;
            }
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

    public Echeance AjouterEcheance(int anneeImposition, int periodeImposition, 
                                   DateTime dateEcheance, decimal montantBase, decimal montantPenalites)
    {
        // Vérifier si l'échéance existe déjà
        var echeanceExistante = _echeances
            .FirstOrDefault(e => e.AnneeImposition == anneeImposition && e.PeriodeImposition == periodeImposition);
            
        if (echeanceExistante != null)
            throw new DomainException($"Une échéance existe déjà pour la période {periodeImposition}/{anneeImposition}");
            
        // Créer la nouvelle échéance
        var echeance = Echeance.Create(
            Id, 
            anneeImposition, 
            periodeImposition, 
            dateEcheance, 
            montantBase, 
            montantPenalites, 
            StatutEcheance.EnAttente
        );
        
        _echeances.Add(echeance);
        
        QueueDomainEvent(new EcheanceAjoutee { ObligationFiscale = this, Echeance = echeance });
        
        return echeance;
    }
    
    // Méthode pour générer automatiquement les échéances en fonction du TypeTaxe
    public void GenererEcheances(TypeTaxe typeTaxe, DateTime dateDebut, DateTime? dateFin, decimal montantBase)
    {
        if (!typeTaxe.EstPeriodique)
            throw new DomainException("Impossible de générer des échéances pour une taxe non périodique.");
            
        var finPeriode = dateFin ?? dateDebut.AddYears(1);
        var dateEcheance = dateDebut;
        var montantPenalites = 0m;
        
        while (dateEcheance < finPeriode)
        {
            var periodeImposition = typeTaxe.FrequencePaiement switch
            {
                FrequencePaiement.Mensuel => dateEcheance.Month,
                FrequencePaiement.Trimestriel => ((dateEcheance.Month - 1) / 3) + 1,
                FrequencePaiement.Semestriel => ((dateEcheance.Month - 1) / 6) + 1,
                _ => 1 // Annuelle
            };
            
            try
            {
                AjouterEcheance(
                    dateEcheance.Year,
                    periodeImposition,
                    dateEcheance,
                    montantBase,
                    montantPenalites
                );
            }
            catch (DomainException)
            {
                // Ignorer si l'échéance existe déjà
            }
            
            dateEcheance = typeTaxe.CalculerProchaineEcheance(dateEcheance);
        }
    }
    
    private void ValiderDates(DateTime debut, DateTime? fin)
    {
        if (debut == default)
            throw new DomainException("La date de début est obligatoire.");
            
        if (fin.HasValue && fin.Value <= debut)
            throw new DomainException("La date de fin doit être postérieure à la date de début.");
    }
} 
