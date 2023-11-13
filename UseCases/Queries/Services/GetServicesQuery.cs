using UseCases.Dtos.ServiceDto;
using UseCases.Interfaces;

namespace UseCases.Queries.Services
{
    public record GetServicesQuery() : IQuery<IEnumerable<ServiceForResponseDto>>;
}
