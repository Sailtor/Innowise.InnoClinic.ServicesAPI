using UseCases.Dtos.ServiceDto;
using UseCases.Interfaces;

namespace UseCases.Commands.Services
{
    public record UpdateServiceCommand(Guid serviceId, ServiceForUpdateDto serviceForUpdate) : ICommand;
}
