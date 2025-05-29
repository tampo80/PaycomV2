using FSH.Framework.Core.Identity.Users.Dtos;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Operations.Update.v1;
public record UpdateOperationCommand(
    Guid? Id,
    DateTime Date,
    string Description,
    UserDetail Utilisateur) : IRequest<UpdateOperationResponse>;
