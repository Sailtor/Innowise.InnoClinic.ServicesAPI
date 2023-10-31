using AutoMapper;
using Core.Exceptions;
using Core.Repositories;
using UseCases.Commands.Specializations;
using UseCases.Interfaces;

namespace UseCases.Handlers
{
    public class UpdateSpecializationHandler : ICommandHandler<UpdateSpecializationCommand>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateSpecializationHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = await _repositoryManager.SpecializationRepository.GetByIdAsync(request.specializationId, cancellationToken);
            if (specialization is null)
            {
                throw new SpecializationNotFoundException(request.specializationId);
            }
            _mapper.Map(request.specializationForUpdate, specialization);
        }
    }
}
