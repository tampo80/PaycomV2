using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.Update.v1;
public class UpdateEcheancierCommandValidator : AbstractValidator<UpdateEcheancierCommand>
{
    public UpdateEcheancierCommandValidator()
    {
        RuleFor(c => c.DateEcheance).NotEmpty();
        RuleFor(c => c.MontantDu).NotEmpty();
        RuleFor(c => c.MontantPaye).NotEmpty();
    }
}
