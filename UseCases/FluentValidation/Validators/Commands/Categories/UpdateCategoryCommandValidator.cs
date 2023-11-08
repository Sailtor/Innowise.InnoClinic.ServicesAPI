using FluentValidation;
using UseCases.Commands.Categories;
using UseCases.FluentValidation.Validators.UpdateDto;

namespace UseCases.FluentValidation.Validators.Commands.Categories
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(p => p.categoryId).NotNull().WithMessage("Category id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Category id must be a valid guid")
                .WithErrorCode("Invalid category ID");

            RuleFor(p => p.categoryForUpdate).NotNull().WithMessage("Category can't be null")
                .SetValidator(new CategoryUpdateDtoValidator())
                .WithErrorCode("Invalid category");
        }
    }
}
