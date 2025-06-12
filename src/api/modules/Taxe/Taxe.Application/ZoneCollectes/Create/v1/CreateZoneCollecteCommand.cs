using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.ZoneCollectes.Create.v1;
public record CreateZoneCollecteCommand(
    [property: DefaultValue("Nom de la zone de collecte")]
    string Nom,
    [property: DefaultValue("Description de la zone")]
    string Description,
    Guid CommuneId,
    [property: DefaultValue("")]
    string DelimitationGeoJSON = "") : IRequest<CreateZoneCollecteResponse>; 
