using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Regions.Update.v1;
public sealed class UpdateRegionCommandValidator : AbstractValidator<UpdateRegionCommand>
{
    public UpdateRegionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Nom).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(c => c.Code).NotEmpty().MaximumLength(50);
    }
}
