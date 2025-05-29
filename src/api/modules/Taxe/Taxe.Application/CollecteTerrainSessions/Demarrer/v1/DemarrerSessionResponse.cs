using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Demarrer.v1;

public record DemarrerSessionResponse(Guid Id, DateTime DateDebut); 
