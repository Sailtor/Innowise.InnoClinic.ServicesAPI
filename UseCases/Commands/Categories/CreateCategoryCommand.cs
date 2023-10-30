using MediatR;
using UseCases.Dtos.CategoryDto;

namespace UseCases.Commands.Categories
{
    public record CreateCategoryCommand(CategoryForCreationDto categoryForCreation) : IRequest<CategoryForResponseDto>;
}
