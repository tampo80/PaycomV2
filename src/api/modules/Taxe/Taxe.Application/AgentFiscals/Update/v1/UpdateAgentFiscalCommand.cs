using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Update.v1;
public record UpdateAgentFiscalCommand(
    Guid Id,
    string Nom,
    string Prenom,
    string Identifiant,
    string LocalisationGPS,
    DateTime DateEmbauche,
    DateTime DateFinFonction,
    StatutAgent Statut) : IRequest<UpdateAgentFiscalResponse>;
