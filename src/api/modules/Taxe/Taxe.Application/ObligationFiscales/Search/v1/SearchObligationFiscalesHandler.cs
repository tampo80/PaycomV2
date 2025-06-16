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
        
        // Compter le total sans pagination
        var countRequest = new SearchObligationFiscalesCommand
        {
            ContribuableId = request.ContribuableId,
            TypeTaxeId = request.TypeTaxeId,
            CommuneId = request.CommuneId,
            EstActif = request.EstActif,
            DateDebutMin = request.DateDebutMin,
            DateDebutMax = request.DateDebutMax,
            DateFinMin = request.DateFinMin,
            DateFinMax = request.DateFinMax,
            ReferenceProprieteBien = request.ReferenceProprieteBien,
            MontantMin = request.MontantMin,
            MontantMax = request.MontantMax,
            IncludeInactives = request.IncludeInactives,
            PageSize = 0
        };
        var countSpec = new SearchObligationFiscalesSpecs(countRequest);
        var totalCount = await repository.CountAsync(countSpec, cancellationToken);

        var responses = items.Select(o => new ObligationFiscaleResponse(
            o.Id,
            o.ContribuableId,
            o.TypeTaxeId,
            o.CommuneId,
            o.DateDebut,
            o.DateFin,
            o.ReferenceProprieteBien,
            o.LocalisationGPS,
            (decimal)(o.TypeTaxe?.MontantBase ?? 0), // MontantCalcule
            null, // MontantPersonnalise - à implémenter selon la logique métier
            o.EstActif,
            o.Created.DateTime,
            o.LastModified.DateTime,
            o.Contribuable?.Nom,
            o.TypeTaxe?.Nom,
            o.Commune?.Nom,
            o.Echeances?.Count ?? 0
        )).ToList();

        return new PagedList<ObligationFiscaleResponse>(responses, request.PageNumber, request.PageSize, totalCount);
    }
} 
