using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.Configurations.Get.v1;

public record ConfigurationResponse(
    Guid? Id,
    string Cle,
    string Valeur,
    string Description);
