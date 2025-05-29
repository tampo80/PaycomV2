using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.TaxeEvents;

namespace PayCom.WebApi.Taxe.Domain;

public class Taxe : AuditableEntity, IAggregateRoot
{
    //public TypeTaxe Type { get; private set; } // Enum type
    public int AnneeImposition { get; private set; }
    public double Taux { get; private set; }
    public DateTime DateEcheance { get; private set; }
    public double MontantDu { get; private set; }
    public double MontantPaye { get; private set; }
    public double SoldeRestant { get; private set; }
    public double PrixUnitaire { get; private set; }
    public string UniteMesure { get; private set; } = string.Empty;
    public string Caracteristiques { get; private set; } = string.Empty;
    public DateTime DateCreation { get; private set; }
    public DateTime DateDerniereModification { get; private set; }

    private Taxe() { }

    public Taxe(Guid id, int anneeImposition, double taux, DateTime dateEcheance, double montantDu, double montantPaye, double soldeRestant, double prixUnitaire, string uniteMesure, string caracteristiques, DateTime dateCreation, DateTime dateDerniereModification)
    {
        Id = id;
        AnneeImposition = anneeImposition;
        Taux = taux;
        DateEcheance = dateEcheance;
        MontantDu = montantDu;
        MontantPaye = montantPaye;
        SoldeRestant = soldeRestant;
        PrixUnitaire = prixUnitaire;
        UniteMesure = uniteMesure;
        Caracteristiques = caracteristiques;
        DateCreation = dateCreation;
        DateDerniereModification = dateDerniereModification;

        QueueDomainEvent(new TaxeCreated{Taxe = this});
    }

    public static Taxe Create(int anneeImposition, double taux, DateTime dateEcheance, double montantDu, double montantPaye, double soldeRestant, double prixUnitaire, string uniteMesure, string caracteristiques, DateTime dateCreation, DateTime dateDerniereModification)
    {
        return new Taxe(Guid.NewGuid(), anneeImposition, taux, dateEcheance, montantDu, montantPaye, soldeRestant, prixUnitaire, uniteMesure, caracteristiques, dateCreation, dateDerniereModification);
    }


    public Taxe Update(int anneeImposition, double taux, DateTime dateEcheance, double montantDu, double montantPaye, double soldeRestant, double prixUnitaire, string uniteMesure, string caracteristiques, DateTime dateCreation, DateTime dateDerniereModification)
    {
        bool isUpdated = false;

        if (AnneeImposition != anneeImposition)
        {
            AnneeImposition = anneeImposition;
            isUpdated = true;
        }

        if (Taux != taux)
        {
            Taux = taux;
            isUpdated = true;
        }

        if (DateEcheance != dateEcheance)
        {
            DateEcheance = dateEcheance;
            isUpdated = true;
        }

        if (MontantDu != montantDu)
        {
            MontantDu = montantDu;
            isUpdated = true;
        }

        if (MontantPaye != montantPaye)
        {
            MontantPaye = montantPaye;
            isUpdated = true;
        }

        if (SoldeRestant != soldeRestant)
        {
            SoldeRestant = soldeRestant;
            isUpdated = true;
        }

        if (PrixUnitaire != prixUnitaire)
        {
            PrixUnitaire = prixUnitaire;
            isUpdated = true;
        }

        if (UniteMesure != uniteMesure)
        {
            UniteMesure = uniteMesure;
            isUpdated = true;
        }

        if (Caracteristiques != caracteristiques)
        {
            Caracteristiques = caracteristiques;
            isUpdated = true;
        }

        if (DateCreation != dateCreation)
        {
            DateCreation = dateCreation;
            isUpdated = true;
        }

        if (DateDerniereModification != dateDerniereModification)
        {
            DateDerniereModification = dateDerniereModification;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new TaxeCreated{Taxe = this});
        }

        return this;
    }
}
