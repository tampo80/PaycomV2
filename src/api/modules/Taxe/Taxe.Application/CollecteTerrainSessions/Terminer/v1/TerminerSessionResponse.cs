using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Terminer.v1;

public record TerminerSessionResponse(Guid Id, DateTime DateFin); 
