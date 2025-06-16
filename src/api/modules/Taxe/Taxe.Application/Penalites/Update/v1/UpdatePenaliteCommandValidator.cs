using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Penalites.Update.v1;
public class UpdatePenaliteCommandValidator : AbstractValidator<UpdatePenaliteCommand>
{
    public UpdatePenaliteCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("L'identifiant de la pénalité est requis");
        RuleFor(p => p.DateApplication).NotEmpty();
        RuleFor(p => p.MontantPenalite).GreaterThan(0).WithMessage("Le montant doit être supérieur à zéro");
        RuleFor(p => p.TauxPenalite).GreaterThanOrEqualTo(0).WithMessage("Le taux de pénalité doit être supérieur ou égal à zéro");
        RuleFor(p => p.NombreJoursRetard).GreaterThanOrEqualTo(0).WithMessage("Le nombre de jours de retard doit être supérieur ou égal à zéro");
        RuleFor(p => p.Motif).MaximumLength(500);
    }
    
}
