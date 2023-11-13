using UseCases.Interfaces;

namespace UseCases.Commands.Categories
{
    public record DeleteCategoryCommand(Guid categoryId) : ICommand;
}
