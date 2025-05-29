using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Echeances.Update.v1;
public record UpdateEcheanceCommand(
    Guid Id,
    DateTime DateEcheance,
    [property: DefaultValue(0.0)]
    decimal MontantDu) : IRequest<UpdateEcheanceResponse>; 
