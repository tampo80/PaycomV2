using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.Create.v1;
public class CreateEcheancierCommandValidator : AbstractValidator<CreateEcheancierCommand>
{
    public CreateEcheancierCommandValidator()
    {
        RuleFor(c => c.DateEcheance).NotEmpty();
        RuleFor(c => c.MontantDu).NotEmpty();
        RuleFor(c => c.MontantPaye).NotEmpty();
    }
}
