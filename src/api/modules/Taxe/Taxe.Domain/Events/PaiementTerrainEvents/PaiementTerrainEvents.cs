using FSH.Framework.Core.Domain.Events;
using Shared.Enums;

namespace  PayCom.WebApi.Taxe.Domain.Events.PaiementTerrainEvents;

public record PaiementTerrainCreated : DomainEvent
{
    public PaiementTerrain PaiementTerrain { get; init; } = default!;
}

public record PaiementTerrainSynchronise : DomainEvent
{
    public PaiementTerrain PaiementTerrain { get; init; } = default!;
}

public record PaiementTerrainStatutChange : DomainEvent
{
    public PaiementTerrain PaiementTerrain { get; init; } = default!;
    public StatutPaiementTerrain AncienStatut { get; init; }
    public StatutPaiementTerrain NouveauStatut { get; init; }
}

public record PaiementTerrainValide : DomainEvent
{
    public PaiementTerrain PaiementTerrain { get; init; } = default!;
    public string ValidePar { get; init; } = string.Empty;
}

public record PaiementTerrainRejete : DomainEvent
{
    public PaiementTerrain PaiementTerrain { get; init; } = default!;
    public string RaisonRejet { get; init; } = string.Empty;
    public string RejetePar { get; init; } = string.Empty;
} 
