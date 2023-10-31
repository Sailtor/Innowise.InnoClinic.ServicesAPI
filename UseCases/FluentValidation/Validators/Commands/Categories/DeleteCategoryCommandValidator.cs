using FluentValidation;
using UseCases.Commands.Categories;

namespace UseCases.FluentValidation.Validators.Commands.Categories
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(p => p.categoryId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid category ID");
        }
    }
}
