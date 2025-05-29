using FSH.Framework.Core.Identity.Users.Dtos;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Paging;
using MediatR;
using PayCom.WebApi.Taxe.Application.Operations.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Operations.Search.v1;
public class SearchOperationCommand : PaginationFilter, IRequest<PagedList<OperationResponse>>
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public UserDetail Utilisateur { get; set; }
}
