using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Core.Repositories;
using UseCases.Commands.Specializations;
using UseCases.Interfaces;

namespace UseCases.Handlers
{
    public class UpdateSpecializationStatusHandler : ICommandHandler<UpdateSpecializationStatusCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateSpecializationStatusHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task Handle(UpdateSpecializationStatusCommand request, CancellationToken cancellationToken)
        {
            var specialization = await _repositoryManager.SpecializationRepository.GetByIdAsync(request.specializationId, cancellationToken);
            if (specialization is null)
            {
                throw new SpecializationNotFoundException(request.specializationId);
            }
            specialization.IsActive = request.isActive;
            var connectedServices = await _repositoryManager.ServiceRepository.GetAllAsync(cancellationToken);
            if (connectedServices is not null)
            {
                foreach (Service s in connectedServices)
                {
                    s.IsActive = request.isActive;
                }
            }
            /*
            change connected doctors status via rabbitMQ  
            */
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
