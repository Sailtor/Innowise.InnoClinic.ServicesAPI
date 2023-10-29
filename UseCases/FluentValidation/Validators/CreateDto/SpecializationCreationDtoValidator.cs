using FluentValidation;
using UseCases.Dtos.SpecializationDto;

namespace UseCases.FluentValidation.Validators.CreateDto
{
    public class SpecializationCreationDtoValidator : AbstractValidator<SpecializationForCreationDto>
    {
        public SpecializationCreationDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().Length(2, 1024).WithErrorCode("Invalid specialization name");
            RuleFor(s => s.IsActive).NotNull().WithErrorCode("Invalid specialization status");
        }
    }
}
