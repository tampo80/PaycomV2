using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Operations.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Operations.Search.v1;
public class SearchOperationsCommand : PaginationFilter, IRequest<PagedList<OperationResponse>>
{
    public string? Libelle { get; init; }
    public string? Type { get; init; }
    public DateTime? DateDebut { get; init; }
    public DateTime? DateFin { get; init; }
} 
