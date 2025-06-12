using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Paging;
using MediatR;
using PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Get.v1;

namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Search.v1;

public class SearchCollecteTerrainSessionsCommand : PaginationFilter, IRequest<PagedList<CollecteTerrainSessionResponse>>
{
    public string? SearchTerm { get; set; }
    public DateTime? DateDebut { get; set; }
    public DateTime? DateFin { get; set; }
    public Guid? AgentFiscalId { get; set; }
    public Guid? ZoneCollecteId { get; set; }
    public Guid? CommuneId { get; set; }
    public string? Statut { get; set; }
    
    public SearchCollecteTerrainSessionsCommand()
    {
    }
    
    public SearchCollecteTerrainSessionsCommand(
        int pageNumber = 1, 
        int pageSize = 10, 
        string? sortBy = null, 
        string? searchTerm = null,
        DateTime? dateDebut = null,
        DateTime? dateFin = null,
        Guid? agentFiscalId = null,
        Guid? zoneCollecteId = null,
        Guid? communeId = null,
        string? statut = null)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        OrderBy = sortBy != null ? new[] { sortBy } : null;
        SearchTerm = searchTerm;
        DateDebut = dateDebut;
        DateFin = dateFin;
        AgentFiscalId = agentFiscalId;
        ZoneCollecteId = zoneCollecteId;
        CommuneId = communeId;
        Statut = statut;
    }
} 
