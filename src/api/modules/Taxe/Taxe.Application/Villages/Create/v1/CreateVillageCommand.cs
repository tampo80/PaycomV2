using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Villages.Create.v1;
public record CreateVillageCommand(
    [property: DefaultValue("Nom")] string Nom,
    [property: DefaultValue("Code")] string Code) : IRequest<CreateVillageResponse>;
