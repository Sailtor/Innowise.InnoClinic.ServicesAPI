using MediatR;
using UseCases.Dtos.CategoryDto;

namespace UseCases.Queries.Categories
{
    public record GetCategoriesQuery() : IRequest<IEnumerable<CategoryForResponseDto>>;
}