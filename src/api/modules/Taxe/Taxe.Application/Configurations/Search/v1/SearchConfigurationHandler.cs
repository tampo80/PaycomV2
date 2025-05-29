using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Application.Configurations.Get.v1;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Configurations.Search.v1;
public sealed class SearchConfigurationHandler(
    [FromKeyedServices("taxe:configurations")] IReadRepository<Configuration> repository) :IRequestHandler<SearchConfigurationCommand, PagedList<ConfigurationResponse>>
{
    public async Task<PagedList<ConfigurationResponse>> Handle(SearchConfigurationCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchConfigurationSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<ConfigurationResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
