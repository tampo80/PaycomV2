using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Paging;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Villes.Search.v1;
public class SearchVillesCommand : PaginationFilter, IRequest<PagedList<VilleResponse>>
{
    public string Nom { get; init; }
    public Guid? PrefectureId { get; init; }
    public string Code { get; init; }
} 
