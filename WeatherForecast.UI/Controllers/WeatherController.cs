using Microsoft.AspNetCore.Mvc;
using WeatherForecast.UI.Model;

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
            var model = new WeatherForecastViewModel
            {
                Name = weather.Name,
                Description = weather.Weather.FirstOrDefault().Description,
                Temperature = weather.Main.Temp
            };

            return Json(new
            {
                data = model
            });
        }
    }
}
