using UseCases.Dtos.CategoryDto;
using UseCases.Interfaces;

namespace UseCases.Queries.Categories
{
    public record GetCategoryQuery(Guid categoryId) : IQuery<CategoryForResponseDto>;
}