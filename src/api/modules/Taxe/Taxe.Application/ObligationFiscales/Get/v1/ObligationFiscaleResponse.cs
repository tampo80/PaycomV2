using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Get.v1;

public record ObligationFiscaleResponse(
    Guid Id,
    Guid ContribuableId,
    Guid TypeTaxeId,
    Guid CommuneId,
    DateTime DateDebut,
    DateTime? DateFin,
    string ReferenceProprieteBien,
    string LocalisationGPS,
    decimal MontantCalcule,
    decimal? MontantPersonnalise,
    bool EstActif,
    DateTime Created,
    DateTime LastModified,
    // Propriétés de navigation pour l'affichage
    string? ContribuableNom = null,
    string? TypeTaxeNom = null,
    string? CommuneNom = null,
    int NombreEcheances = 0); 
