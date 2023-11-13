using FluentValidation;
using UseCases.Commands.Services;

namespace UseCases.FluentValidation.Validators.Commands.Services
{
    public class DeleteServiceCommandValidator : AbstractValidator<DeleteServiceCommand>
    {
        public DeleteServiceCommandValidator()
        {
            RuleFor(p => p.serviceId).NotNull().WithMessage("Service id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Service id must be a valid guid")
                .WithErrorCode("Invalid service ID");
        }
    }
}
