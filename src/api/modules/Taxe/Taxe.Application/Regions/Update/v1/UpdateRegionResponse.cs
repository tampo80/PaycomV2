using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.Regions.Update.v1;

public record UpdateRegionResponse(
    Guid Id,
    string Nom,
    string Code,
    Guid? ChefLieuId,
    string? NomChefLieu);
