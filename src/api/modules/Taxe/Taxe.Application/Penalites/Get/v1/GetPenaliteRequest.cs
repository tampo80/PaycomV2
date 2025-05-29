using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Penalites.Get.v1;
public record GetPenaliteRequest(Guid Id) : IRequest<PenaliteResponse>;
