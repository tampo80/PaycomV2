using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayCom.WebApi.Taxe.Domain;


namespace PayCom.WebApi.Taxe.Infrastructure.Persistence.Configurations;


internal sealed class AgentFiscalConfiguration : IEntityTypeConfiguration<AgentFiscal>
{
    public void Configure(EntityTypeBuilder<AgentFiscal> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nom).HasMaxLength(100);
        builder.Property(x => x.Prenom).HasMaxLength(100);
        builder.Property(x => x.Identifiant).HasMaxLength(100);
        builder.Property(x => x.DateEmbauche);
        builder.Property(x => x.DateFinFonction);
        builder.Property(x => x.LocalisationGPS).HasMaxLength(100);
        builder.Property(x => x.Statut);
    }
    
    
}

internal sealed class ObligationFiscaleConfiguration : IEntityTypeConfiguration<ObligationFiscale>
{
    public void Configure(EntityTypeBuilder<ObligationFiscale> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        
        // Configuration des propriétés
        builder.Property(x => x.ContribuableId).IsRequired();
        builder.Property(x => x.TypeTaxeId).IsRequired();
        builder.Property(x => x.CommuneId).IsRequired();
        builder.Property(x => x.DateDebut).IsRequired();
        builder.Property(x => x.DateFin).IsRequired(false);
        builder.Property(x => x.ReferenceProprieteBien)
               .HasMaxLength(200)
               .IsRequired(false)
               .HasDefaultValue("");
        builder.Property(x => x.LocalisationGPS)
               .HasMaxLength(500)
               .IsRequired(false)
               .HasDefaultValue("");
        builder.Property(x => x.EstActif).IsRequired();
        
        // Configuration des relations
        builder.HasOne(x => x.Contribuable)
               .WithMany()
               .HasForeignKey(x => x.ContribuableId)
               .OnDelete(DeleteBehavior.Restrict);
               
        builder.HasOne(x => x.TypeTaxe)
               .WithMany()
               .HasForeignKey(x => x.TypeTaxeId)
               .OnDelete(DeleteBehavior.Restrict);
               
        builder.HasOne(x => x.Commune)
               .WithMany()
               .HasForeignKey(x => x.CommuneId)
               .OnDelete(DeleteBehavior.Restrict);
               
        // Configuration de la relation avec les échéances
        builder.HasMany(x => x.Echeances)
               .WithOne(e => e.ObligationFiscale)
               .HasForeignKey(e => e.ObligationFiscaleId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

internal sealed class EcheanceConfiguration : IEntityTypeConfiguration<Echeance>
{
    public void Configure(EntityTypeBuilder<Echeance> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        
        // Configuration des propriétés
        builder.Property(x => x.ObligationFiscaleId).IsRequired();
        builder.Property(x => x.AnneeImposition).IsRequired();
        builder.Property(x => x.PeriodeImposition).IsRequired();
        builder.Property(x => x.DateEcheance).IsRequired();
        builder.Property(x => x.Statut).IsRequired();
        
        // Configuration des montants avec précision pour PostgreSQL
        builder.Property(x => x.MontantBase)
               .HasColumnType("decimal(18,2)")
               .IsRequired();
               
        builder.Property(x => x.MontantPenalites)
               .HasColumnType("decimal(18,2)")
               .IsRequired();
               
        builder.Property(x => x.MontantTotal)
               .HasColumnType("decimal(18,2)")
               .IsRequired();
        
        // Configuration de la relation avec ObligationFiscale
        builder.HasOne(x => x.ObligationFiscale)
               .WithMany(o => o.Echeances)
               .HasForeignKey(x => x.ObligationFiscaleId)
               .OnDelete(DeleteBehavior.Cascade);
               
        // Configuration de la relation avec les paiements
        builder.HasMany(x => x.Paiements)
               .WithOne(p => p.Echeance)
               .HasForeignKey(p => p.EcheanceId)
               .OnDelete(DeleteBehavior.Restrict);
               
        // Index pour améliorer les performances
        builder.HasIndex(x => new { x.ObligationFiscaleId, x.AnneeImposition, x.PeriodeImposition })
               .IsUnique()
               .HasDatabaseName("IX_Echeance_ObligationFiscale_Periode");
    }
}

internal sealed class TypeTaxeConfiguration : IEntityTypeConfiguration<TypeTaxe>
{
    public void Configure(EntityTypeBuilder<TypeTaxe> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        
        // Configuration des propriétés
        builder.Property(x => x.Nom).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Code).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1000);
        builder.Property(x => x.EstPeriodique).IsRequired();
        builder.Property(x => x.FrequencePaiement).IsRequired();
        builder.Property(x => x.UniteMesure).IsRequired();
        builder.Property(x => x.NecessiteInspection).IsRequired();
        
        // Configuration du montant avec précision pour PostgreSQL
        builder.Property(x => x.MontantBase)
               .HasColumnType("decimal(18,2)")
               .IsRequired(false);
        
        // Index unique sur le code
        builder.HasIndex(x => x.Code)
               .IsUnique()
               .HasDatabaseName("IX_TypeTaxe_Code");
    }
}

internal sealed class CommuneConfiguration : IEntityTypeConfiguration<Commune>
{
    public void Configure(EntityTypeBuilder<Commune> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nom).HasMaxLength(100);
        
        // Configurer la relation avec Region
        builder.HasOne(c => c.Region)
               .WithMany(r => r.Communes)
               .HasForeignKey(c => c.RegionId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

internal sealed class VilleConfiguration : IEntityTypeConfiguration<Ville>
{
    public void Configure(EntityTypeBuilder<Ville> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nom).HasMaxLength(100);
    }
}

internal sealed class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nom).HasMaxLength(100);
        
        // Configurer la relation avec Communes
        builder.HasMany(r => r.Communes)
               .WithOne(c => c.Region)
               .HasForeignKey(c => c.RegionId)
               .OnDelete(DeleteBehavior.Restrict);
               
        // Configurer la relation avec le chef-lieu
        builder.HasOne<Commune>()
               .WithMany()
               .HasForeignKey(r => r.ChefLieuId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.SetNull);
    }
}

internal sealed class PrefectureConfiguration : IEntityTypeConfiguration<Prefecture>
{
    public void Configure(EntityTypeBuilder<Prefecture> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nom).HasMaxLength(100);
    }
}

internal sealed class ContribuableConfiguration : IEntityTypeConfiguration<Contribuable>
{
    public void Configure(EntityTypeBuilder<Contribuable> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nom).HasMaxLength(100);
    }
}

internal sealed class EcheancierConfiguration : IEntityTypeConfiguration<Echeancier>
{
    public void Configure(EntityTypeBuilder<Echeancier> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.DateEcheance);
    }
}

internal sealed class PenaliteConfiguration : IEntityTypeConfiguration<Penalite>
{
    public void Configure(EntityTypeBuilder<Penalite> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        
        // Configuration des propriétés
        builder.Property(x => x.EcheanceId).IsRequired();
        builder.Property(x => x.ObligationFiscaleId).IsRequired();
        builder.Property(x => x.TypePenalite).IsRequired();
        builder.Property(x => x.MontantPenalite)
               .HasColumnType("decimal(18,2)")
               .IsRequired();
        builder.Property(x => x.TauxPenalite)
               .HasColumnType("decimal(5,2)")
               .IsRequired();
        builder.Property(x => x.DateCalcul).IsRequired();
        builder.Property(x => x.DateApplication).IsRequired();
        builder.Property(x => x.NombreJoursRetard).IsRequired();
        builder.Property(x => x.Motif)
               .HasMaxLength(500)
               .IsRequired(false);
        builder.Property(x => x.Observation)
               .HasMaxLength(1000)
               .IsRequired(false);
        builder.Property(x => x.Statut).IsRequired();
        builder.Property(x => x.EstAnnulee).IsRequired();
        builder.Property(x => x.DateAnnulation).IsRequired(false);
        builder.Property(x => x.MotifAnnulation)
               .HasMaxLength(500)
               .IsRequired(false);
        builder.Property(x => x.AnnuleePar).IsRequired(false);
        
        // Configuration des relations
        builder.HasOne(x => x.Echeance)
               .WithMany()
               .HasForeignKey(x => x.EcheanceId)
               .OnDelete(DeleteBehavior.Restrict);
               
        builder.HasOne(x => x.ObligationFiscale)
               .WithMany()
               .HasForeignKey(x => x.ObligationFiscaleId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

internal sealed class PaiementConfiguration : IEntityTypeConfiguration<Paiement>
{
    public void Configure(EntityTypeBuilder<Paiement> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Montant);
        builder.Property(x => x.DateTransaction);
    }
}

internal sealed class OperationConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description);
        builder.Property(x => x.Date);
    }
}

internal sealed class TransactionPaiementConfiguration : IEntityTypeConfiguration<TransactionPaiement>
{
    public void Configure(EntityTypeBuilder<TransactionPaiement> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Montant);
        builder.Property(x => x.Date);
    }
}

internal sealed class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.DateEnvoi);
        builder.Property(x => x.Contenu);
    }
}

internal sealed class VillageConfiguration : IEntityTypeConfiguration<Village>
{
    public void Configure(EntityTypeBuilder<Village> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nom).HasMaxLength(100);
    }
}

