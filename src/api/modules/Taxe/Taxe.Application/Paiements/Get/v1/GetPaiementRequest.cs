using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Paiements.Get.v1;
public record GetPaiementRequest(Guid Id) : IRequest<PaiementResponse>;
