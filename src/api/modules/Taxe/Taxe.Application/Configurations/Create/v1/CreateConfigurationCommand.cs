using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Configurations.Create.v1;
public record CreateConfigurationCommand(
    [property: DefaultValue("Clé de la configuration")]
    string Cle,
    [property: DefaultValue("Valeur de la configuration")]
    string Valeur,
    [property: DefaultValue("Description de la configuration")]
    string Description) : IRequest<CreateConfigurationResponse>;
