using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Villes.Update.v1;
public record UpdateVilleResponse
{
    public Guid Id { get; init; }
    public string Nom { get; init; }
    public string Description { get; init; }
    public string Code { get; init; }
    public Guid PrefectureId { get; init; }
    public string PrefectureNom { get; init; }
} 
