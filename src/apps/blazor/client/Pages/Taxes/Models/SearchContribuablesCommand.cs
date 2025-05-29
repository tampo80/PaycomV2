using FSH.Framework.Core.Paging;

namespace PayCom.Blazor.Client.Pages.Taxes.Models;

public class SearchContribuablesCommand : PaginationFilter
{
    public string? SearchTerm { get; set; }
} 
