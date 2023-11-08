using FluentValidation;
using UseCases.Commands.Specializations;

namespace UseCases.FluentValidation.Validators.Commands.Specializations
{
    public class UpdateSpecializationStatusCommandValidator : AbstractValidator<UpdateSpecializationStatusCommand>
    {
        public UpdateSpecializationStatusCommandValidator()
        {
            RuleFor(p => p.specializationId).NotNull().WithMessage("Specialization id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Specialization id must be a valid guid")
                .WithErrorCode("Invalid specialization ID");

            RuleFor(p => p.isActive).NotNull().WithMessage("Specialization status can't be null")
                .WithErrorCode("Invalid specialization status");
        }
    }
}
