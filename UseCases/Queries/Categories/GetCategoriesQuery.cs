using UseCases.Dtos.CategoryDto;
using UseCases.Interfaces;

namespace UseCases.Queries.Categories
{
    public record GetCategoriesQuery() : IQuery<IEnumerable<CategoryForResponseDto>>;
}