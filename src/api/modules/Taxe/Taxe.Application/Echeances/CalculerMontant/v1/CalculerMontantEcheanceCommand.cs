using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Echeances.CalculerMontant.v1;
public record CalculerMontantEcheanceCommand(
    [property: DefaultValue("ID de l'échéance")]
    Guid EcheanceId) : IRequest<CalculerMontantEcheanceResponse>; 
