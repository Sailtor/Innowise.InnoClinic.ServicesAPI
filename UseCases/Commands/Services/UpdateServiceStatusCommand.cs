using UseCases.Interfaces;

namespace UseCases.Commands.Services
{
    public record UpdateServiceStatusCommand(Guid serviceId, bool isActive) : ICommand;
}
