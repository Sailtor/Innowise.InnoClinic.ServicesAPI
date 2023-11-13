using Core.Exceptions;
using Core.RepositoryInterfaces;
using UseCases.Commands.Services;
using UseCases.Interfaces;

namespace UseCases.Handlers.Services
{
    public class UpdateServiceStatusHandler : ICommandHandler<UpdateServiceStatusCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateServiceStatusHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task Handle(UpdateServiceStatusCommand request, CancellationToken cancellationToken)
        {
            var service = await _repositoryManager.ServiceRepository.GetByIdAsync(request.serviceId, cancellationToken);
            if (service is null)
            {
                throw new ServiceNotFoundException(request.serviceId);
            }
            service.IsActive = request.isActive;
            _repositoryManager.ServiceRepository.Update(service);
        }
    }
}
