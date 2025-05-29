using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Echeanciers.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.Search.v1;
public class SearchEcheancierHandler(
    [FromKeyedServices("taxe:echeanciers")] IReadRepository<Echeancier> repository)
    : IRequestHandler<SearchEcheancierCommand, PagedList<EcheancierResponse>>
{
    public async Task<PagedList<EcheancierResponse>> Handle(SearchEcheancierCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchEcheancierSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<EcheancierResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
