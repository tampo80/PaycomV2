using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.Update.v1;
public record UpdateEcheancierCommand(
    Guid Id,
    DateTime DateEcheance,
    double MontantDu,
    double MontantPaye) : IRequest<UpdateEcheancierResponse>;
