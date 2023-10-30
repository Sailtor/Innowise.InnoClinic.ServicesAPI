using MediatR;

namespace UseCases.Commands.Categories
{
    public record DeleteCategoryCommand(Guid categoryId) : IRequest;
}
