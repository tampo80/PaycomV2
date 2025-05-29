using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.ObligationFiscales.Get.v1;

namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Search.v1;

public class SearchObligationFiscalesSpecs : EntitiesByPaginationFilterSpec<ObligationFiscale, ObligationFiscaleResponse>
{
    public SearchObligationFiscalesSpecs(SearchObligationFiscalesCommand command) 
        : base(command) =>
        Query
            .OrderBy(o => o.DateDebut, !command.HasOrderBy())
            .Where(o => o.ContribuableId == command.ContribuableId, command.ContribuableId.HasValue)
            .Where(o => o.TypeTaxeId == command.TypeTaxeId, command.TypeTaxeId.HasValue)
            .Where(o => o.EstActif == command.EstActif, command.EstActif.HasValue);
} 
