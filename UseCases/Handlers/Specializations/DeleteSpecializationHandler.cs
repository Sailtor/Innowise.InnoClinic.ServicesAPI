using Core.Exceptions;
using Core.Repositories;
using UseCases.Commands.Specializations;
using UseCases.Interfaces;

namespace UseCases.Handlers
{
    public class DeleteSpecializationHandler : ICommandHandler<DeleteSpecializationCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteSpecializationHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = await _repositoryManager.SpecializationRepository.GetByIdAsync(request.specializationId, cancellationToken);
            if (specialization is null)
            {
                throw new SpecializationNotFoundException(request.specializationId);
            }
            _repositoryManager.SpecializationRepository.Remove(specialization);
        }
    }
}
