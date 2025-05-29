using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Application.Communes.Get.v1;
using PayCom.WebApi.Taxe.Domain;
namespace PayCom.WebApi.Taxe.Application.Communes.Search.v1;
public sealed class SearchCommuneHandler(
    [FromKeyedServices("taxe:communes")] IReadRepository<Commune> repository) : IRequestHandler<SearchCommuneCommand, PagedList<CommuneResponse>>
{
    public async Task<PagedList<CommuneResponse>> Handle(SearchCommuneCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchCommuneSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<CommuneResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
