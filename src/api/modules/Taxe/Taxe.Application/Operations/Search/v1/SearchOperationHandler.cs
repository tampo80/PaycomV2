using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Operations.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Operations.Search.v1;
public class SearchOperationHandler(
    [FromKeyedServices("taxe:operations")] IReadRepository<Operation> repository)
: IRequestHandler<SearchOperationCommand, PagedList<OperationResponse>>
{
    public async Task<PagedList<OperationResponse>> Handle(SearchOperationCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchOperationSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<OperationResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
