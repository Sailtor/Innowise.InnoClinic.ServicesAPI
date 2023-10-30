using MediatR;
using UseCases.Dtos.ServiceDto;

namespace UseCases.Queries.Services
{
    public record GetServiceQuery(Guid serviceId) : IRequest<ServiceForResponseDto>;

}
