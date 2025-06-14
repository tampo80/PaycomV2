using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.TypeTaxeEvents;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Domain;

public class TypeTaxe : AuditableEntity, IAggregateRoot
{
    public string Code { get; private set; } = string.Empty;
    public string Nom { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public bool EstPeriodique { get; private set; }
    public FrequencePaiement FrequencePaiement { get; private set; }
    public double MontantBase { get; private set; }
    public UniteMesure UniteMesure { get; private set; }
    public bool NecessiteInspection { get; private set; }
    
    

    private TypeTaxe() { }

    public TypeTaxe(Guid id, string code, string nom, string description, bool estPeriodique, FrequencePaiement frequencePaiement,
                   double montantBase, UniteMesure uniteMesure, bool necessiteInspection)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(code))
            throw new DomainException("Le code du type de taxe est obligatoire.");
        if (string.IsNullOrWhiteSpace(nom))
            throw new DomainException("Le nom du type de taxe est obligatoire.");
        if (montantBase < 0)
            throw new DomainException("Le montant de base ne peut pas être négatif.");
            
        Id = id;
        Code = code;
        Nom = nom;
        Description = description;
        EstPeriodique = estPeriodique;
        FrequencePaiement = frequencePaiement;
        MontantBase = montantBase;
        UniteMesure = uniteMesure;
        NecessiteInspection = necessiteInspection;

        QueueDomainEvent(new TypeTaxeCreated { TypeTaxe = this });
    }

    public static TypeTaxe Create(string code, string nom, string description, bool estPeriodique, FrequencePaiement frequencePaiement,
                                 double montantBase, UniteMesure uniteMesure, bool necessiteInspection)
    {
        return new TypeTaxe(Guid.NewGuid(), code, nom, description, estPeriodique, frequencePaiement, montantBase, uniteMesure, necessiteInspection);
    }

    public TypeTaxe Update(string code, string nom, string description, bool estPeriodique, FrequencePaiement frequencePaiement,
                          double montantBase, UniteMesure uniteMesure, bool necessiteInspection)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(code))
            throw new DomainException("Le code du type de taxe est obligatoire.");
        if (string.IsNullOrWhiteSpace(nom))
            throw new DomainException("Le nom du type de taxe est obligatoire.");
        if (montantBase < 0)
            throw new DomainException("Le montant de base ne peut pas être négatif.");
            
        bool isUpdated = false;

        if (Code != code)
        {
            Code = code;
            isUpdated = true;
        }

        if (Nom != nom)
        {
            Nom = nom;
            isUpdated = true;
        }

        if (Description != description)
        {
            Description = description;
            isUpdated = true;
        }

        if (EstPeriodique != estPeriodique)
        {
            EstPeriodique = estPeriodique;
            isUpdated = true;
        }

        if (FrequencePaiement != frequencePaiement)
        {
            FrequencePaiement = frequencePaiement;
            isUpdated = true;
        }

        if (MontantBase != montantBase)
        {
            MontantBase = montantBase;
            isUpdated = true;
        }

        if (UniteMesure != uniteMesure)
        {
            UniteMesure = uniteMesure;
            isUpdated = true;
        }

        if (NecessiteInspection != necessiteInspection)
        {
            NecessiteInspection = necessiteInspection;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new TypeTaxeUpdated { TypeTaxe = this });
        }

        return this;
    }

    // Méthode pour générer la prochaine date d'échéance en fonction de la fréquence
    public DateTime CalculerProchaineEcheance(DateTime dateReference)
    {
        return FrequencePaiement switch
        {
            FrequencePaiement.Mensuel => dateReference.AddMonths(1),
            FrequencePaiement.Trimestriel => dateReference.AddMonths(3),
            FrequencePaiement.Semestriel => dateReference.AddMonths(6),
            FrequencePaiement.Annuel => dateReference.AddYears(1),
            _ => dateReference.AddYears(1) // Par défaut annuelle
        };
    }
} 
