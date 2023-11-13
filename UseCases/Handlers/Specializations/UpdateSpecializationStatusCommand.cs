using Core.Entities;
using Core.Exceptions;
using Core.RepositoryInterfaces;
using UseCases.Commands.Specializations;
using UseCases.Interfaces;

namespace UseCases.Handlers.Specializations
{
    public class UpdateSpecializationStatusHandler : ICommandHandler<UpdateSpecializationStatusCommand>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMessageProducer _messageProducer;
        public UpdateSpecializationStatusHandler(IRepositoryManager repositoryManager, IMessageProducer messageProducer)
        {
            _repositoryManager = repositoryManager;
            _messageProducer = messageProducer;
        }

        public async Task Handle(UpdateSpecializationStatusCommand request, CancellationToken cancellationToken)
        {
            var specialization = await _repositoryManager.SpecializationRepository.GetByIdAsync(request.specializationId, cancellationToken);
            if (specialization is null)
            {
                throw new SpecializationNotFoundException(request.specializationId);
            }
            specialization.IsActive = request.isActive;
            _repositoryManager.SpecializationRepository.Update(specialization);

            var connectedServices = await _repositoryManager.ServiceRepository.GetAllAsync(cancellationToken);
            if (connectedServices is not null)
            {
                foreach (Service s in connectedServices)
                {
                    if (s.SpecializationId == request.specializationId)
                    {
                        s.IsActive = request.isActive;
                        _repositoryManager.ServiceRepository.Update(s);
                    }
                }
            }

            _messageProducer.SendMessage(specialization);
        }
    }
}
