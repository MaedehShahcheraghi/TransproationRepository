using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportationSystem.Applciation.Attributes;
using TransportationSystem.Applciation.DTOs.CityDTOS;
using TransportationSystem.Applciation.Features.CityMange.Handlers.Queries;
using TransportationSystem.Applciation.Features.CityMange.Requests.Commsnds;
using TransportationSystem.Applciation.Features.CityMange.Requests.Queries;

namespace TransportationSystem.Api.Controllers
{
    [PermissionChecker(3)]
    [Route("api/[controller]")]

    [ApiController]
    //[Authorize]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/Cities")]
        public async Task<ActionResult> GetAllCity()
        {
            var requset = new GetAllCityRequest();
            var response = await _mediator.Send(requset);
            return Ok(response);
        }
        [HttpGet("/Cities/{id}")]
        public async Task<ActionResult> GetCity(long id)
        {
            var request = new GetCityRequest() { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("/Cities/City/{cityCode}")]
        public async Task<ActionResult> GetCityByCityCode(int cityCode)
        {
            var request = new GetCityByCityCodeRequest() { CityCode = cityCode };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("/Cities/CreateCity")]
        public async Task<ActionResult> CreateCity(CreateCityDto createCity)
        {
            var request = new CreateCityCommandRequest() { CityDto = createCity };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("/Cities/EditCity")]
        public async Task<ActionResult> EditCity(EditCityDto editCity)
        {
            var request = new EditCityCommandRequest() { EditCity = editCity };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("/Cities/RemoveCity/{id}")]
        public async Task<ActionResult> RemoveCity(long id)
        {
            var request = new DeleteCityCommandRequest() { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
