using System;

namespace AvaloniaApplication.Models;

public class WeatherData(
    string weather,
    int temperature,
    int visibility,
    int pressure,
    int humidity,
    int windSpeed)
{
    public string Weather { get; } = weather;
    public int Temperature { get; } = temperature;
    public int Visibility { get; } = visibility;
    public int Pressure { get; } = pressure;
    public int Humidity { get; } = humidity;
    public int WindSpeed { get; } = windSpeed;
}