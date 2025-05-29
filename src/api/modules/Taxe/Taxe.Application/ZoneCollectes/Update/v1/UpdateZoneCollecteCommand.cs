using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.ZoneCollectes.Update.v1;
public record UpdateZoneCollecteCommand(
    [property: DefaultValue("ID de la zone")]
    Guid Id,
    [property: DefaultValue("Nom de la zone")]
    string Nom,
    [property: DefaultValue("Description de la zone")]
    string Description,
    [property: DefaultValue("ID de la commune")]
    Guid CommuneId) : IRequest<UpdateZoneCollecteResponse>; 
