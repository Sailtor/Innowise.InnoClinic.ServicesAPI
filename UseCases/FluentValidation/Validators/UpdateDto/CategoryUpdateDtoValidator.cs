using FluentValidation;
using UseCases.Dtos.CategoryDto;

namespace UseCases.FluentValidation.Validators.CreateDto
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryForUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().Length(2, 1024).WithErrorCode("Invalid category name");
            RuleFor(p => p.TimeSlotSize).NotNull().InclusiveBetween(1, 3).WithErrorCode("Invalid category time slot size");
        }
    }
}
