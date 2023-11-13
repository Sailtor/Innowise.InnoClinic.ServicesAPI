using FluentValidation;
using UseCases.Commands.Specializations;
using UseCases.FluentValidation.Validators.UpdateDto;

namespace UseCases.FluentValidation.Validators.Commands.Specializations
{
    public class UpdateSpecializationCommandValidator : AbstractValidator<UpdateSpecializationCommand>
    {
        public UpdateSpecializationCommandValidator()
        {
            RuleFor(p => p.specializationId).NotNull().WithMessage("Specialization id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Specialization id must be a valid guid")
                .WithErrorCode("Invalid specialization ID");

            RuleFor(p => p.specializationForUpdate).NotNull().WithMessage("Specialization can't be null")
                .SetValidator(new SpecializationUpdateDtoValidator())
                .WithErrorCode("Invalid specialization");
        }
    }
}
