using Infrastructure.Presentation.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Commands.Specializations;
using UseCases.Dtos.SpecializationDto;
using UseCases.Queries.Specializations;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/specializations")]
    public class SpecializationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpecializationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = UserRoles.All)]
        [HttpGet]
        public async Task<IActionResult> GetSpecializations(CancellationToken cancellationToken)
        {
            var specializationsDto = await _mediator.Send(new GetSpecializationsQuery(), cancellationToken);
            return Ok(specializationsDto);
        }

        [Authorize(Roles = UserRoles.All)]
        [HttpGet("{specializationId:guid}")]
        public async Task<IActionResult> GetSpecializationById(Guid specializationId, CancellationToken cancellationToken)
        {
            var specializationDto = await _mediator.Send(new GetSpecializationQuery(specializationId), cancellationToken);
            return Ok(specializationDto);
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPost]
        public async Task<IActionResult> CreateSpecialization([FromBody] SpecializationForCreationDto specializationForCreationDto, CancellationToken cancellationToken)
        {
            var specializationDto = await _mediator.Send(new CreateSpecializationCommand(specializationForCreationDto), cancellationToken);
            return CreatedAtAction(nameof(GetSpecializationById), new { specializationId = specializationDto.Id }, specializationDto);
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPut("{specializationId:guid}")]
        public async Task<IActionResult> UpdateSpecialization(Guid specializationId, [FromBody] SpecializationForUpdateDto specializationForUpdateDto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateSpecializationCommand(specializationId, specializationForUpdateDto), cancellationToken);
            return NoContent();
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPatch("{specializationId:guid}")]
        public async Task<IActionResult> ChangeSpecializationStatus(Guid specializationId, [FromBody] bool isActive, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateSpecializationStatusCommand(specializationId, isActive), cancellationToken);
            return NoContent();
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpDelete("{specializationId:guid}")]
        public async Task<IActionResult> DeleteSpecialization(Guid specializationId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteSpecializationCommand(specializationId), cancellationToken);
            return NoContent();
        }
    }
}
