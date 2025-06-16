using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Create.v1;

public record CreateObligationFiscaleCommand(
    [Required] Guid ContribuableId,
    [Required] Guid TypeTaxeId,
    [Required] Guid CommuneId,
    [Required] DateTime DateDebut,
    DateTime? DateFin = null,
    string? ReferenceProprieteBien = null,
    string? LocalisationGPS = null,
    [property: DefaultValue(0.0)]
    decimal? MontantPersonnalise = null,
    [property: DefaultValue(true)]
    bool EstActif = true) : IRequest<CreateObligationFiscaleResponse>; 
