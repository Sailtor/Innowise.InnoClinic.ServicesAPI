using FluentValidation;
using UseCases.Commands.Services;
using UseCases.FluentValidation.Validators.UpdateDto;

namespace UseCases.FluentValidation.Validators.Commands.Services
{
    public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceCommandValidator()
        {
            RuleFor(p => p.serviceId).NotNull().WithMessage("Service id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Service id must be a valid guid")
                .WithErrorCode("Invalid service ID");

            RuleFor(p => p.serviceForUpdate).NotNull().WithMessage("Service can't be null")
                .SetValidator(new ServiceUpdateDtoValidator())
                .WithErrorCode("Invalid service");
        }
    }
}
