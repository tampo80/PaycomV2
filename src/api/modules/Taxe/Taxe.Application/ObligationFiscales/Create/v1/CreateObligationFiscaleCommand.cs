using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Create.v1;
public record CreateObligationFiscaleCommand(
    Guid ContribuableId,
    Guid TypeTaxeId,
    DateTime DateDebut,
    DateTime? DateFin = null,
    [property: DefaultValue(0.0)]
    decimal? MontantPersonnalise = null) : IRequest<CreateObligationFiscaleResponse>; 
