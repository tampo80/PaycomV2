using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Villages.Update.v1;
public class UpdateVillageCommandValidator : AbstractValidator<UpdateVillageCommand>
{
    public UpdateVillageCommandValidator()
    {
        RuleFor(p => p.Nom).NotEmpty();
        RuleFor(p => p.Code).NotEmpty();
    }
    
}
