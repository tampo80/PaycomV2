using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Get.v1;

public record ObligationFiscaleResponse(
    Guid Id,
    Guid ContribuableId,
    Guid TypeTaxeId,
    DateTime DateDebut,
    DateTime? DateFin,
    decimal MontantCalcule,
    decimal? MontantPersonnalise,
    bool EstActif); 
