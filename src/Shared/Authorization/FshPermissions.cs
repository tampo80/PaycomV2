using System.Collections.ObjectModel;

namespace PayCom.Shared.Authorization;

public static class FshPermissions
{
    private static readonly FshPermission[] AllPermissions =
    [     
        //tenants
        new("View Tenants", FshActions.View, FshResources.Tenants, IsRoot: true),
        new("Create Tenants", FshActions.Create, FshResources.Tenants, IsRoot: true),
        new("Update Tenants", FshActions.Update, FshResources.Tenants, IsRoot: true),
        new("Upgrade Tenant Subscription", FshActions.UpgradeSubscription, FshResources.Tenants, IsRoot: true),

        //identity
        new("View Users", FshActions.View, FshResources.Users),
        new("Search Users", FshActions.Search, FshResources.Users),
        new("Create Users", FshActions.Create, FshResources.Users),
        new("Update Users", FshActions.Update, FshResources.Users),
        new("Delete Users", FshActions.Delete, FshResources.Users),
        new("Export Users", FshActions.Export, FshResources.Users),
        new("View UserRoles", FshActions.View, FshResources.UserRoles),
        new("Update UserRoles", FshActions.Update, FshResources.UserRoles),
        new("View Roles", FshActions.View, FshResources.Roles),
        new("Create Roles", FshActions.Create, FshResources.Roles),
        new("Update Roles", FshActions.Update, FshResources.Roles),
        new("Delete Roles", FshActions.Delete, FshResources.Roles),
        new("View RoleClaims", FshActions.View, FshResources.RoleClaims),
        new("Update RoleClaims", FshActions.Update, FshResources.RoleClaims),
        
        //products
        new("View Products", FshActions.View, FshResources.Products, IsBasic: true),
        new("Search Products", FshActions.Search, FshResources.Products, IsBasic: true),
        new("Create Products", FshActions.Create, FshResources.Products),
        new("Update Products", FshActions.Update, FshResources.Products),
        new("Delete Products", FshActions.Delete, FshResources.Products),
        new("Export Products", FshActions.Export, FshResources.Products),

        //brands
        new("View Brands", FshActions.View, FshResources.Brands, IsBasic: true),
        new("Search Brands", FshActions.Search, FshResources.Brands, IsBasic: true),
        new("Create Brands", FshActions.Create, FshResources.Brands),
        new("Update Brands", FshActions.Update, FshResources.Brands),
        new("Delete Brands", FshActions.Delete, FshResources.Brands),
        new("Export Brands", FshActions.Export, FshResources.Brands),

        //todos
        new("View Todos", FshActions.View, FshResources.Todos, IsBasic: true),
        new("Search Todos", FshActions.Search, FshResources.Todos, IsBasic: true),
        new("Create Todos", FshActions.Create, FshResources.Todos),
        new("Update Todos", FshActions.Update, FshResources.Todos),
        new("Delete Todos", FshActions.Delete, FshResources.Todos),
        new("Export Todos", FshActions.Export, FshResources.Todos),

         new("View Hangfire", FshActions.View, FshResources.Hangfire),
         new("View Dashboard", FshActions.View, FshResources.Dashboard),

        //audit
        new("View Audit Trails", FshActions.View, FshResources.AuditTrails),
        
        //Agentfiscal
        new("View Agentfiscal", FshActions.View, FshResources.AgentFiscals),
        new("Search Agentfiscal", FshActions.Search, FshResources.AgentFiscals),
        new("Read Agentfiscal", FshActions.Read, FshResources.AgentFiscals),
        new("Create Agentfiscal", FshActions.Create, FshResources.AgentFiscals),
        new("Update Agentfiscal", FshActions.Update, FshResources.AgentFiscals),
        new("Delete Agentfiscal", FshActions.Delete, FshResources.AgentFiscals),
        new("Export Agentfiscal", FshActions.Export, FshResources.AgentFiscals),
        new("Manage Agentfiscal Users", FshActions.Manage, FshResources.AgentFiscals),
        
        //Contribuables - harmonisées avec l'API
        new("Read Contribuables", FshActions.Read, FshResources.Contribuables),
        new("Create Contribuables", FshActions.Create, FshResources.Contribuables),
        new("Update Contribuables", FshActions.Update, FshResources.Contribuables),
        new("Delete Contribuables", FshActions.Delete, FshResources.Contribuables),
        new("Export Contribuables", FshActions.Export, FshResources.Contribuables),
        new("Manage Contribuables", FshActions.Manage, FshResources.Contribuables),
        // Garde de la rétrocompatibilité pour les anciens éléments d'interface
        new("View Contribuables", FshActions.View, FshResources.Contribuables),
        new("Search Contribuables", FshActions.Search, FshResources.Contribuables),
        
        //Communes
        new("View Communes", FshActions.View, FshResources.Communes),
        new("Search Communes", FshActions.Search, FshResources.Communes),
        new("Read Communes", FshActions.Read, FshResources.Communes),
        new("Create Communes", FshActions.Create, FshResources.Communes),
        new("Update Communes", FshActions.Update, FshResources.Communes),
        new("Delete Communes", FshActions.Delete, FshResources.Communes),
        new("Export Communes", FshActions.Export, FshResources.Communes),
        
        //Regions
        new("View Regions", FshActions.View, FshResources.Regions),
        new("Search Regions", FshActions.Search, FshResources.Regions),
        new("Read Regions", FshActions.Read, FshResources.Regions),
        new("Create Regions", FshActions.Create, FshResources.Regions),
        new("Update Regions", FshActions.Update, FshResources.Regions),
        new("Delete Regions", FshActions.Delete, FshResources.Regions),
        new("Export Regions", FshActions.Export, FshResources.Regions),
        
        //ObligationsFiscales
        new("View ObligationsFiscales", FshActions.View, FshResources.ObligationsFiscales),
        new("Search ObligationsFiscales", FshActions.Search, FshResources.ObligationsFiscales),
        new("Read ObligationsFiscales", FshActions.Read, FshResources.ObligationsFiscales),
        new("Create ObligationsFiscales", FshActions.Create, FshResources.ObligationsFiscales),
        new("Update ObligationsFiscales", FshActions.Update, FshResources.ObligationsFiscales),
        new("Delete ObligationsFiscales", FshActions.Delete, FshResources.ObligationsFiscales),
        new("Manage ObligationsFiscales", FshActions.Manage, FshResources.ObligationsFiscales),
        
        //TypesTaxe
        new("View TypesTaxe", FshActions.View, FshResources.TypesTaxe),
        new("Search TypesTaxe", FshActions.Search, FshResources.TypesTaxe),
        new("Read TypesTaxe", FshActions.Read, FshResources.TypesTaxe),
        new("Create TypesTaxe", FshActions.Create, FshResources.TypesTaxe),
        new("Update TypesTaxe", FshActions.Update, FshResources.TypesTaxe),
        new("Delete TypesTaxe", FshActions.Delete, FshResources.TypesTaxe),
        new("Export TypesTaxe", FshActions.Export, FshResources.TypesTaxe),
        
        //Taxes
        new("View Taxes", FshActions.View, FshResources.Taxes),
        new("Search Taxes", FshActions.Search, FshResources.Taxes),
        new("Read Taxes", FshActions.Read, FshResources.Taxes),
        new("Create Taxes", FshActions.Create, FshResources.Taxes),
        new("Update Taxes", FshActions.Update, FshResources.Taxes),
        new("Delete Taxes", FshActions.Delete, FshResources.Taxes),
        new("Export Taxes", FshActions.Export, FshResources.Taxes),
        
        //AdministrateurFiscal
        new("View AdminFiscal", FshActions.View, FshResources.AdminFiscal),
        new("Read AdminFiscal", FshActions.Read, FshResources.AdminFiscal),
        new("Manage Fiscalite", FshActions.Manage, FshResources.AdminFiscal),
        new("Validate Declarations", FshActions.Valider, FshResources.AdminFiscal),
        new("Manage Anomalies", FshActions.GererAnomalies, FshResources.AdminFiscal),
    ];

    public static IReadOnlyList<FshPermission> All { get; } = new ReadOnlyCollection<FshPermission>(AllPermissions);
    public static IReadOnlyList<FshPermission> Root { get; } = new ReadOnlyCollection<FshPermission>(AllPermissions.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<FshPermission> Admin { get; } = new ReadOnlyCollection<FshPermission>(AllPermissions.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<FshPermission> Basic { get; } = new ReadOnlyCollection<FshPermission>(AllPermissions.Where(p => p.IsBasic).ToArray());
    
    // Permissions spécifiques pour l'administrateur fiscal
    public static IReadOnlyList<FshPermission> AdministrateurFiscal { get; } = new ReadOnlyCollection<FshPermission>(AllPermissions.Where(p => 
        p.Resource == FshResources.AdminFiscal ||
        p.Resource == FshResources.Contribuables ||
        p.Resource == FshResources.ObligationsFiscales ||
        p.Resource == FshResources.Taxes ||
        p.Resource == FshResources.TypesTaxe ||
        (p.Resource == FshResources.AgentFiscals && 
            (p.Action == FshActions.View || 
             p.Action == FshActions.Search || 
             p.Action == FshActions.Read ||
             p.Action == FshActions.Create || 
             p.Action == FshActions.Update || 
             p.Action == FshActions.Delete || 
             p.Action == FshActions.Export ||
             p.Action == FshActions.Manage)) ||
        (p.Resource == FshResources.Dashboard && p.Action == FshActions.View)
    ).ToArray());
    
    // Permissions spécifiques pour le contribuable
    public static IReadOnlyList<FshPermission> Contribuable { get; } = new ReadOnlyCollection<FshPermission>(AllPermissions.Where(p => 
        (p.Resource == FshResources.Contribuables && 
            (p.Action == FshActions.View || 
             p.Action == FshActions.Search || 
             p.Action == FshActions.Read ||
             p.Action == FshActions.Update)) ||
        p.Resource == FshResources.ObligationsFiscales ||
        (p.Resource == FshResources.Taxes && (p.Action == FshActions.View || p.Action == FshActions.Read)) ||
        (p.Resource == FshResources.TypesTaxe && 
            (p.Action == FshActions.View || 
             p.Action == FshActions.Search ||
             p.Action == FshActions.Read)) ||
        (p.Resource == FshResources.Dashboard && p.Action == FshActions.View)
    ).ToArray());
    
    // Permissions spécifiques pour l'agent fiscal
    public static IReadOnlyList<FshPermission> AgentFiscal { get; } = new ReadOnlyCollection<FshPermission>(AllPermissions.Where(p => 
        p.Resource == FshResources.Contribuables ||
        p.Resource == FshResources.ObligationsFiscales ||
        p.Resource == FshResources.Taxes ||
        (p.Resource == FshResources.AgentFiscals && 
            (p.Action == FshActions.View || 
             p.Action == FshActions.Search ||
             p.Action == FshActions.Read)) ||
        (p.Resource == FshResources.TypesTaxe && 
            (p.Action == FshActions.View || 
             p.Action == FshActions.Search ||
             p.Action == FshActions.Read)) ||
        (p.Resource == FshResources.Communes && 
            (p.Action == FshActions.View || 
             p.Action == FshActions.Search ||
             p.Action == FshActions.Read)) ||
        (p.Resource == FshResources.Regions && 
            (p.Action == FshActions.View || 
             p.Action == FshActions.Search ||
             p.Action == FshActions.Read)) ||
        (p.Resource == FshResources.Dashboard && p.Action == FshActions.View)
    ).ToArray());
    
    // Permissions spécifiques pour le rôle Basic étendu
    public static IReadOnlyList<FshPermission> BasicRole { get; } = new ReadOnlyCollection<FshPermission>(AllPermissions.Where(p => 
        p.IsBasic || 
        (p.Resource == FshResources.Dashboard && p.Action == FshActions.View)
    ).ToArray());
}

public record FshPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource)
    {
        return $"Permissions.{resource}.{action}";
    }
}


