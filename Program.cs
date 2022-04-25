using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;

namespace WeatherApp
{
    public class Program
    {
         static void Main(string[] args)
        {
            var key = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(key).GetValue("myWeatherKey").ToString();

            Console.WriteLine("Please enter you zip code.");
            var zipCode = Console.ReadLine();

            var apiCall = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&units=imperial&appid{apiKey}";

            var client = new HttpClient();

            var response = client.GetStringAsync(apiCall).Result;

            var temp = double.Parse(JObject.Parse(response)["main"]["temp"].ToString());

            Console.WriteLine($"It is currently {temp} degrees Fahrenheit");
        }
    }
}
