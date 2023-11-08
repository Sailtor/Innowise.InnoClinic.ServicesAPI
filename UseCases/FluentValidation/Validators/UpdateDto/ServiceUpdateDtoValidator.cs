using FluentValidation;
using UseCases.Dtos.ServiceDto;

namespace UseCases.FluentValidation.Validators.UpdateDto
{
    public class ServiceUpdateDtoValidator : AbstractValidator<ServiceForUpdateDto>
    {
        public ServiceUpdateDtoValidator()
        {
            RuleFor(p => p.CategoryId).NotNull().WithMessage("Category id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Category id should be a guid")
                .WithErrorCode("Invalid service category ID");

            RuleFor(p => p.Name).NotNull().WithMessage("Name can't be null")
                .Length(2, 1024).WithMessage("Name should be from 2 to 1024 characters long")
                .WithErrorCode("Invalid service name");

            RuleFor(p => p.Price).NotNull().WithMessage("Price can't be null")
                .GreaterThan(0).WithMessage("Price should be greater than 0")
                .WithErrorCode("Invalid service price");

            RuleFor(p => p.SpecializationId).NotNull().WithMessage("Specialization id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Specialization id should be a guid")
                .WithErrorCode("Invalid service specialization ID");
        }
    }
}
