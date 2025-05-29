using FSH.Framework.Core.Identity.Users.Dtos;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Operations.Get.v1;
public record GetOperationRequest(Guid Id) : IRequest<OperationResponse>;
