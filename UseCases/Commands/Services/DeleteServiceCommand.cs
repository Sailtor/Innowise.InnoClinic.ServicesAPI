using UseCases.Interfaces;

namespace UseCases.Commands.Services
{
    public record DeleteServiceCommand(Guid serviceId) : ICommand;
}
