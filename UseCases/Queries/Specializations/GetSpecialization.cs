using UseCases.Dtos.SpecializationDto;
using UseCases.Interfaces;

namespace UseCases.Queries.Specializations
{
    public record GetSpecializationQuery(Guid specializationId) : IQuery<SpecializationForResponseDto>;

}
