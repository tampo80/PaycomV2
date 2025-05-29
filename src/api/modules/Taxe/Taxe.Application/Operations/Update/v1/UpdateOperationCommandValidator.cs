using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Operations.Update.v1;
public class UpdateOperationCommandValidator : AbstractValidator<UpdateOperationCommand>
{
    public UpdateOperationCommandValidator()
    {
        RuleFor(o => o.Date).NotEmpty();
        RuleFor(o => o.Description).MinimumLength(2).NotEmpty();
        RuleFor(o => o.Utilisateur).NotEmpty();
    }
}
