using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Application.ObligationFiscales.Get.v1;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Search.v1;

public sealed class SearchObligationFiscalesHandler(
    [FromKeyedServices("taxe:obligations-fiscales")] IReadRepository<ObligationFiscale> repository) 
    : IRequestHandler<SearchObligationFiscalesCommand, PagedList<ObligationFiscaleResponse>>
{
    public async Task<PagedList<ObligationFiscaleResponse>> Handle(SearchObligationFiscalesCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchObligationFiscalesSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken);
        var totalCount = await repository.CountAsync(spec, cancellationToken);

        var responses = items.Select(o => new ObligationFiscaleResponse(
            o.Id,
            o.ContribuableId,
            o.TypeTaxeId,
            o.DateDebut,
            o.DateFin,
            0, // MontantCalcule - à implémenter selon la logique métier
            null, // MontantPersonnalise - à implémenter selon la logique métier
            o.EstActif
        )).ToList();

        return new PagedList<ObligationFiscaleResponse>(responses, request.PageNumber, request.PageSize, totalCount);
    }
} 