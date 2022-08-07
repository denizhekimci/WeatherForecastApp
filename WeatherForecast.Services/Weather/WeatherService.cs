using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Service.Weather
{
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System.Net.Http.Headers;
    using WeatherForecast.Data.Entities;
    public class WeatherService : IWeatherService
    {
        private IConfiguration _iConfig;

        public WeatherService(IConfiguration iConfig)
        {
            _iConfig = iConfig;
        }

        private async Task<Result<string>> MakeRequestAsync(string path, Dictionary<string, double> queries, string fullPath = "", string jsonData = "")
        {
            try
            {
                if (fullPath == "")
                {
                    fullPath = Path.Combine(path);

                    fullPath += "?";
                    foreach (var item in queries)
                    {
                        fullPath += item.Key + "=" + item.Value + "&";
                    }

                    fullPath += "appid" + "=" + "0a7f4479ca5b9f99ab40b530d42bc11a";

                }

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                string jsonContent = "";
                
                var response = await client.GetAsync(fullPath);
                jsonContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode == false) return new Result<string> { Data = null, Success = false, Message = response.ReasonPhrase + " : " + jsonContent };
                

                return new Result<string> { Data = jsonContent, Success = true };
            }
            catch (Exception ex)
            {
                return new Result<string> { Data = null, Success = false, Message = ex.Message, Exception = ex };
            }
        }

        public OpenWeatherResponse GetWeatherForecast(double latitude, double longitude)
        {
            var data = new Dictionary<string, double>();
            data.Add("lat", latitude);
            data.Add("lon", longitude);

            var responseText = MakeRequestAsync("https://api.openweathermap.org/data/2.5/weather", data).GetAwaiter().GetResult();
            if (responseText.Success == false)
            {
                throw new Exception("API Weather Error", responseText.Exception);
            }

            var forecast = JsonConvert.DeserializeObject<OpenWeatherResponse>(responseText.Data);
            return forecast;
        }
    }
}
