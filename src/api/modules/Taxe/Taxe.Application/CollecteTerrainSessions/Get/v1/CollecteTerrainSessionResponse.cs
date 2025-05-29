using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Get.v1;

public record CollecteTerrainSessionResponse(
    Guid Id,
    DateTime DateDebut,
    DateTime? DateFin,
    string Notes,
    string Statut,
    Guid AgentFiscalId,
    Guid ZoneCollecteId); 
