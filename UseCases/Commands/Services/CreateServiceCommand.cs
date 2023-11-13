using UseCases.Dtos.ServiceDto;
using UseCases.Interfaces;

namespace UseCases.Commands.Services
{
    public record CreateServiceCommand(ServiceForCreationDto serviceForCreation) : ICommand<ServiceForResponseDto>;
}
