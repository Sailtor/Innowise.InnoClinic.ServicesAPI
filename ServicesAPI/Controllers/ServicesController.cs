using InnoClinic.ServicesAPI.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Commands.Services;
using UseCases.Dtos.ServiceDto;
using UseCases.Queries.Services;

namespace InnoClinic.ServicesAPI.Controllers
{
    [ApiController]
    [Route("api/services")]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = UserRoles.All)]
        [HttpGet]
        public async Task<IActionResult> GetServices(CancellationToken cancellationToken)
        {
            var servicesDto = await _mediator.Send(new GetServicesQuery(), cancellationToken);
            return Ok(servicesDto);
        }

        [Authorize(Roles = UserRoles.All)]
        [HttpGet("{serviceId:guid}")]
        public async Task<IActionResult> GetServiceById(Guid serviceId, CancellationToken cancellationToken)
        {
            var serviceDto = await _mediator.Send(new GetServiceQuery(serviceId), cancellationToken);
            return Ok(serviceDto);
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] ServiceForCreationDto serviceForCreationDto, CancellationToken cancellationToken)
        {
            var serviceDto = await _mediator.Send(new CreateServiceCommand(serviceForCreationDto), cancellationToken);
            return CreatedAtAction(nameof(GetServiceById), new { serviceId = serviceDto.Id }, serviceDto);
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPut("{serviceId:guid}")]
        public async Task<IActionResult> UpdateService(Guid serviceId, [FromBody] ServiceForUpdateDto serviceForUpdateDto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateServiceCommand(serviceId, serviceForUpdateDto), cancellationToken);
            return NoContent();
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPatch("{serviceId:guid}")]
        public async Task<IActionResult> ChangeServiceStatus(Guid serviceId, [FromBody] bool isActive, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateServiceStatusCommand(serviceId, isActive), cancellationToken);
            return NoContent();
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpDelete("{serviceId:guid}")]
        public async Task<IActionResult> DeleteService(Guid serviceId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteServiceCommand(serviceId), cancellationToken);
            return NoContent();
        }
    }
}
