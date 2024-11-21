using MvvmToolkitExmple.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmToolkitExmple.Services
{
    public interface IweatherWebService
    {
        public  Task<WeatherResponse> GetWeatherAsync(string city);
    }
}
