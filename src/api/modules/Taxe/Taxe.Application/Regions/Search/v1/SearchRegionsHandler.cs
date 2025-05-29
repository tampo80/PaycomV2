using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Regions.Search.v1;
public sealed class SearchRegionsHandler(
    [FromKeyedServices("taxe:regions")] IReadRepository<Region> repository,
    ILogger<SearchRegionsHandler> logger)
    : IRequestHandler<SearchRegionsCommand, PagedList<RegionResponse>>
{
    public async Task<PagedList<RegionResponse>> Handle(SearchRegionsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var spec = new SearchRegionSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken);
        var totalCount = await repository.CountAsync(spec, cancellationToken);
        logger.LogInformation("Searched regions with {Count} results", items.Count);
        return new PagedList<RegionResponse>(items, request.PageNumber, request.PageSize, totalCount);
    }
}
