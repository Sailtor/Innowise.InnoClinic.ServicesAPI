using AutoMapper;
using Core.RepositoryInterfaces;
using UseCases.Dtos.SpecializationDto;
using UseCases.Interfaces;
using UseCases.Queries.Specializations;

namespace UseCases.Handlers.Specializations
{
    public class GetSpecializationsHandler : IQueryHandler<GetSpecializationsQuery, IEnumerable<SpecializationForResponseDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetSpecializationsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SpecializationForResponseDto>> Handle(GetSpecializationsQuery request, CancellationToken cancellationToken)
        {
            var specializations = await _repositoryManager.SpecializationRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<SpecializationForResponseDto>>(specializations);
        }
    }
}
