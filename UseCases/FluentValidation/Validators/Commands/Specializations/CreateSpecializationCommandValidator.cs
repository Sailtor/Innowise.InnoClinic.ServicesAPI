using FluentValidation;
using UseCases.Commands.Specializations;
using UseCases.FluentValidation.Validators.CreateDto;

namespace UseCases.FluentValidation.Validators.Commands.Specializations
{
    public class CreateSpecializationCommandValidator : AbstractValidator<CreateSpecializationCommand>
    {
        public CreateSpecializationCommandValidator()
        {
            RuleFor(p => p.specializationForCreation).NotNull().WithMessage("Specialization can't be null")
                .SetValidator(new SpecializationCreationDtoValidator())
                .WithErrorCode("Invalid specialization");
        }
    }
}
