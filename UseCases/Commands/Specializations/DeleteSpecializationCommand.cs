using UseCases.Interfaces;

namespace UseCases.Commands.Specializations
{
    public record DeleteSpecializationCommand(Guid specializationId) : ICommand;
}
