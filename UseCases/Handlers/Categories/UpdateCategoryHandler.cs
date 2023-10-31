using AutoMapper;
using Core.Exceptions;
using Core.Repositories;
using UseCases.Commands.Categories;
using UseCases.Interfaces;

namespace UseCases.Handlers.Categories
{
    public class UpdateCategoryHandler : ICommandHandler<UpdateCategoryCommand>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repositoryManager.CategoryRepository.GetByIdAsync(request.categoryId, cancellationToken);
            if (category is null)
            {
                throw new CategoryNotFoundException(request.categoryId);
            }
            _mapper.Map(request.categoryForUpdate, category);
        }
    }
}
