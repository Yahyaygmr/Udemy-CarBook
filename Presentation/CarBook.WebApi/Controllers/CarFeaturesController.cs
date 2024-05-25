using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("CarFeatureListByCarId/{id}")]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }
        [HttpGet("CarFeatureChangeAvailableToFalse/{id}")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
           await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Başarılı");
        }
        [HttpGet("CarFeatureChangeAvailableToTrue/{id}")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
           await _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Başarılı");
        }
        [HttpPost("CreateCarFeatureByCarId")]
        public async Task<IActionResult> CreateCarFeatureByCarId(CreateCarFeatureByCarCommand createCarFeatureByCarCommand)
        {
            await _mediator.Send(createCarFeatureByCarCommand);
            return Ok("Başarılı");
        }
    }
}
