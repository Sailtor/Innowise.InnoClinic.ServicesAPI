using UseCases.Interfaces;

namespace UseCases.Commands.Specializations
{
    public record UpdateSpecializationStatusCommand(Guid specializationId, bool isActive) : ICommand;
}
