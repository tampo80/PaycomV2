namespace PayCom.WebApi.Taxe.Domain;

public class StatistiquesAdministratives
{
    public int NombreRegions { get; set; }
    public int NombreCommunes { get; set; }
    public int NombreCommunesUrbaines { get; set; }
    public int NombreCommunesRurales { get; set; }
    public int NombreArrondissements { get; set; }
    public int NombreMunicipalites { get; set; }
    public int NombreCommunesSpeciales { get; set; }

    public override string ToString()
    {
        return $"Statistiques administratives:\n" +
               $"- Régions: {NombreRegions}\n" +
               $"- Communes: {NombreCommunes}\n" +
               $"  - Standard: {NombreCommunes - (NombreCommunesUrbaines + NombreCommunesRurales + NombreArrondissements + NombreMunicipalites + NombreCommunesSpeciales)}\n" +
               $"  - Urbaines: {NombreCommunesUrbaines}\n" +
               $"  - Rurales: {NombreCommunesRurales}\n" +
               $"  - Arrondissements: {NombreArrondissements}\n" +
               $"  - Municipalités: {NombreMunicipalites}\n" +
               $"  - Statut spécial: {NombreCommunesSpeciales}";
    }
}
