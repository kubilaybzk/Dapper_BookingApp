using System;
using Dapper_Web_Api.Repositorys.PopularLocation;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Web_Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _popularLocationRepository;

        public PopularLocationsController(IPopularLocationRepository popularLocationRepository)
        {
            _popularLocationRepository = popularLocationRepository;
        }


        [HttpGet]
        public async Task<IActionResult> PopularLocationList()
        {
            var value = await _popularLocationRepository.GetAllPopularLocationAsync();
            return Ok(value);
        }
    }
}

