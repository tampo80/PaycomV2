using FluentValidation;

namespace PayCom.WebApi.Catalog.Application.Brands.Update.v1;
public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(b => b.Name).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(b => b.Description).MaximumLength(1000);
    }
}
