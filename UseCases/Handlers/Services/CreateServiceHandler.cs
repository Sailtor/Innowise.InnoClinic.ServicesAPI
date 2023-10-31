using AutoMapper;
using Core.Entities;
using Core.Repositories;
using UseCases.Commands.Services;
using UseCases.Dtos.ServiceDto;
using UseCases.Interfaces;

namespace UseCases.Handlers
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
            await _repositoryManager.ServiceRepository.AddAsync(service, cancellationToken);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ServiceForResponseDto>(service);
        }
    }
}
