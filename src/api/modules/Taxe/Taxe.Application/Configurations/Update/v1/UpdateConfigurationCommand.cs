using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Configurations.Update.v1;
public record UpdateConfigurationCommand(
    Guid Id,
    string Cle,
    string Valeur,
    string Description) : IRequest<UpdateConfigurationResponse>;
