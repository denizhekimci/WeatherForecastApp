using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.UI.Controllers
{
    using WeatherForecast.Service.Weather;
    public class WeatherController : Controller
    {
        IWeatherService _weatherService;
        public WeatherController(
            IWeatherService weatherService) 
        { 
            _weatherService = weatherService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetWeatherForecast()
        {
            var weather = _weatherService.GetWeatherForecast(39.9334, 32.8597);
            Console.WriteLine(weather.ToString());
            return Json(weather);
        }
    }
}
