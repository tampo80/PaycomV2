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
        builder.Property(x => x.Description);
        builder.Property(x => x.DateApplication);
        builder.Property(x => x.Montant);
        builder.Property(x => x.Type);
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

