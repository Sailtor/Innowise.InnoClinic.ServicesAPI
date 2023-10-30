using MediatR;
using UseCases.Dtos.ServiceDto;

namespace UseCases.Commands.Services
{
    public record CreateServiceCommand(ServiceForCreationDto serviceForCreation) : IRequest<ServiceForResponseDto>;
}
