using MediatR;
using UseCases.Dtos.CategoryDto;

namespace UseCases.Categories.Queries
{
    public record GetCategoriesQuery() : IRequest<IEnumerable<CategoryForResponseDto>>;
}