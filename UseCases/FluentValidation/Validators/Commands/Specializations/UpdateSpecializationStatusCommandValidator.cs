using FluentValidation;
using UseCases.Commands.Specializations;

namespace UseCases.FluentValidation.Validators.Commands.Specializations
{
    public class UpdateSpecializationStatusCommandValidator : AbstractValidator<UpdateSpecializationStatusCommand>
    {
        public UpdateSpecializationStatusCommandValidator()
        {
            RuleFor(p => p.specializationId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid specialization ID");
            RuleFor(p => p.isActive).NotNull().WithErrorCode("Invalid specialization status");
        }
    }
}
