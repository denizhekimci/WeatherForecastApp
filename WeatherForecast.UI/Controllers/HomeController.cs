using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
