using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Configurations.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Configurations.Search.v1;
public class SearchConfigurationCommand : PaginationFilter, IRequest<PagedList<ConfigurationResponse>>
{
    public string Cle { get; set; }
    public string Valeur { get; set; }
    public string Description { get; set; }
}
