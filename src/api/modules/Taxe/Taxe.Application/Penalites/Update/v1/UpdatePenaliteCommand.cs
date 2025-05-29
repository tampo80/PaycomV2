using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Penalites.Update.v1;
public record UpdatePenaliteCommand(
    Guid Id,
    DateTime DateApplication,
    string Type,
    double Montant,
    string Description,
    Domain.Taxe TaxeConcernee
    ) : IRequest<UpdatePenaliteResponse>;
