using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Update.v1;
public sealed record UpdateTypeTaxeCommand(
    Guid Id,
    string Nom,
    string? Description,
    decimal? MontantBase,
    FrequencePaiement FrequencePaiement,
    bool EstPeriodique,
    UniteMesure UniteMesure,
    bool NecessiteInspection) : IRequest<UpdateTypeTaxeResponse>;
