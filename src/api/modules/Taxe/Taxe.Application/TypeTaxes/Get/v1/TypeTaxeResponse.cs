using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Get.v1;

public class TypeTaxeResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Nom { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool EstPeriodique { get; set; }
    public string FrequencePaiement { get; set; } = string.Empty;
    public decimal MontantBase { get; set; }
    public string UniteMesure { get; set; } = string.Empty;
    public bool NecessiteInspection { get; set; }
} 
