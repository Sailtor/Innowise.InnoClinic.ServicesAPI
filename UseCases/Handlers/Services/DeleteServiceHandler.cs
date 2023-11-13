﻿using Core.Exceptions;
using Core.RepositoryInterfaces;
using UseCases.Commands.Services;
using UseCases.Interfaces;

namespace UseCases.Handlers.Services
{
    public class DeleteServiceHandler : ICommandHandler<DeleteServiceCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteServiceHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _repositoryManager.ServiceRepository.GetByIdAsync(request.serviceId, cancellationToken);
            if (service is null)
            {
                throw new ServiceNotFoundException(request.serviceId);
            }
            _repositoryManager.ServiceRepository.Remove(service);
        }
    }
}
