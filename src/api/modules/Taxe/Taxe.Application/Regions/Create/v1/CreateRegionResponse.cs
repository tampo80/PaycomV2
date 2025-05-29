using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.Regions.Create.v1;

public record CreateRegionResponse(
    Guid Id,
    string Nom,
    string Code,
    Guid? ChefLieuId,
    string? NomChefLieu);
