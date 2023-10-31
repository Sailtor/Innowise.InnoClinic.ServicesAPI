using AutoMapper;
using Core.Exceptions;
using Core.Repositories;
using UseCases.Dtos.SpecializationDto;
using UseCases.Interfaces;
using UseCases.Queries.Specializations;

namespace UseCases.Handlers
{
    public class GetSpecializationHandler : IQueryHandler<GetSpecializationQuery, SpecializationForResponseDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetSpecializationHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<SpecializationForResponseDto> Handle(GetSpecializationQuery request, CancellationToken cancellationToken)
        {
            var specialization = await _repositoryManager.SpecializationRepository.GetByIdAsync(request.specializationId, cancellationToken);
            if (specialization is null)
            {
                throw new SpecializationNotFoundException(request.specializationId);
            }
            return _mapper.Map<SpecializationForResponseDto>(specialization);
        }
    }
}
