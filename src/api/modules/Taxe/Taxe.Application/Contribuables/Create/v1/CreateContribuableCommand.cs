using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Contribuables.Create.v1;
public record CreateContribuableCommand(
    [property: DefaultValue("Nom du contribuable")]
    string Nom,
    [property: DefaultValue("Prenom du contribuable")]
    string Prenom,
    DateTime? DateNaissance,
    [property: DefaultValue("Numero d'identification du contribuble")]
    string NumeroIdentification,
    
    [property: DefaultValue(Genre.Homme)]
    Genre Genre,
    [property: DefaultValue("Nom commerciale du contribuable")]
    string NomCommercial,
    [property: DefaultValue("Adresse du contribuable")]
    string Adresse,
    [property: DefaultValue("LocalisationGPS du contribuable")]
    string LocalisationGPS,
    [property: DefaultValue("TypeActivite du contribuable")]
    string TypeActivite,
    [property: DefaultValue("ContactPrincipal du contribuable")]
    string ContactPrincipal,
    [property: DefaultValue("ContactSecondaire du contribuable")]
    string ContactSecondaire, 
    //[property: DefaultValue(DateTime.Now)]
    DateTime? DateEnregistrement,
    [property: DefaultValue(StatutContribuable.Actif)]
    StatutContribuable Statut,
    [property: DefaultValue(TypeContribuable.PersonnePhysique)]
    TypeContribuable TypeContribuable,
    [property: DefaultValue("Numéro registre commerce")]
    string NumeroRegistreCommerce,
    [property: DefaultValue("email@example.com")]
    string Email,
    Guid? UtilisateurId,
    Guid? AgentFiscalId,
    [property: DefaultValue("Numéro d'Identification Fiscale")]
    string NIF,
    DateTime? DateCreationEntreprise,
    [property: DefaultValue("Secteur d'activité")]
    string SecteurActivite,
    decimal? CapitalSocial,
    [property: DefaultValue("Forme juridique (SARL, SA, etc.)")]
    string FormeJuridique,
    [property: DefaultValue("Nom du représentant légal")]
    string RepresentantLegal) : IRequest<CreateContribuableResponse>;
