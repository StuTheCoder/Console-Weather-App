using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WeatherDetails
{
    [JsonProperty("temp")]
    public double Temperature { get; set; }

    [JsonProperty("humidity")]
    public double Humidity { get; set; }
}