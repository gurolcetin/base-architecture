using BaseArchitecture.BLL.Concrete;
using BaseArchitecture.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BaseArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger; 
        private readonly EntityManager<WeatherForecast> _weatherForecastManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, EntityManager<WeatherForecast> weatherForecastManager)
        {
            _logger = logger;
            _weatherForecastManager = weatherForecastManager;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastManager.GetAll();
        }

        [HttpGet("{id}", Name = "GetFirst")]
        public WeatherForecast GetFirst(int id)
        {
            return _weatherForecastManager.GetFirst(x=>x.Id == id);
        }
    }
}