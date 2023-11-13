using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Core.RepositoryInterfaces;
using UseCases.Commands.Services;
using UseCases.Dtos.ServiceDto;
using UseCases.Interfaces;

namespace UseCases.Handlers.Services
{
    public class CreateServiceHandler : ICommandHandler<CreateServiceCommand, ServiceForResponseDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateServiceHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ServiceForResponseDto> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = _mapper.Map<Service>(request.serviceForCreation);
            if (await _repositoryManager.CategoryRepository.GetByIdAsync(request.serviceForCreation.CategoryId, cancellationToken) is null)
            {
                throw new CategoryNotFoundException(request.serviceForCreation.CategoryId);
            }
            if (await _repositoryManager.SpecializationRepository.GetByIdAsync(request.serviceForCreation.SpecializationId, cancellationToken) is null)
            {
                throw new SpecializationNotFoundException(request.serviceForCreation.SpecializationId);
            }
            service = await _repositoryManager.ServiceRepository.AddAsync(service, cancellationToken);
            return _mapper.Map<ServiceForResponseDto>(service);
        }
    }
}
