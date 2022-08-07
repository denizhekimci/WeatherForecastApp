using Newtonsoft.Json;

namespace WeatherForecast.Data.Entities
{
    public class WeatherForecast
    {
        public partial class Temperatures
        {
            [JsonProperty("weather")]
            public Weather[] Weather { get; set; }
            [JsonProperty("main")]
            public Temps[] Temps { get; set; } 
        }

        public partial class Weather
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("main")]
            public string Main { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }
        }

        public partial class Temps
        {
            [JsonProperty("temp")]
            public double Temp { get; set; }
            [JsonProperty("feels_like")]
            public double FeelsLike { get; set; }
            [JsonProperty("humidity")]
            public long Humidity { get; set; }
        }
    }
}