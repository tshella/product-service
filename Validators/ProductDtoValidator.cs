using FluentValidation;
using ProductApi.Models;

namespace ProductApi.Validators;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3, 100);
        RuleFor(x => x.Description).NotEmpty().Length(5, 200);
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
