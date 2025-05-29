using FSH.Framework.Core.Paging;
using PayCom.Blazor.Infrastructure.Api;

namespace PayCom.Blazor.Client.Pages.Taxes.Models;

public class SearchTaxesCommand : PaginationFilter
{
    public string? SearchTerm { get; set; }
    public int? AnneeImposition { get; set; }
    public Guid? TypeTaxeId { get; set; }
    public Guid? ContribuableId { get; set; }
} 
