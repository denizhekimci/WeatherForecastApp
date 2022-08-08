using Microsoft.AspNetCore.Mvc;
using WeatherForecast.UI.Model;

namespace WeatherForecast.UI.Controllers
{
    using System.Globalization;
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

            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(weather.Dt).ToLocalTime();

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var desc = weather.Weather.FirstOrDefault().Description;

            var model = new WeatherForecastViewModel
            {
                Name = weather.Name,
                Description = textInfo.ToTitleCase(desc),
                Temperature = Math.Round(tempC, 2),
                Date = dtDateTime.ToString()
            };

            MyHelper.MyList.Add(model);

            return Json(new
            {
                data = MyHelper.MyList
            });
        }
    }
}
