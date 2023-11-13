using FluentValidation;
using UseCases.Dtos.SpecializationDto;

namespace UseCases.FluentValidation.Validators.CreateDto
{
    public class SpecializationCreationDtoValidator : AbstractValidator<SpecializationForCreationDto>
    {
        public SpecializationCreationDtoValidator()
        {
            RuleFor(p => p.Name).NotNull()
                .WithMessage("Name can't be null")
                .Length(2, 1024)
                .WithMessage("Invalid name length")
                .WithErrorCode("Invalid specialization name");

            RuleFor(s => s.IsActive).NotNull().WithMessage("Specialization status can't be null")
                .WithErrorCode("Invalid specialization status");
        }
    }
}
