using FluentValidation;
using UseCases.Commands.Categories;
using UseCases.FluentValidation.Validators.CreateDto;

namespace UseCases.FluentValidation.Validators.Commands.Categories
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(p => p.categoryId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid category ID");
            RuleFor(p => p.categoryForUpdate).NotNull().SetValidator(new CategoryUpdateDtoValidator()).WithErrorCode("Invalid category");
        }
    }
}
