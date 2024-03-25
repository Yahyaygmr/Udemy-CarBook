using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCarPricingWithCaListDaily")]
        public async Task<IActionResult> GetCarPricingWithCaListDaily()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(values);
        }
        //[HttpGet("GetCarPricingWithCaList")]
        //public async Task<IActionResult> GetCarPricingWithCaList()
        //{
        //    var values = await _mediator.Send(new GetCarPricingWithCarQuery());
        //    return Ok(values);
        //}
    }
}
