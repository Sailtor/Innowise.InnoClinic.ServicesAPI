using MediatR;

namespace UseCases.Commands.Services
{
    public record DeleteServiceCommand(Guid serviceId) : IRequest;
}
