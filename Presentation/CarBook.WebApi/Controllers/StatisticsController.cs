using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public IActionResult GetCarCount()
        {
            var value = _mediator.Send(new GetCarCountQuery());
            return Ok(value);
        }
        [HttpGet("GetLocationCount")]
        public IActionResult GetLocationCount()
        {
            var value = _mediator.Send(new GetLocationCountQuery());
            return Ok(value);
        }
        [HttpGet("GetAuthorCount")]
        public IActionResult GetAuthorCount()
        {
            var value = _mediator.Send(new GetAuthorCountQuery());
            return Ok(value);
        }
        [HttpGet("GetBrandCount")]
        public IActionResult GetBrandCount()
        {
            var value = _mediator.Send(new GetBrandCountQuery());
            return Ok(value);
        }
        [HttpGet("GetAvgRentPriceForDaily")]
        public IActionResult GetAvgRentPriceForDaily()
        {
            var value = _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(value);
        }
        [HttpGet("GetAvgRentPriceForWeekly")]
        public IActionResult GetAvgRentPriceForWeekly()
        {
            var value = _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(value);
        }
        [HttpGet("GetAvgRentPriceForMounthly")]
        public IActionResult GetAvgRentPriceForMounthly()
        {
            var value = _mediator.Send(new GetAvgRentPriceForMounthlyQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByTransmissionIsAuto")]
        public IActionResult GetCarCountByTransmissionIsAuto()
        {
            var value = _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(value);
        }
        [HttpGet("BrandNameByMaxCar")]
        public IActionResult BrandNameByMaxCar()
        {
            var value = _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(value);
        }
        [HttpGet("BlogTitleByMaxBlogComment")]
        public IActionResult BlogTitleByMaxBlogComment()
        {
            var value = _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountWithLessThan1000Kilometers")]
        public IActionResult GetCarCountWithLessThan1000Kilometers()
        {
            var value = _mediator.Send(new GetCarCountWithLessThan1000KilometersQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public IActionResult GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(value);
        }
        [HttpGet("GetCountByFuelElectric")]
        public IActionResult GetCountByFuelElectric()
        {
            var value = _mediator.Send(new GetCountByFuelElectricQuery());
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByDailyRentPriceMax")]
        public IActionResult GetCarBrandAndModelByDailyRentPriceMax()
        {
            var value = _mediator.Send(new GetCarBrandAndModelByDailyRentPriceMaxQuery());
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByDailyRentPriceMin")]
        public IActionResult GetCarBrandAndModelByDailyRentPriceMin()
        {
            var value = _mediator.Send(new GetCarBrandAndModelByDailyRentPriceMinQuery());
            return Ok(value);
        }
    }
}
