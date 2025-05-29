using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Annuler.v1;

public record AnnulerSessionResponse(Guid Id, string Raison); 
