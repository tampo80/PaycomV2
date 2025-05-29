using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Paging;
using MediatR;
using PayCom.WebApi.Taxe.Application.TypeTaxes.Get.v1;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Search.v1;

public class SearchTypeTaxesCommand : PaginationFilter, IRequest<PagedList<TypeTaxeResponse>>
{
    public string? SearchTerm { get; set; }
    
    public SearchTypeTaxesCommand()
    {
        PageNumber = 1;
        PageSize = 10;
    }
} 
