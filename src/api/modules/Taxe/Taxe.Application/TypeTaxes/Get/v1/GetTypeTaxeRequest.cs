using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Get.v1;
public record GetTypeTaxeRequest(Guid Id) : IRequest<TypeTaxeResponse>; 
