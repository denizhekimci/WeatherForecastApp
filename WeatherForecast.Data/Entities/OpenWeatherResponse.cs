using Newtonsoft.Json;

namespace WeatherForecast.Data.Entities
{
    public class OpenWeatherResponse
    {
        public string Name { get; set; }

        public List<WeatherDescription> Weather { get; set; }

        public Main Main { get; set; }
    }

    public class WeatherDescription
    {
        public string Main { get; set; }
        public string? Description { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
    }
}