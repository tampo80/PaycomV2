using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Create.v1;
public sealed record CreateTypeTaxeCommand(
    [property: DefaultValue("Nom du type de taxe")] string Nom,
    [property: DefaultValue("Description du type de taxe")] string? Description = null,
    [property: DefaultValue(0.0)] decimal? MontantBase = 0,
    [property: DefaultValue(FrequencePaiement.Annuel)] FrequencePaiement FrequencePaiement = FrequencePaiement.Annuel,
    [property: DefaultValue(false)] bool EstPeriodique = false,
    [property: DefaultValue(UniteMesure.Unite)] UniteMesure UniteMesure = UniteMesure.Unite,
    [property: DefaultValue(false)] bool NecessiteInspection = false) : IRequest<CreateTypeTaxeResponse>;
