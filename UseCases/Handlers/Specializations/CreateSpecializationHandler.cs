using AutoMapper;
using Core.Entities;
using Core.Repositories;
using UseCases.Commands.Specializations;
using UseCases.Dtos.SpecializationDto;
using UseCases.Interfaces;

namespace UseCases.Handlers
{
    public class CreateSpecializationHandler : ICommandHandler<CreateSpecializationCommand, SpecializationForResponseDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateSpecializationHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<SpecializationForResponseDto> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = _mapper.Map<Specialization>(request.specializationForCreation);
            await _repositoryManager.SpecializationRepository.AddAsync(specialization, cancellationToken);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<SpecializationForResponseDto>(specialization);
        }
    }
}
