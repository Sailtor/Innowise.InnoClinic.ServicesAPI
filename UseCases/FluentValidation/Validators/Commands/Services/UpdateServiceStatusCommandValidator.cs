using FluentValidation;
using UseCases.Commands.Services;

namespace UseCases.FluentValidation.Validators.Commands.Services
{
    public class UpdateServiceStatusCommandValidator : AbstractValidator<UpdateServiceStatusCommand>
    {
        public UpdateServiceStatusCommandValidator()
        {
            RuleFor(p => p.serviceId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid service ID");
            RuleFor(p => p.isActive).NotNull().WithErrorCode("Invalid service status");
        }
    }
}
