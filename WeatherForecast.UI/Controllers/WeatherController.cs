using Microsoft.AspNetCore.Mvc;
using WeatherForecast.UI.Model;

namespace WeatherForecast.UI.Controllers
{
    using WeatherForecast.Service.Weather;

    public static class MyHelper
    {
        static MyHelper()
        {
            MyList = new List<WeatherForecastViewModel>();
        }

        public static IList<WeatherForecastViewModel> MyList { get; set; }
    }

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

            var tempC = weather.Main.Temp - 273.15;
            var model = new WeatherForecastViewModel
            {
                Name = weather.Name,
                Description = weather.Weather.FirstOrDefault().Description,
                Temperature = Math.Round(tempC, 2)
            };

            MyHelper.MyList.Add(model);

            return Json(new
            {
                data = MyHelper.MyList
            });
        }
    }
}
