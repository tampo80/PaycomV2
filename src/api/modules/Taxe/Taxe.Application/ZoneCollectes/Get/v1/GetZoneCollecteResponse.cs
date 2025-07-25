using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.ZoneCollectes.Get.v1;

public record GetZoneCollecteResponse(
    Guid Id,
    string Nom,
    string Description,
    Guid CommuneId,
    string Code,
    string? CommuneNom = null,
    string? DelimitationGeoJSON = null); 
