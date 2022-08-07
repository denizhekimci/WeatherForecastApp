using System;
using System.Collections.Generic;
using System.Linq;


namespace WeatherForecast.Data.Entities
{
    public class Result 
    {
        public Result()
        {
            Success = false;
            Messages = new List<string>();
        }

        public bool Success { get; set; }
        public List<string> Messages { get; set; }


        public string Message { get { return Messages.FirstOrDefault(); } set { Messages.Add(value); } }

        public Exception Exception { get; set; }
        public Result SubResult { get; set; }
    }

    public class Result<T> : Result
    {
        public Result()
        {
            Success = false;
            Messages = new List<string>();
        }

        public T Data { get; set; }

    }
}
