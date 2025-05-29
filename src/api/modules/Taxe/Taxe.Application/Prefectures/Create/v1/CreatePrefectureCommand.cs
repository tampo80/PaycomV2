using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Create.v1;
public record CreatePrefectureCommand(
    [property: DefaultValue("Nom de la prefecture")] string Nom,
    [property: DefaultValue("Code de la prefecture")] string Code) : IRequest<CreatePrefectureResponse>;
