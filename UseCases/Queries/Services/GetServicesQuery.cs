using MediatR;
using UseCases.Dtos.ServiceDto;

namespace UseCases.Queries.Services
{
    public record GetServicesQuery() : IRequest<IEnumerable<ServiceForResponseDto>>;
}
