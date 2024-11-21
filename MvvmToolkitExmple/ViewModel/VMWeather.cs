
using MvvmToolkitExmple.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmToolkitExmple.ViewModel
{
    public class VMWeather : INotifyPropertyChanged
    {
        private readonly IweatherWebService _weatherService;
        private string _weatherInfo;
        public string WeatherInfo
        {
            get => _weatherInfo;
            set
            {
                _weatherInfo = value;
                OnPropertyChanged();
            }
        }

        public ICommand FetchWeatherCommand { get; }

        public VMWeather()
        {
            _weatherService = new WeatherService();
            FetchWeatherCommand = 
                new Command<string>(async (city) => await FetchWeatherAsync(city));
        }

        public async Task FetchWeatherAsync(string city)
        {
            try
            {
                var weather = await _weatherService.GetWeatherAsync(city);
                WeatherInfo = $"City: {weather.Location.Name}\n" +
                                $"Region: {weather.Location.Name}\n" +
                                $"country: {weather.Location.Country}\n" +
                              $"Temperature: {weather.Current.TempC}°C\n" +
                              $"Condition: {weather.Current.Condition.Text}";
            }
            catch (Exception ex)
            {
                WeatherInfo = "please enter a valid city name !";
            }
           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

