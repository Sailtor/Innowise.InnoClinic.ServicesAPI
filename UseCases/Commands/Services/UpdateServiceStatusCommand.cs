using MediatR;

namespace UseCases.Commands.Services
{
    public record UpdateServiceStatusCommand(Guid serviceId, bool isActive) : IRequest;
}
