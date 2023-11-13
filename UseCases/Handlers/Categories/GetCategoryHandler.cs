using AutoMapper;
using Core.Exceptions;
using Core.RepositoryInterfaces;
using UseCases.Dtos.CategoryDto;
using UseCases.Interfaces;
using UseCases.Queries.Categories;

namespace UseCases.Handlers.Categories
{
    public class GetCategoryHandler : IQueryHandler<GetCategoryQuery, CategoryForResponseDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetCategoryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CategoryForResponseDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _repositoryManager.CategoryRepository.GetByIdAsync(request.categoryId, cancellationToken);
            if (category is null)
            {
                throw new CategoryNotFoundException(request.categoryId);
            }
            return _mapper.Map<CategoryForResponseDto>(category);
        }
    }
}
