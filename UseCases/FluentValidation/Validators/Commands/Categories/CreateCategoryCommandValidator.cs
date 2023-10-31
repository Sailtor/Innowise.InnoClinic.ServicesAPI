using FluentValidation;
using UseCases.Commands.Categories;
using UseCases.FluentValidation.Validators.CreateDto;

namespace UseCases.FluentValidation.Validators.Commands.Categories
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(p => p.categoryForCreation).NotNull().SetValidator(new CategoryCreationDtoValidator()).WithErrorCode("Invalid category");
        }
    }
}
