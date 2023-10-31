using FluentValidation;
using UseCases.Commands.Specializations;
using UseCases.FluentValidation.Validators.CreateDto;

namespace UseCases.FluentValidation.Validators.Commands.Specializations
{
    public class UpdateSpecializationCommandValidator : AbstractValidator<UpdateSpecializationCommand>
    {
        public UpdateSpecializationCommandValidator()
        {
            RuleFor(p => p.specializationId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid specialization ID");
            RuleFor(p => p.specializationForUpdate).NotNull().SetValidator(new SpecializationUpdateDtoValidator()).WithErrorCode("Invalid specialization");
        }
    }
}
