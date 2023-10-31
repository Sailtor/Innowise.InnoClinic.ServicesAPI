using Infrastructure.Presentation.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Commands.Categories;
using UseCases.Dtos.CategoryDto;
using UseCases.Queries.Categories;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = UserRoles.All)]
        [HttpGet]
        public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
        {
            var categoriesDto = await _mediator.Send(new GetCategoriesQuery(), cancellationToken);
            return Ok(categoriesDto);
        }

        [Authorize(Roles = UserRoles.All)]
        [HttpGet("{categoryId:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid categoryId, CancellationToken cancellationToken)
        {
            var categoryDto = await _mediator.Send(new GetCategoryQuery(categoryId), cancellationToken);
            return Ok(categoryDto);
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto categoryForCreationDto, CancellationToken cancellationToken)
        {
            var categoryDto = await _mediator.Send(new CreateCategoryCommand(categoryForCreationDto), cancellationToken);
            return CreatedAtAction(nameof(GetCategoryById), new { patientId = categoryDto.Id }, categoryDto);
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPut("{categoryId:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId, [FromBody] CategoryForUpdateDto categoryForUpdateDto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateCategoryCommand(categoryId, categoryForUpdateDto), cancellationToken);
            return NoContent();
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpDelete("{categoryId:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCategoryCommand(categoryId), cancellationToken);
            return NoContent();
        }
    }
}
