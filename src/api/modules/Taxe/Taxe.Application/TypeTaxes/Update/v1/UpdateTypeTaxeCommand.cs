using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Update.v1;
public record UpdateTypeTaxeCommand(
    [property: DefaultValue("Id du type de taxe")]
    Guid Id,
    [property: DefaultValue("Nom du type de taxe")]
    string Nom,
    [property: DefaultValue("Description du type de taxe")]
    string Description,
    [property: DefaultValue(0)]
    decimal MontantBase,
   // [property: DefaultValue(FrequencePaiement.Mensuelle)]
    FrequencePaiement FrequencePaiement) : IRequest<UpdateTypeTaxeResponse>; 
