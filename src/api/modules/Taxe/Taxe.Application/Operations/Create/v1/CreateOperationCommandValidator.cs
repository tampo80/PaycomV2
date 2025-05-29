using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Operations.Create.v1;
public class CreateOperationCommandValidator : AbstractValidator<CreateOperationCommand>
{
    public CreateOperationCommandValidator()
    {
        RuleFor(o => o.Date).NotEmpty();
        RuleFor(o => o.Description).NotEmpty().MinimumLength(2);
        RuleFor(o => o.Utilisateur).NotEmpty();
    }
}
