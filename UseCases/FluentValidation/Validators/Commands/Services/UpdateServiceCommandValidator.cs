using FluentValidation;
using UseCases.Commands.Services;
using UseCases.FluentValidation.Validators.UpdateDto;

namespace UseCases.FluentValidation.Validators.Commands.Services
{
    public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceCommandValidator()
        {
            RuleFor(p => p.serviceId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid service ID");
            RuleFor(p => p.serviceForUpdate).NotNull().SetValidator(new ServiceUpdateDtoValidator()).WithErrorCode("Invalid service");
        }
    }
}
