using AutoMapper;
using Core.Exceptions;
using Core.Repositories;
using UseCases.Commands.Services;
using UseCases.Interfaces;

namespace UseCases.Handlers
{
    public class UpdateServiceHandler : ICommandHandler<UpdateServiceCommand>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateServiceHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _repositoryManager.ServiceRepository.GetByIdAsync(request.serviceId, cancellationToken);
            if (service is null)
            {
                throw new ServiceNotFoundException(request.serviceId);
            }
            _mapper.Map(request.serviceForUpdate, service);
            _repositoryManager.ServiceRepository.Update(service);
        }
    }
}
