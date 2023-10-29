using FluentValidation;
using UseCases.Dtos.ServiceDto;

namespace UseCases.FluentValidation.Validators.UpdateDto
{
    public class ServiceUpdateDtoValidator : AbstractValidator<ServiceForUpdateDto>
    {
        public ServiceUpdateDtoValidator()
        {
            RuleFor(p => p.CategoryId).NotNull().Must(ValidateGuid).WithErrorCode("Invalid service category ID");
            RuleFor(p => p.Name).NotNull().NotEmpty().Length(2, 1024).WithErrorCode("Invalid service name");
            RuleFor(p => p.Price).NotNull().GreaterThan(0).WithErrorCode("Invalid service price");
            RuleFor(p => p.SpecializationId).NotNull().Must(ValidateGuid).WithErrorCode("Invalid service specialization ID");
        }

        protected bool ValidateGuid(Guid? unvalidatedGuid)
        {
            if (unvalidatedGuid != Guid.Empty)
            {
                if (Guid.TryParse(unvalidatedGuid.ToString(), out _))
                {
                    return true;
                }
            }
            return false;
        }

        //Duct tape for not nullable guids
        protected bool ValidateGuid(Guid unvalidatedGuid)
        {
            if (unvalidatedGuid != Guid.Empty)
            {
                if (Guid.TryParse(unvalidatedGuid.ToString(), out _))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
