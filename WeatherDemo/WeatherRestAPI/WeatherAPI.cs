using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp2.WeatherRestAPI
{
    internal class WeatherAPI
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;


        public WeatherAPI()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<WeatherInfo> GetWeatherInfo()
        {
            WeatherInfo weatherInfo = new WeatherInfo();
         
            Uri uri = new Uri("https://api.openweathermap.org/data/2.5/weather?lat=40.7128&lon=-74.0060&units=imperial&appid=" + File.ReadAllText("api_key.txt"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(content);
                    weatherInfo = JsonSerializer.Deserialize<WeatherInfo>(content, _serializerOptions);
                    var iconID = weatherInfo.weather[0].icon;
                    weatherInfo.weather[0].icon = "http://openweathermap.org/img/wn/" + iconID + "@2x.png";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return weatherInfo;
        }
    }
}
