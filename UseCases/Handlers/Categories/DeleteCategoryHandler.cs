using Core.Exceptions;
using Core.Repositories;
using MediatR;
using UseCases.Commands.Categories;

namespace UseCases.Handlers.Categories
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteCategoryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repositoryManager.CategoryRepository.GetByIdAsync(request.categoryId, cancellationToken);
            if (category is null)
            {
                throw new CategoryNotFoundException(request.categoryId);
            }
            _repositoryManager.CategoryRepository.Remove(category);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
