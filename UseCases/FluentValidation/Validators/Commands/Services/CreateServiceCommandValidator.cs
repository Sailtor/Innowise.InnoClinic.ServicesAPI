using FluentValidation;
using UseCases.Commands.Services;
using UseCases.FluentValidation.Validators.CreateDto;

namespace UseCases.FluentValidation.Validators.Commands.Services
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(p => p.serviceForCreation).NotNull().SetValidator(new ServiceCreationDtoValidator()).WithErrorCode("Invalid service");
        }
    }
}
