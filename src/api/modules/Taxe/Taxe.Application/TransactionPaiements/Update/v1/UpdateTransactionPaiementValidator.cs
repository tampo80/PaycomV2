using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Update.v1;
public class UpdateTransactionPaiementValidator : AbstractValidator<UpdateTransactionPaiementCommand>
{
    public UpdateTransactionPaiementValidator()
    {
        RuleFor(p => p.CodeTransaction).NotEmpty();
        RuleFor(p => p.Date).NotEmpty();
        RuleFor(p => p.Montant).NotEmpty().GreaterThan(0);
        RuleFor(p => p.ModePaiement).IsInEnum();
        RuleFor(p => p.Frais).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(p => p.Statut).IsInEnum();
        RuleFor(p => p.Paiement).NotNull();
    }
}
