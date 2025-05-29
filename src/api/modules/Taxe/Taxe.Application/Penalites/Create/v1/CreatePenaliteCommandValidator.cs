using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Penalites.Create.v1;

namespace PayCom.WebApi.Taxe.Application.Penalites.Create;
public class CreatePenaliteCommandValidator : AbstractValidator<CreatePenaliteCommand>
{
    public CreatePenaliteCommandValidator()
    {
        RuleFor(p => p.DateApplication).NotEmpty();
        RuleFor(p => p.Montant).GreaterThan(0).WithMessage("Le montant doit être supérieur à zéro");
        RuleFor(p => p.Type).NotEmpty().MaximumLength(100);
        RuleFor(p => p.Description).MaximumLength(500);
        RuleFor(p => p.TaxeConcerneeId).NotEmpty().WithMessage("L'identifiant de la taxe concernée est requis");
    }
}
