using AutoMapper;
using Core.RepositoryInterfaces;
using UseCases.Dtos.CategoryDto;
using UseCases.Interfaces;
using UseCases.Queries.Categories;

namespace UseCases.Handlers.Categories
{
    public class GetCategoriesHandler : IQueryHandler<GetCategoriesQuery, IEnumerable<CategoryForResponseDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetCategoriesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryForResponseDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repositoryManager.CategoryRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<CategoryForResponseDto>>(categories);
        }
    }
}
