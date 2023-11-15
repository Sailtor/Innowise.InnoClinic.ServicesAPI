using AutoMapper;
using Core.Exceptions;
using Core.RepositoryInterfaces;
using Infrastructure.Shared;
using MassTransit;
using UseCases.Commands.Services;
using UseCases.Interfaces;

namespace UseCases.Handlers.Services
{
    public class UpdateServiceHandler : ICommandHandler<UpdateServiceCommand>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateServiceHandler(IRepositoryManager repositoryManager, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _repositoryManager.ServiceRepository.GetByIdAsync(request.serviceId, cancellationToken);
            if (service is null)
            {
                throw new ServiceNotFoundException(request.serviceId);
            }
            if (await _repositoryManager.CategoryRepository.GetByIdAsync(request.serviceForUpdate.CategoryId, cancellationToken) is null)
            {
                throw new CategoryNotFoundException(request.serviceForUpdate.CategoryId);
            }
            if (await _repositoryManager.SpecializationRepository.GetByIdAsync(request.serviceForUpdate.SpecializationId, cancellationToken) is null)
            {
                throw new SpecializationNotFoundException(request.serviceForUpdate.SpecializationId);
            }
            _mapper.Map(request.serviceForUpdate, service);
            _repositoryManager.ServiceRepository.Update(service);

            await _publishEndpoint.Publish<ServiceNameChanged>(new
            {
                Id = request.serviceId,
                Name = request.serviceForUpdate.Name
            });
        }
    }
}
