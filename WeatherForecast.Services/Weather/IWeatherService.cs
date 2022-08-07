using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Service.Weather
{
    using WeatherForecast.Data.Entities;
    public interface IWeatherService
    {
        OpenWeatherResponse GetWeatherForecast(double latitude, double longitude);
    }
}
