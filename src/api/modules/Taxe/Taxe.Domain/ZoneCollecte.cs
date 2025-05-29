using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.ZoneCollecteEvents;


namespace  PayCom.WebApi.Taxe.Domain;

public class ZoneCollecte : AuditableEntity, IAggregateRoot
{
    public string Code { get; private set; } = string.Empty;
    public string Nom { get; private set; } = string.Empty;
    public Guid CommuneId { get; private set; }
    public virtual Commune Commune { get; private set; } = default!;
    public string DelimitationGeoJSON { get; private set; } = string.Empty;
    
    // Navigation property
    private readonly List<AgentFiscal> _agentsAssignes = new();
    public virtual IReadOnlyCollection<AgentFiscal> AgentsAssignes => _agentsAssignes.AsReadOnly();

    private ZoneCollecte() { }

    public ZoneCollecte(Guid id, string code, string nom, Guid communeId, string delimitationGeoJSON)
    {
        Id = id;
        Code = code;
        Nom = nom;
        CommuneId = communeId;
        DelimitationGeoJSON = delimitationGeoJSON;
        
        QueueDomainEvent(new ZoneCollecteCreated { ZoneCollecte = this });
    }

    public static ZoneCollecte Create(string code, string nom, Guid communeId, string delimitationGeoJSON)
    {
        return new ZoneCollecte(Guid.NewGuid(), code, nom, communeId, delimitationGeoJSON);
    }

    public ZoneCollecte Update(string code, string nom, Guid communeId, string delimitationGeoJSON)
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

        if (CommuneId != communeId)
        {
            CommuneId = communeId;
            isUpdated = true;
        }

        if (DelimitationGeoJSON != delimitationGeoJSON)
        {
            DelimitationGeoJSON = delimitationGeoJSON;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new ZoneCollecteUpdated { ZoneCollecte = this });
        }

        return this;
    }

    public void AssignerAgent(AgentFiscal agent)
    {
        if (!_agentsAssignes.Contains(agent))
        {
            _agentsAssignes.Add(agent);
            QueueDomainEvent(new AgentAssigneZone { ZoneCollecte = this, AgentFiscal = agent });
        }
    }

    public void DesassignerAgent(AgentFiscal agent)
    {
        if (_agentsAssignes.Contains(agent))
        {
            _agentsAssignes.Remove(agent);
            QueueDomainEvent(new AgentDesassigneZone { ZoneCollecte = this, AgentFiscal = agent });
        }
    }
} 
