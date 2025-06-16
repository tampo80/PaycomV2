using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.PenaliteEvents;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Domain;

public class Penalite : AuditableEntity, IAggregateRoot
{
    public Guid EcheanceId { get; private set; }
    public virtual Echeance Echeance { get; private set; } = default!;
    
    public Guid ObligationFiscaleId { get; private set; }
    public virtual ObligationFiscale ObligationFiscale { get; private set; } = default!;
    
    public TypePenalite TypePenalite { get; private set; }
    public decimal MontantPenalite { get; private set; }
    public decimal TauxPenalite { get; private set; }
    public DateTime DateCalcul { get; private set; }
    public DateTime DateApplication { get; private set; }
    public int NombreJoursRetard { get; private set; }
    public string? Motif { get; private set; }
    public string? Observation { get; private set; }
    public StatutPenalite Statut { get; private set; }
    public bool EstAnnulee { get; private set; }
    public DateTime? DateAnnulation { get; private set; }
    public string? MotifAnnulation { get; private set; }
    public Guid? AnnuleePar { get; private set; }

    private Penalite() { }

    public Penalite(Guid id, Guid echeanceId, Guid obligationFiscaleId, TypePenalite typePenalite, 
                   decimal montantPenalite, decimal tauxPenalite, DateTime dateCalcul, 
                   DateTime dateApplication, int nombreJoursRetard, string? motif, string? observation)
    {
        Id = id;
        EcheanceId = echeanceId;
        ObligationFiscaleId = obligationFiscaleId;
        TypePenalite = typePenalite;
        MontantPenalite = montantPenalite;
        TauxPenalite = tauxPenalite;
        DateCalcul = dateCalcul;
        DateApplication = dateApplication;
        NombreJoursRetard = nombreJoursRetard;
        Motif = motif;
        Observation = observation;
        Statut = StatutPenalite.Calculee;
        EstAnnulee = false;
        
        QueueDomainEvent(new PenaliteCalculee { Penalite = this });
    }

    public static Penalite Create(Guid echeanceId, Guid obligationFiscaleId, TypePenalite typePenalite, 
                                 decimal montantPenalite, decimal tauxPenalite, DateTime dateCalcul, 
                                 DateTime dateApplication, int nombreJoursRetard, string? motif = null, 
                                 string? observation = null)
    {
        return new Penalite(Guid.NewGuid(), echeanceId, obligationFiscaleId, typePenalite, 
                           montantPenalite, tauxPenalite, dateCalcul, dateApplication, 
                           nombreJoursRetard, motif, observation);
    }

    public void Appliquer()
    {
        if (EstAnnulee)
            throw new DomainException("Impossible d'appliquer une pénalité annulée");
            
        if (Statut == StatutPenalite.Appliquee)
            throw new DomainException("La pénalité est déjà appliquée");

        Statut = StatutPenalite.Appliquee;
        DateApplication = DateTime.UtcNow;
        
        QueueDomainEvent(new PenaliteAppliquee { Penalite = this });
    }

    public void Annuler(string motifAnnulation, Guid annuleePar)
    {
        if (EstAnnulee)
            throw new DomainException("La pénalité est déjà annulée");

        EstAnnulee = true;
        DateAnnulation = DateTime.UtcNow;
        MotifAnnulation = motifAnnulation;
        AnnuleePar = annuleePar;
        Statut = StatutPenalite.Annulee;
        
        QueueDomainEvent(new PenaliteAnnulee { Penalite = this });
    }

    public void ModifierMontant(decimal nouveauMontant, string? observation = null)
    {
        if (EstAnnulee)
            throw new DomainException("Impossible de modifier une pénalité annulée");
            
        if (Statut == StatutPenalite.Appliquee)
            throw new DomainException("Impossible de modifier une pénalité déjà appliquée");

        var ancienMontant = MontantPenalite;
        MontantPenalite = nouveauMontant;
        
        if (!string.IsNullOrWhiteSpace(observation))
        {
            Observation = string.IsNullOrWhiteSpace(Observation) 
                ? observation 
                : $"{Observation}\n{DateTime.UtcNow:dd/MM/yyyy HH:mm}: {observation}";
        }
        
        QueueDomainEvent(new PenaliteModifiee { Penalite = this, AncienMontant = ancienMontant });
    }

    public void Modifier(decimal montantPenalite, decimal tauxPenalite, DateTime dateApplication, 
                        int nombreJoursRetard, string? motif = null, string? observation = null)
    {
        if (EstAnnulee)
            throw new DomainException("Impossible de modifier une pénalité annulée");
            
        if (Statut == StatutPenalite.Appliquee)
            throw new DomainException("Impossible de modifier une pénalité déjà appliquée");

        var ancienMontant = MontantPenalite;
        MontantPenalite = montantPenalite;
        TauxPenalite = tauxPenalite;
        DateApplication = dateApplication;
        NombreJoursRetard = nombreJoursRetard;
        Motif = motif;
        
        if (!string.IsNullOrWhiteSpace(observation))
        {
            Observation = string.IsNullOrWhiteSpace(Observation) 
                ? observation 
                : $"{Observation}\n{DateTime.UtcNow:dd/MM/yyyy HH:mm}: {observation}";
        }
        
        QueueDomainEvent(new PenaliteModifiee { Penalite = this, AncienMontant = ancienMontant });
    }

    public static decimal CalculerMontantPenalite(decimal montantBase, decimal tauxPenalite, int nombreJours, TypePenalite typePenalite)
    {
        return typePenalite switch
        {
            TypePenalite.Retard => montantBase * (tauxPenalite / 100) * (nombreJours / 30m), // Pénalité mensuelle
            TypePenalite.Majoration => montantBase * (tauxPenalite / 100), // Majoration fixe
            TypePenalite.Amende => tauxPenalite, // Montant fixe
            _ => 0m
        };
    }
}

