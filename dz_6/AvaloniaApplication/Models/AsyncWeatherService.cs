using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models;

public class AsyncWeatherService
{
    private readonly WeatherService.WeatherService _service = new();

    private static WeatherData ConvertJson(string json)
    {
        var root = JsonDocument.Parse(json).RootElement;
        var weather = root.GetProperty("weather")[0].GetProperty("main").GetString();
        var temp = (int)(root.GetProperty("main").GetProperty("temp").GetSingle() - 273.15);
        var vis = root.GetProperty("visibility").GetInt32();
        var press = root.GetProperty("main").GetProperty("pressure").GetInt32();
        var hum = root.GetProperty("main").GetProperty("humidity").GetInt32();
        var ws = (int)root.GetProperty("wind").GetProperty("speed").GetSingle();
        return new WeatherData(weather, temp, vis, press, hum, ws);
    }

    public async Task<WeatherData> GetWeather()
    {
        var result = await Task.Run(() => ConvertJson(_service.GetDataSync(true)));
        return result;
    }
}