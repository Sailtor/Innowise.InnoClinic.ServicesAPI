using UseCases.Dtos.CategoryDto;
using UseCases.Interfaces;

namespace UseCases.Commands.Categories
{
    public record CreateCategoryCommand(CategoryForCreationDto categoryForCreation) : ICommand<CategoryForResponseDto>;
}
