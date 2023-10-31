using FluentValidation;
using UseCases.Dtos.ServiceDto;

namespace UseCases.FluentValidation.Validators.CreateDto
{
    public class ServiceCreationDtoValidator : AbstractValidator<ServiceForCreationDto>
    {
        public ServiceCreationDtoValidator()
        {
            RuleFor(p => p.CategoryId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid service category ID");
            RuleFor(p => p.Name).NotNull().NotEmpty().Length(2, 1024).WithErrorCode("Invalid service name");
            RuleFor(p => p.Price).NotNull().GreaterThan(0).WithErrorCode("Invalid service price");
            RuleFor(s => s.IsActive).NotNull().WithErrorCode("Invalid service status");
            RuleFor(p => p.SpecializationId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid service specialization ID");
        }
    }
}
