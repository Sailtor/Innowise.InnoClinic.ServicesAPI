using UseCases.Dtos.SpecializationDto;
using UseCases.Interfaces;

namespace UseCases.Commands.Specializations
{
    public record CreateSpecializationCommand(SpecializationForCreationDto specializationForCreation) : ICommand<SpecializationForResponseDto>;
}
