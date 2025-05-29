using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Paging;
using MediatR;
using PayCom.WebApi.Taxe.Application.Echeances.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Echeances.Search.v1;
public record SearchEcheancesCommand(
    [property: DefaultValue(1)]
    int PageIndex = 1,
    [property: DefaultValue(10)]
    int PageSize = 10,
    [property: DefaultValue("")]
    string? SortBy = null,
    [property: DefaultValue(null)]
    Guid? ObligationFiscaleId = null,
    string? Statut = null) : IRequest<PagedList<EcheanceResponse>>; 
