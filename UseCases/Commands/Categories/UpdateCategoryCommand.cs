using MediatR;
using UseCases.Dtos.CategoryDto;

namespace UseCases.Commands.Categories
{
    public record UpdateCategoryCommand(Guid categoryId,CategoryForUpdateDto categoryForUpdate) : IRequest;
}
