using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.TransactionPaiements.Create.v1;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Create;
public class CreateTransactionPaiementCommandValidator : AbstractValidator<CreateTransactionPaiementCommand>
{
    public CreateTransactionPaiementCommandValidator()
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
