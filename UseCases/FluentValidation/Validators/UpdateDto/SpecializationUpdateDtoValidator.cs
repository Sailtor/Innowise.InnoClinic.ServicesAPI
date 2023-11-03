using FluentValidation;
using UseCases.Dtos.SpecializationDto;

namespace UseCases.FluentValidation.Validators.UpdateDto
{
    public class SpecializationUpdateDtoValidator : AbstractValidator<SpecializationForUpdateDto>
    {
        public SpecializationUpdateDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().Length(2, 1024).WithErrorCode("Invalid specialization name");
        }
    }
}
