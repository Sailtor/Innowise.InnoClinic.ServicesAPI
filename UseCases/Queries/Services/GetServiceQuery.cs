using UseCases.Dtos.ServiceDto;
using UseCases.Interfaces;

namespace UseCases.Queries.Services
{
    public record GetServiceQuery(Guid serviceId) : IQuery<ServiceForResponseDto>;

}
