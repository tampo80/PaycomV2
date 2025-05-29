using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Regions.Update.v1;
public record UpdateRegionCommand(
    Guid Id,
    string Nom,
    string Code,
    Guid? ChefLieuId) : IRequest<UpdateRegionResponse>;
