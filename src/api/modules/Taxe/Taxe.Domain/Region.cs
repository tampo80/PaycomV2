using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using System.Collections.Generic;
using System.Linq;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain.Events.RegionEvents;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayCom.WebApi.Taxe.Domain;

public class Region : AuditableEntity, IAggregateRoot
{
    private readonly List<Commune> _communes = new();
    public IReadOnlyCollection<Commune> Communes => _communes.AsReadOnly();
    
    public string Nom { get; private set; } = string.Empty;
    public string Code { get; private set; } = string.Empty;
    public Guid? ChefLieuId { get; private set; }

    private Region() { }

    public Region(Guid id, string nom, string code)
    {
        Id = id;
        Nom = nom;
        Code = code;
        
        QueueDomainEvent(new RegionCreated(
            Id,
            Nom,
            Code));
    }

    public static Region Create(string nom, string code)
    {
        return new Region(Guid.NewGuid(), nom, code);
    }

    public Region Update(string nom, string code)
    {
        bool isUpdated = false;
        
        if (nom != Nom)
        {
            Nom = nom;
            isUpdated = true;
        }

        if (code != Code)
        {
            Code = code;
            isUpdated = true;
        }
        
        if (isUpdated)
        {
            QueueDomainEvent(new RegionUpdated(
                Id,
                Nom,
                Code));
        }
        
        return this;
    }

    public void AjouterCommune(Commune commune)
    {
        if (!_communes.Any(c => c.Id == commune.Id))
        {
            _communes.Add(commune);
        }
    }
    
    public void DefinirChefLieu(Commune? commune)
    {
        var ancienChefLieuId = ChefLieuId;
        ChefLieuId = commune?.Id;
        
        if (commune != null)
        {
            commune.DefinirTypeChefLieu(TypeChefLieu.ChefLieuRegion);
        }
        
        QueueDomainEvent(new Events.RegionEvents.ChefLieuChanged(
            "Region",
            Id,
            ancienChefLieuId,
            ChefLieuId));
    }

    public int NombreCommunes => _communes.Count;
    
    [NotMapped]
    public IEnumerable<Commune> CommunesUrbaines => _communes.Where(c => c.Type == TypeCommune.Urbaine);
    
    [NotMapped]
    public IEnumerable<Commune> CommunesRurales => _communes.Where(c => c.Type == TypeCommune.Rurale);
    
    [NotMapped]
    public IEnumerable<Commune> CommunesStandard => _communes.Where(c => c.Type == TypeCommune.Standard);
    
    [NotMapped]
    public IEnumerable<Commune> Arrondissements => _communes.Where(c => c.Type == TypeCommune.Arrondissement);
    
    [NotMapped]
    public IEnumerable<Commune> Municipalites => _communes.Where(c => c.Type == TypeCommune.Municipalite);
    
    [NotMapped]
    public IEnumerable<Commune> CommunesSpeciales => _communes.Where(c => c.Type == TypeCommune.SpecialStatus);
    
    public override string ToString() => $"{Code} - {Nom}";
}
