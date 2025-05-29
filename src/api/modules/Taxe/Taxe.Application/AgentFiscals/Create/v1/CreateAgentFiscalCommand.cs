using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Create.v1;
public record CreateAgentFiscalCommand(
    [property: DefaultValue("")] string Nom,
    [property: DefaultValue("")] string Prenom,
    [property: DefaultValue("")] string Identifiant,
    [property: DefaultValue("")] string LocalisationGPS,
    DateTime DateEmbauche,
    DateTime? DateFinFonction,
    StatutAgent Statut,
    [property: DefaultValue("")] string Email,
    [property: DefaultValue("")] string Telephone,
    [property: DefaultValue(false)] bool EstCollecteurTerrain,
    [property: DefaultValue(0.0)] double SoldePortefeuille,
    Guid? UtilisateurId) : IRequest<CreateAgentFiscalResponse>;
