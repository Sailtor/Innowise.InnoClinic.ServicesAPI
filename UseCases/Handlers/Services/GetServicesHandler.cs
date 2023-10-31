using AutoMapper;
using Core.Repositories;
using UseCases.Dtos.ServiceDto;
using UseCases.Interfaces;
using UseCases.Queries.Services;

namespace UseCases.Handlers
{
    public class GetServicesHandler : IQueryHandler<GetServicesQuery, IEnumerable<ServiceForResponseDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetServicesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceForResponseDto>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _repositoryManager.ServiceRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ServiceForResponseDto>>(services);
        }
    }
}
