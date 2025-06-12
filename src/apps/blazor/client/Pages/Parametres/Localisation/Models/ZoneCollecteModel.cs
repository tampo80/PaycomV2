namespace PayCom.Blazor.Client.Pages.Parametres.Localisation.Models;

public class ZoneCollecteModel
{
    public Guid Id { get; set; } 
    public string Nom { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid CommuneId { get; set; }

    public string CommuneNom { get; set; } = string.Empty;
    public string DelimitationGeoJSON { get; set; } = string.Empty;
}
