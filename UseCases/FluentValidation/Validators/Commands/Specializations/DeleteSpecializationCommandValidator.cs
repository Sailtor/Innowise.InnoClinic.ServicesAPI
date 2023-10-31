using FluentValidation;
using UseCases.Commands.Specializations;

namespace UseCases.FluentValidation.Validators.Commands.Specializations
{
    public class DeleteSpecializationCommandValidator : AbstractValidator<DeleteSpecializationCommand>
    {
        public DeleteSpecializationCommandValidator()
        {
            RuleFor(p => p.specializationId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid specialization ID");
        }
    }
}
