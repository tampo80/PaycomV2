using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Contribuables.Get.v1;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Contribuables.Search.v1;
public class SearchContribuableCommand : PaginationFilter, IRequest<PagedList<ContribuableResponse>>
{
    public Guid Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public DateTime DateNaissance { get; set; }
    public Genre Genre { get; set; }
    public string NumeroIdentification { get; set; }
    public string NomCommercial { get; set; }
    public string Adresse { get; set; }
    public string LocalisationGPS { get; set; }
    public string TypeActivite { get; set; }
    public string ContactPrincipal { get; set; }
    public string ContactSecond { get; set; }
    public DateTime DateEnregistrement { get; set; }
    public StatutContribuable Statut { get; set; }
}
