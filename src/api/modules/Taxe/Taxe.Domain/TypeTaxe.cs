using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.TypeTaxeEvents;
using Shared.Enums;


namespace  PayCom.WebApi.Taxe.Domain;

public class TypeTaxe : AuditableEntity, IAggregateRoot
{
    public string Code { get; private set; } = string.Empty;
    public string Nom { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public bool EstPeriodique { get; private set; }
    public FrequencePaiement FrequencePaiement { get; private set; }
    public double TauxBase { get; private set; }
    public string UniteMesure { get; private set; } = string.Empty;
    public bool NecessiteInspection { get; private set; }

    private TypeTaxe() { }

    public TypeTaxe(Guid id, string code, string nom, string description, bool estPeriodique, FrequencePaiement frequencePaiement, 
                   double tauxBase, string uniteMesure, bool necessiteInspection)
    {
        Id = id;
        Code = code;
        Nom = nom;
        Description = description;
        EstPeriodique = estPeriodique;
        FrequencePaiement = frequencePaiement;
        TauxBase = tauxBase;
        UniteMesure = uniteMesure;
        NecessiteInspection = necessiteInspection;

        QueueDomainEvent(new TypeTaxeCreated { TypeTaxe = this });
    }

    public static TypeTaxe Create(string code, string nom, string description, bool estPeriodique, FrequencePaiement frequencePaiement, 
                                 double tauxBase, string uniteMesure, bool necessiteInspection)
    {
        return new TypeTaxe(Guid.NewGuid(), code, nom, description, estPeriodique, frequencePaiement, tauxBase, uniteMesure, necessiteInspection);
    }

    public TypeTaxe Update(string code, string nom, string description, bool estPeriodique, FrequencePaiement frequencePaiement, 
                          double tauxBase, string uniteMesure, bool necessiteInspection)
    {
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

        if (TauxBase != tauxBase)
        {
            TauxBase = tauxBase;
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
} 
