using FluentValidation;
using UseCases.Dtos.SpecializationDto;

namespace UseCases.FluentValidation.Validators.UpdateDto
{
    public class SpecializationUpdateDtoValidator : AbstractValidator<SpecializationForUpdateDto>
    {
        public SpecializationUpdateDtoValidator()
        {
            RuleFor(p => p.Name).NotNull()
                .WithMessage("Name can't be null")
                .Length(2, 1024)
                .WithMessage("Invalid name length")
                .WithErrorCode("Invalid specialization name");
        }
    }
}
