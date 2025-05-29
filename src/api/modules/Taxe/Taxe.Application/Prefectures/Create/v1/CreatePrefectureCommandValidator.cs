using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Prefectures.Create.v1;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Create;
public class CreatePrefectureCommandValidator : AbstractValidator<CreatePrefectureCommand>
{
    public CreatePrefectureCommandValidator()
    {
        RuleFor(p => p.Nom).NotEmpty().MinimumLength(2);
        RuleFor(p => p.Code).NotEmpty();
    }
    
}
