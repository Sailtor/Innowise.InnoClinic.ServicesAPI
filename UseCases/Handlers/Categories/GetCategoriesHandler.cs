using AutoMapper;
using Core.Repositories;
using MediatR;
using UseCases.Categories.Queries;
using UseCases.Dtos.CategoryDto;

namespace UseCases.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryForResponseDto>>
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
