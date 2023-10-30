using MediatR;
using UseCases.Dtos.CategoryDto;

namespace UseCases.Queries.Categories
{
    public record GetCategoryQuery(Guid categoryId) : IRequest<CategoryForResponseDto>;
}