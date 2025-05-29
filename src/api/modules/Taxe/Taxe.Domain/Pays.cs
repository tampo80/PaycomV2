using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PayCom.WebApi.Taxe.Domain;

public class Pays : AuditableEntity, IAggregateRoot
{
    private readonly List<Region> _regions = new();
    public IReadOnlyCollection<Region> Regions => _regions.AsReadOnly();
    
    public string Nom { get; private set; } = string.Empty;
    public string Code { get; private set; } = string.Empty;

    private Pays() { }
    
    public Pays(Guid id, string nom, string code)
    {
        Id = id;
        Nom = nom;
        Code = code;
    }
    
    public static Pays Create(string nom, string code)
    {
        return new Pays(Guid.NewGuid(), nom, code);
    }
    
    public Pays Update(string nom, string code)
    {
        bool isUpdated = false;
        
        if (Nom != nom)
        {
            Nom = nom;
            isUpdated = true;
        }
        
        if (Code != code)
        {
            Code = code;
            isUpdated = true;
        }
        
        return this;
    }

    public void AjouterRegion(Region region)
    {
        if (!_regions.Any(r => r.Id == region.Id))
        {
            _regions.Add(region);
        }
    }

    public int NombreRegions => _regions.Count;

    public int NombreCommunes => _regions.Sum(r => r.NombreCommunes);

    public Commune? RechercherCommune(string nom)
    {
        return _regions
            .SelectMany(r => r.Communes)
            .FirstOrDefault(c => c.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase));
    }

    public Region? RechercherRegion(string nom)
    {
        return _regions
            .FirstOrDefault(r => r.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase));
    }

    public StatistiquesAdministratives ObtenirStatistiques()
    {
        var communes = _regions.SelectMany(r => r.Communes).ToList();
        
        return new StatistiquesAdministratives
        {
            NombreRegions = NombreRegions,
            NombreCommunes = communes.Count,
            NombreCommunesUrbaines = communes.Count(c => c.Type == Enums.TypeCommune.Urbaine),
            NombreCommunesRurales = communes.Count(c => c.Type == Enums.TypeCommune.Rurale),
            NombreArrondissements = communes.Count(c => c.Type == Enums.TypeCommune.Arrondissement),
            NombreMunicipalites = communes.Count(c => c.Type == Enums.TypeCommune.Municipalite),
            NombreCommunesSpeciales = communes.Count(c => c.Type == Enums.TypeCommune.SpecialStatus)
        };
    }
    
    public override string ToString() => $"{Code} - {Nom}";
} 
