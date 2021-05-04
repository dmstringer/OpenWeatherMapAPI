using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMapAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            // The OpenWeatherMapAPI requires you to be signed up with them to get an API key.
            // We will not hard code that key here
            Console.WriteLine("Please enter your API key:");
            var apiKey = Console.ReadLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the city name:");
                var cityName = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={apiKey}";

                var response = client.GetStringAsync(weatherURL).Result;
                // the JSON that is returned contains a 'main' key that has the info we want
                var formatResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formatResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose a different city?");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput.ToLower() == "no")
                {
                    break;
                }
            }
        }
    }
}
