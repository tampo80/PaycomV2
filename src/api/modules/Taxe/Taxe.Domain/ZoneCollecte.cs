using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.ZoneCollecteEvents;
using PayCom.WebApi.Taxe.Domain.Exceptions;
using System.Text.Json;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace PayCom.WebApi.Taxe.Domain;

public class ZoneCollecte : AuditableEntity, IAggregateRoot
{
    public string Code { get; private set; } = string.Empty;
    public string Nom { get; private set; } = string.Empty;
    public Guid CommuneId { get; private set; }
    public virtual Commune Commune { get; private set; } = default!;
    
    public string Description { get; private set; }
    public string DelimitationGeoJSON { get; private set; } = string.Empty;
    
    private const int MAX_AGENTS_PAR_ZONE = 5;
    
    // Navigation property
    private readonly List<AgentFiscal> _agentsAssignes = new();
    public virtual IReadOnlyCollection<AgentFiscal> AgentsAssignes => _agentsAssignes.AsReadOnly();

    private ZoneCollecte() { }

    public ZoneCollecte(Guid id, string code, string nom, Guid communeId,string description, string delimitationGeoJSON)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new DomainException("Le code de la zone de collecte ne peut pas être vide");
        
        if (string.IsNullOrWhiteSpace(nom))
            throw new DomainException("Le nom de la zone de collecte ne peut pas être vide");
        
        if (communeId == Guid.Empty)
            throw new DomainException("L'identifiant de la commune est invalide");
        
       

        Id = id;
        Code = code;
        Nom = nom;
        CommuneId = communeId;
        Description = description;
        DelimitationGeoJSON = delimitationGeoJSON;
        
        QueueDomainEvent(new ZoneCollecteCreated { ZoneCollecte = this });
    }

    public static ZoneCollecte Create(string code, string nom, Guid communeId, string description, string delimitationGeoJSON)
    {
        return new ZoneCollecte(Guid.NewGuid(), code, nom, communeId,description, delimitationGeoJSON);
    }

    public ZoneCollecte Update(string code, string nom, Guid communeId,string description, string delimitationGeoJSON)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new DomainException("Le code de la zone de collecte ne peut pas être vide");
        
        if (string.IsNullOrWhiteSpace(nom))
            throw new DomainException("Le nom de la zone de collecte ne peut pas être vide");
        
        if (communeId == Guid.Empty)
            throw new DomainException("L'identifiant de la commune est invalide");
        
       

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

        if (CommuneId != communeId)
        {
            CommuneId = communeId;
            isUpdated = true;
        }
        if (Description != description)
        {
            Description = description;
            isUpdated = true;
        }

        if (DelimitationGeoJSON != delimitationGeoJSON)
        {
            DelimitationGeoJSON = delimitationGeoJSON;
            isUpdated = true;
            QueueDomainEvent(new ZoneCollecteDelimitationUpdated { ZoneCollecte = this });
        }

        if (isUpdated)
        {
            QueueDomainEvent(new ZoneCollecteUpdated { ZoneCollecte = this });
        }

        return this;
    }

    public bool EstAgentAssigne(AgentFiscal agent)
    {
        return _agentsAssignes.Contains(agent);
    }

    public void AssignerAgent(AgentFiscal agent)
    {
        if (agent == null)
            throw new DomainException("L'agent fiscal ne peut pas être null");

        if (EstAgentAssigne(agent))
            throw new DomainException("L'agent est déjà assigné à cette zone");

        if (_agentsAssignes.Count >= MAX_AGENTS_PAR_ZONE)
            throw new DomainException($"Le nombre maximum d'agents ({MAX_AGENTS_PAR_ZONE}) est atteint pour cette zone");

        _agentsAssignes.Add(agent);
        QueueDomainEvent(new AgentAssigneZone { ZoneCollecte = this, AgentFiscal = agent });
    }

    public void DesassignerAgent(AgentFiscal agent)
    {
        if (agent == null)
            throw new DomainException("L'agent fiscal ne peut pas être null");

        if (!EstAgentAssigne(agent))
            throw new DomainException("L'agent n'est pas assigné à cette zone");

        _agentsAssignes.Remove(agent);
        QueueDomainEvent(new AgentDesassigneZone { ZoneCollecte = this, AgentFiscal = agent });
    }

    public void Supprimer()
    {
        if (_agentsAssignes.Any())
            throw new DomainException("Impossible de supprimer une zone avec des agents assignés");

        QueueDomainEvent(new ZoneCollecteDeleted { ZoneCollecte = this });
    }

    private static bool EstGeoJSONValide(string geoJson)
    {
        if (string.IsNullOrWhiteSpace(geoJson))
            return false;

        try
        {
            var jsonDoc = JsonDocument.Parse(geoJson);
            var root = jsonDoc.RootElement;

            // Vérification de la structure GeoJSON
            if (!root.TryGetProperty("type", out var typeElement) || 
                !root.TryGetProperty("coordinates", out _))
                return false;

            var type = typeElement.GetString();
            return type == "Point" || 
                   type == "LineString" || 
                   type == "Polygon" || 
                   type == "MultiPoint" || 
                   type == "MultiLineString" || 
                   type == "MultiPolygon";
        }
        catch
        {
            return false;
        }
    }
} 
