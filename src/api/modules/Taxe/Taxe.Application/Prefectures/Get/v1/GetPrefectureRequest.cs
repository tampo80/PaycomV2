using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Get.v1;
public record GetPrefectureRequest(Guid Id) : IRequest<PrefectureResponse>;
