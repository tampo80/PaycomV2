using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Create.v1;
public record CreateTypeTaxeCommand(
    [property: DefaultValue("Nom du type de taxe")]
    string Nom,
    [property: DefaultValue("Description du type de taxe")]
    string Description,
    [property: DefaultValue(0.0)]
    decimal MontantBase,
    string FrequencePaiement) : IRequest<CreateTypeTaxeResponse>; 
