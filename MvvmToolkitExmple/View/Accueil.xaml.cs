using Microsoft.Maui.Controls;

namespace MvvmToolkitExmple.View
{
    public partial class Accueil : ContentPage
    {
        public Accueil()
        {
            InitializeComponent(); 
        }


        private async void OnCalculButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//CaculPage");
        }

        private async void OnCalculButtonClickedWeather(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//RandomWeatherPage");
        }

        private async void OnCalculRationButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//CaculRation");
        }

    }
}
