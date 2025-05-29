using FSH.Framework.Core.Identity.Users.Dtos;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Operations.Get.v1;
public record OperationResponse(
    Guid? Id,
    DateTime Date,
    string Description,
    UserDetail Utilisateur);
