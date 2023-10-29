using AutoMapper;
using Core.Repositories;
using MediatR;
using UseCases.Dtos.CategoryDto;
using UseCases.Queries;

namespace UseCases.Handlers
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, CategoryForResponseDto>
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
            var categories = await _repositoryManager.CategoryRepository.GetByIdAsync(request.categoryId, cancellationToken);
            return _mapper.Map<CategoryForResponseDto>(categories);
        }
    }
}
