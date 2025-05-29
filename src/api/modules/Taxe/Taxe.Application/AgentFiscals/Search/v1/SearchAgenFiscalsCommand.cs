using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.AgentFiscals.Get.v1;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Search.v1;
public class SearchAgenFiscalsCommand : PaginationFilter, IRequest<PagedList<AgentFiscalResponse>>
{
    public string? Nom { get; set; }
    public string? Prenom { get; set; }
    public string? Identifiant { get; set; }
    public string? LocalisationgPS { get; set; }
    public DateTime DateEmbauche { get; set;}
    public DateTime DateFinFonction { get; set; }
    public StatutAgent Statut { get; set; }
}
