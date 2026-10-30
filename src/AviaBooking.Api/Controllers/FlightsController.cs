using AviaBooking.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AviaBooking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;

        //Через конструктор внедряем наш сервис
        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        /// <summary>
        /// Получить список всех рейсов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllFlights()
        {
            var result = await _flightService.GetAllFlightsAsync();
            return Ok(result);
        }

    }
}
