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
        RuleFor(p => p.MontantPenalite).GreaterThan(0).WithMessage("Le montant doit être supérieur à zéro");
        RuleFor(p => p.TypePenalite).NotEmpty();
        RuleFor(p => p.Motif).MaximumLength(500);
        RuleFor(p => p.ObligationFiscaleId).NotEmpty().WithMessage("L'identifiant de l'obligation fiscale est requis");
        RuleFor(p => p.EcheanceId).NotEmpty().WithMessage("L'identifiant de l'échéance est requis");
        RuleFor(p => p.TauxPenalite).GreaterThanOrEqualTo(0).WithMessage("Le taux de pénalité doit être supérieur ou égal à zéro");
        RuleFor(p => p.NombreJoursRetard).GreaterThanOrEqualTo(0).WithMessage("Le nombre de jours de retard doit être supérieur ou égal à zéro");
    }
}
