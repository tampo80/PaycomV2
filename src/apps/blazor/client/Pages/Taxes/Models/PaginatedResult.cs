namespace PayCom.Blazor.Client.Pages.Taxes.Models;

public class PaginatedResult<T>
{
    public List<T> Items { get; set; } = new List<T>();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
} 
