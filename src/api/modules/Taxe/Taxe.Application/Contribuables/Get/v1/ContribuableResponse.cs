using Shared.Enums;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Contribuables.Get.v1;
public record ContribuableResponse(
    Guid? Id,
    string Nom,
    string Prenom,
    DateTime? DateNaissance,
    Genre Genre,
    string NumeroIdentification,
    string NomCommercial,
    string Adresse,
    string LocalisationGPS,
    string TypeActivite,
    string ContactPrincipal,
    string ContactSecondaire,
    DateTime? DateEnregistrement,
    StatutContribuable Statut,
    TypeContribuable TypeContribuable,
    string NumeroRegistreCommerce,
    string Email,
    Guid? UtilisateurId,
    Guid? AgentFiscalId,
    string NIF,
    DateTime? DateCreationEntreprise,
    string SecteurActivite,
    decimal? CapitalSocial,
    string FormeJuridique,
    string RepresentantLegal
    );
