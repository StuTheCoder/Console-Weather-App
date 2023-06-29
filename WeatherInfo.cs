using System;
using System.Net;
using Newtonsoft.Json;

public class WeatherInfo
{
    [JsonProperty("main")]
    public WeatherDetails Details { get; set; }

    [JsonProperty("weather")]
    public WeatherCondition[] Conditions { get; set; }

    [JsonProperty("name")]
    public string Location { get; set; }
}