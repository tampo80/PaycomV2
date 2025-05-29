using System.ComponentModel.DataAnnotations;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Regions.Create.v1;
public record CreateRegionCommand(
    string Nom,
    string Code,
    Guid? ChefLieuId) : IRequest<CreateRegionResponse>;
