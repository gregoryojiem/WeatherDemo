using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDemo.WeatherRestAPI
{
    public class WeatherInfo
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string baseStr { get; set; } // Renamed to avoid keyword conflict
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

        public string GetIconURI()
        {
            return weather[0].icon;
        }

        public string GetTemperature()
        {
            return main.temp.ToString() + "°F";
        }

        public string GetWeatherStatus()
        {
            return weather[0].description;
        }

        public string GetLocation()
        {
            return name + ", " + sys.country;
        }

        public string GetHumidity()
        {
            return main.humidity.ToString() + "%";
        }

        public string GetCloudCoverage()
        {
            return clouds.all + "%";
        }

        public string GetFeelsLike()
        {
            return main.feels_like.ToString() + "°F";
        }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}
