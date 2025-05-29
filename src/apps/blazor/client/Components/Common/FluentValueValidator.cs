using FluentValidation;
using MudBlazor;
using System.Linq.Expressions;

namespace PayCom.Blazor.Client.Components.Common;

public class FluentValueValidator<T>
{
    public IValidator<T> Validator { get; }

    public FluentValueValidator(Expression<Func<AbstractValidator<T>>> validator)
    {
        Validator = validator.Compile()();
    }

    public FluentValueValidator(AbstractValidator<T> validator)
    {
        Validator = validator;
    }

    public FluentValueValidator(params IValidationRule[] validationRules)
    {
        var validator = new InlineValidator<T>();
        foreach (var rule in validationRules)
        {
          //  validator.RuleSets.Add(rule);
        }
        Validator = validator;
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidatePropertyAsync((T)model, propertyName);
        if (result.Errors?.Any() == true)
            return result.Errors.Select(e => e.ErrorMessage);
        return Array.Empty<string>();
    };

    public async Task<FluentValidation.Results.ValidationResult> ValidateAsync(T model)
    {
        return await Validator.ValidateAsync(model);
    }

    public async Task<FluentValidation.Results.ValidationResult> ValidatePropertyAsync(T model, string propertyName)
    {
        return await Validator.ValidateAsync(model, x => x.IncludeProperties(propertyName));
    }
} 
