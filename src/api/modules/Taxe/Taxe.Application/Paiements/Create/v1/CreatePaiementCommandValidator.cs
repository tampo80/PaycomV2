using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Paiements.Create.v1;
public class CreatePaiementCommandValidator : AbstractValidator<CreatePaiementCommand>
{
    public CreatePaiementCommandValidator()
    {
        RuleFor(p => p.Date).NotEmpty();
        RuleFor(p => p.FraisTransaction).NotEmpty();
        RuleFor(p => p.Montant).NotEmpty();
        RuleFor(p => p.CodeTransaction).NotEmpty();
        RuleFor(p => p.Statut).NotEmpty();
        RuleFor(p => p.ModePaiement).NotEmpty();
        RuleFor(p => p.InformationsSupplementaires).NotEmpty();
        RuleFor(p => p.DateTransaction).NotEmpty();
    }
    
}
