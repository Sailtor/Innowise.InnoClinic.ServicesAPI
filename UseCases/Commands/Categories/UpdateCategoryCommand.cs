using UseCases.Dtos.CategoryDto;
using UseCases.Interfaces;

namespace UseCases.Commands.Categories
{
    public record UpdateCategoryCommand(Guid categoryId, CategoryForUpdateDto categoryForUpdate) : ICommand;
}
