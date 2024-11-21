using Microsoft.Extensions.Logging;

using MvvmToolkitExmple.Services;
using MvvmToolkitExmple.ViewModel;
using System.Resources;

namespace MvvmToolkitExmple
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif


            builder.Services.AddSingleton<IweatherWebService, WeatherService>();
            builder.Services.AddSingleton<VMWeather>();

            return builder.Build();
        }
    }
}
