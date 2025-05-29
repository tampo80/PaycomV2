using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Application.Communes.Search.v1;
using PayCom.WebApi.Taxe.Application.Configurations.Get.v1;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Configurations.Search.v1;
public class SearchConfigurationSpecs : EntitiesByPaginationFilterSpec<Configuration, ConfigurationResponse>
{
    public SearchConfigurationSpecs(SearchConfigurationCommand command) : base(command)
        => Query.OrderBy(c => c.Cle, !command.HasOrderBy())
            .Where(c => c.Cle.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
