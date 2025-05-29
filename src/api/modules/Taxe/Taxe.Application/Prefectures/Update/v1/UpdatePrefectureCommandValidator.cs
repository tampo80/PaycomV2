using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Update.v1;
public class UpdatePrefectureCommandValidator : AbstractValidator<UpdatePrefectureCommand>
{
    public UpdatePrefectureCommandValidator()
    {
        RuleFor(p => p.Nom).NotEmpty();
        RuleFor(p => p.Code).NotEmpty();
    }
    
}
