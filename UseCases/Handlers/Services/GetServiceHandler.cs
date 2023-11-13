using AutoMapper;
using Core.Exceptions;
using Core.RepositoryInterfaces;
using UseCases.Dtos.ServiceDto;
using UseCases.Interfaces;
using UseCases.Queries.Services;

namespace UseCases.Handlers.Services
{
    public class GetServiceHandler : IQueryHandler<GetServiceQuery, ServiceForResponseDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetServiceHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ServiceForResponseDto> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var service = await _repositoryManager.ServiceRepository.GetByIdAsync(request.serviceId, cancellationToken);
            if (service is null)
            {
                throw new ServiceNotFoundException(request.serviceId);
            }
            return _mapper.Map<ServiceForResponseDto>(service);
        }
    }
}
