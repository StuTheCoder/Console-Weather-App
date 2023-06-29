using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public class WeatherApp
{
    private const string ApiKey = "831785aea4fb86a2fb75c22790e5fc2d";

    public void Run()
    {
        Console.WriteLine("Welcome to WeatherApp");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Enter a location (or 'exit' to Exit)");
            string location = Console.ReadLine();

            if (location.ToLower() == "exit")
            {
                Console.WriteLine("Thank you for using WeatherApp!");
                break;
            }

            WeatherInfo weatherInfo = GetWeatherInfo(location);

            if (weatherInfo != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Weather information for {weatherInfo.Location}:");
                Console.WriteLine($"Temperature: {weatherInfo.Details.Temperature}°C");
                Console.WriteLine($"Humidity: {weatherInfo.Details.Humidity}%");
                Console.WriteLine($"Condition: {weatherInfo.Conditions[0].Main} - {weatherInfo.Conditions[0].Description}");
            }
            else
            {
                Console.WriteLine("Failed to retrieve weather info.");
            }
        }
    }

    private WeatherInfo GetWeatherInfo(string location)
    {
        try
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={location}&units=metric&appid={ApiKey}";

            using (WebClient webClient = new WebClient())
            {
                string json = webClient.DownloadString(url);
                WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(json);

                return weatherInfo;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }
}