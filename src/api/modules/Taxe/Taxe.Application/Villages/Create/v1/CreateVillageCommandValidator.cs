using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Villages.Create.v1;
public class CreateVillageCommandValidator : AbstractValidator<CreateVillageCommand>
{
    public CreateVillageCommandValidator()
    {
        RuleFor(p => p.Nom).NotEmpty();
        RuleFor(p => p.Code).NotEmpty();
    }
    
}
