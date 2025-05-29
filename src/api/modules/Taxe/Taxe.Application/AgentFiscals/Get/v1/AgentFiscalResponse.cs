using Shared.Enums;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Get.v1;
public record AgentFiscalResponse(
    Guid? Id,
    string Nom,
    string Prenom,
    string Identifiant,
    string LocalisationGPS,
    DateTime DateEmbauche,
    DateTime? DateFinFonction,
    StatutAgent Statut,
    string Email,
    string Telephone,
    bool EstCollecteurTerrain,
    double SoldePortefeuille,
    Guid? UtilisateurId);
