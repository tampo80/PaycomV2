using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Application.Penalites.Get.v1;
using PayCom.WebApi.Taxe.Application.Penalites.Search.v1;

namespace PayCom.WebApi.Taxe.Application.Penalites.Update.v1;
public record UpdatePenaliteResponse(Guid? Id);
