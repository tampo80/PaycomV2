using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using Shared.Enums;
namespace PayCom.WebApi.Taxe.Application.Contribuables.Create.v1;

public record CreateContribuableResponse(
    Guid Id,
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
