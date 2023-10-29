using MediatR;
using UseCases.Dtos.CategoryDto;

namespace UseCases.Queries
{
    public record GetCategoryQuery(Guid categoryId) : IRequest<CategoryForResponseDto>;
}