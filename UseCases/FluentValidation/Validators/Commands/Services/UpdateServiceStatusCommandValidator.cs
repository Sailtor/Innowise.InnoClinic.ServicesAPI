using FluentValidation;
using UseCases.Commands.Services;

namespace UseCases.FluentValidation.Validators.Commands.Services
{
    public class UpdateServiceStatusCommandValidator : AbstractValidator<UpdateServiceStatusCommand>
    {
        public UpdateServiceStatusCommandValidator()
        {
            RuleFor(p => p.serviceId).NotNull().WithMessage("Service id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Service id must be a valid guid")
                .WithErrorCode("Invalid service ID");

            RuleFor(p => p.isActive).NotNull().WithMessage("Service status can't be null")
                .WithErrorCode("Invalid service status");
        }
    }
}
