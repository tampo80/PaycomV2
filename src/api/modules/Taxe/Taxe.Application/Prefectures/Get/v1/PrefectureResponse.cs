using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.Prefectures.Get.v1;

public record PrefectureResponse(
    Guid Id,
    string Nom,
    string Code);
