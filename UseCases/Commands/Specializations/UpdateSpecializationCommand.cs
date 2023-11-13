using UseCases.Dtos.SpecializationDto;
using UseCases.Interfaces;

namespace UseCases.Commands.Specializations
{
    public record UpdateSpecializationCommand(Guid specializationId, SpecializationForUpdateDto specializationForUpdate) : ICommand;
}
