using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Identity.Users.Dtos;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Operations.Create.v1;
public record CreateOperationCommand(
    DateTime Date,
    [property: DefaultValue("Description de l'operation")]
    string Description,
    UserDetail Utilisateur) : IRequest<CreateOperationResponse>;
