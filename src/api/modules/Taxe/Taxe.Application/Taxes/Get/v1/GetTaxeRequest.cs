using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Taxes.Get.v1;
public class GetTaxeRequest : IRequest<TaxeResponse>
{
    public Guid Id { get; set; }
    public int AnneeImposition { get; set; }
    public double Taux { get; set; }
    public DateTime DateEcheance { get; set; }
    public double MontantDu { get; set; }
    public double MontantPaye { get; set; }
    public double SoldeRestant { get; set; }
    public double PrixUnitaire { get; set; }
    public string UniteMesure { get; set; }
    public string Caracteristiques { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateDerniereModification { get; set; }
}
