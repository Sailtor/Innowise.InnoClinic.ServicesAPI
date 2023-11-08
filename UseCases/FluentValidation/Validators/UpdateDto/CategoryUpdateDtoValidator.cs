using FluentValidation;
using UseCases.Dtos.CategoryDto;

namespace UseCases.FluentValidation.Validators.UpdateDto
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryForUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Name can't be null")
                .Length(2, 1024).WithMessage("Name should be from 2 to 1024 characters long")
                .WithErrorCode("Invalid category name");

            RuleFor(p => p.TimeSlotSize).NotNull().WithMessage("Time slot size can't be null")
                .InclusiveBetween(1, 3).WithMessage("Time slot size should be between 1 and 3")
                .WithErrorCode("Invalid category time slot size");
        }
    }
}
