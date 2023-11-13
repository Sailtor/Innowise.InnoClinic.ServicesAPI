using UseCases.Dtos.SpecializationDto;
using UseCases.Interfaces;

namespace UseCases.Queries.Specializations
{
    public record GetSpecializationsQuery() : IQuery<IEnumerable<SpecializationForResponseDto>>;

}
