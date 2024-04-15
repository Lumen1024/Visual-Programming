using System;
using System.Threading;
using AvaloniaApplication.Models;
using ReactiveUI;

namespace AvaloniaApplication.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly AsyncWeatherService _service = new();
    private Timer timer;
    
    private DateTime _currentTime;
    public DateTime CurrentTime
    {
        get => _currentTime;
        set
        {
            _currentTime = value;
            this.RaiseAndSetIfChanged(ref _currentTime, value);
        }
    }

    private WeatherData? _weather;

    public WeatherData? Weather
    {
        get => _weather;
        set => this.RaiseAndSetIfChanged(ref _weather, value);
    }
    
    private bool _isLoading = true;

    public bool IsLoading
    {
        get => _isLoading;
        set => this.RaiseAndSetIfChanged(ref _isLoading, value);
    }
    
    private string _weatherPicture = "";

    public string WeatherPicture
    {
        get => _weatherPicture;
        set => this.RaiseAndSetIfChanged(ref _weatherPicture, value);
    }

    public MainWindowViewModel()
    {
        var t = _service.GetWeather();
        t.ContinueWith((task) =>
        {
            if (!task.IsCompleted) return;
            Weather = task.Result;
            switch (task.Result.Weather)
            {
                case "Rain": WeatherPicture = "/Assets/rain.svg";
                    break;
                case "Sun": WeatherPicture = "/Assets/sun.svg";
                    break;
            };
            IsLoading = false;
        });
        timer = new Timer(UpdateCurrentTime, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
    }
    
    private void UpdateCurrentTime(object? state)
    {
        CurrentTime = DateTime.Now;
    }
}