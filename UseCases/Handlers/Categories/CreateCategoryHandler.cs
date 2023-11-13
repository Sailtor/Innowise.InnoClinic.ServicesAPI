using AutoMapper;
using Core.Entities;
using Core.RepositoryInterfaces;
using UseCases.Commands.Categories;
using UseCases.Dtos.CategoryDto;
using UseCases.Interfaces;

namespace UseCases.Handlers.Categories
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand, CategoryForResponseDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CategoryForResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.categoryForCreation);
            category = await _repositoryManager.CategoryRepository.AddAsync(category, cancellationToken);
            return _mapper.Map<CategoryForResponseDto>(category);
        }
    }
}
