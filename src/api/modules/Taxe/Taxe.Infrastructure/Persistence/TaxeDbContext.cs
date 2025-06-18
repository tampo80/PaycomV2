using Finbuckle.MultiTenant.Abstractions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using FSH.Framework.Infrastructure.Tenant;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PayCom.WebApi.Taxe.Domain;
using Shared.Constants;


namespace PayCom.WebApi.Taxe.Infrastructure.Persistence;

public sealed class TaxeDbContext:FshDbContext
{
    public TaxeDbContext(IMultiTenantContextAccessor<FshTenantInfo> multiTenantContextAccessor, DbContextOptions<TaxeDbContext> options, IPublisher publisher, IOptions<DatabaseOptions> settings)
    : base(multiTenantContextAccessor, options, publisher, settings)
    { }
    
    
    public DbSet<Configuration> Configurations { get; set; }
    public DbSet<AgentFiscal> AgentsFiscaux { get; set; }
    public DbSet<Ville> Villes { get; set; }
    public DbSet<Contribuable> Contribuables { get; set; }

    public DbSet<Region> Regions { get; set; }
    public DbSet<Prefecture> Prefectures { get; set; }
    public DbSet<Village> Villages { get; set; }
    public DbSet<Penalite> Penalites { get; set; }
    public DbSet<Paiement> Paiements { get; set; }
    public DbSet<PaiementTerrain> PaiementTerrains { get; set; }
    public DbSet<Operation> Operations { get; set; }
    public DbSet<TransactionPaiement> TransactionPaiements { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Commune> Communes { get; set; }
    public DbSet<Domain.Taxe> Taxes { get; set; }
    public DbSet<TypeTaxe> TypesTaxe { get; set; }
    public DbSet<ObligationFiscale> ObligationsFiscales { get; set; }
    public DbSet<Echeance> Echeances { get; set; }
    public DbSet<CollecteTerrainSession> CollecteTerrainSessions { get; set; }
    public DbSet<TransactionCollecte> TransactionCollectes { get; set; }
    public DbSet<ZoneCollecte> ZonesCollecte { get; set; }
    
    
   
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaxeDbContext).Assembly);
        modelBuilder.HasDefaultSchema(SchemaNames.Taxe);
    }
    
}
