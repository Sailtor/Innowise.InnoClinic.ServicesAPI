using AutoMapper;
using Core.Exceptions;
using Core.Repositories;
using UseCases.Commands.Services;
using UseCases.Interfaces;

namespace UseCases.Handlers
{
    public class UpdateServiceStatusHandler : ICommandHandler<UpdateServiceStatusCommand>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateServiceStatusHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task Handle(UpdateServiceStatusCommand request, CancellationToken cancellationToken)
        {
            var service = await _repositoryManager.ServiceRepository.GetByIdAsync(request.serviceId, cancellationToken);
            if (service is null)
            {
                throw new ServiceNotFoundException(request.serviceId);
            }
            service.IsActive = request.isActive;
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
