using MediatR;
using UseCases.Dtos.ServiceDto;

namespace UseCases.Commands.Services
{
    public record UpdateServiceCommand(Guid serviceId, ServiceForUpdateDto serviceForUpdate) : IRequest;
}
