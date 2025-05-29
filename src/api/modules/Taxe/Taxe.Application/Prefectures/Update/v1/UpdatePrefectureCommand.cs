using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Update.v1;
public record UpdatePrefectureCommand(
    Guid Id,
    string Nom,
    string Code) : IRequest<UpdatePrefectureResponse>;
