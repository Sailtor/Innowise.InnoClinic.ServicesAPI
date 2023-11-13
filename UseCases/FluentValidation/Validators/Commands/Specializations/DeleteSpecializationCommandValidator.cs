using FluentValidation;
using UseCases.Commands.Specializations;

namespace UseCases.FluentValidation.Validators.Commands.Specializations
{
    public class DeleteSpecializationCommandValidator : AbstractValidator<DeleteSpecializationCommand>
    {
        public DeleteSpecializationCommandValidator()
        {
            RuleFor(p => p.specializationId).NotNull().WithMessage("Specialization id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Specialization id must be a valid guid")
                .WithErrorCode("Invalid specialization ID");
        }
    }
}
