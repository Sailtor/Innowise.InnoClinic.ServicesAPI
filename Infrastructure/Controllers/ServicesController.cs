using Infrastructure.Presentation.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Presentation.Controllers
{
    [ApiController]
    [Route("api/doctors")]
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
            var servicesDto = await _mediator.Send();
            return Ok(servicesDto);
        }

        [Authorize(Roles = UserRoles.All)]
        [HttpGet("{serviceId:guid}")]
        public async Task<IActionResult> GetServiceById(Guid serviceId, CancellationToken cancellationToken)
        {
            var serviceDto = await _mediator.Send();
            return Ok(serviceDto);
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] ServiceForCreationDto serviceForCreationDto)
        {
            var serviceDto = await _mediator.Send();
            return CreatedAtAction(nameof(GetServiceById), new { serviceId = serviceDto.Id }, serviceDto);
        }

        [Authorize(Roles = UserRoles.ReceptionistAndDoctor, Policy = AuthPolicies.OwnerOrReceptionist)]
        [HttpPut("{serviceId:guid}")]
        public async Task<IActionResult> UpdateService(Guid serviceId, [FromBody] ServiceForUpdateDto serviceForUpdateDto, CancellationToken cancellationToken)
        {
            await _mediator.Send();
            return NoContent();
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPut("{serviceId:guid}")]
        public async Task<IActionResult> ChangeServiceStatus(Guid serviceId, [FromBody] bool isActiveStatus, CancellationToken cancellationToken)
        {
            await _mediator.Send();
            return NoContent();
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpDelete("{serviceId:guid}")]
        public async Task<IActionResult> DeleteService(Guid serviceId, CancellationToken cancellationToken)
        {
            await _mediator.Send();
            return NoContent();
        }
    }
}
