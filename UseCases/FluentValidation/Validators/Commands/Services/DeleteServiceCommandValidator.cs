using FluentValidation;
using UseCases.Commands.Services;

namespace UseCases.FluentValidation.Validators.Commands.Services
{
    public class DeleteServiceCommandValidator : AbstractValidator<DeleteServiceCommand>
    {
        public DeleteServiceCommandValidator()
        {
            RuleFor(p => p.serviceId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid service ID");
        }
    }
}
