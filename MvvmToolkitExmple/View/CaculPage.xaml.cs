namespace MvvmToolkitExmple.View
{
    public partial class CaculPage : ContentPage
    {
        public CaculPage()
        {
            InitializeComponent();
        }

        private async void OnCalculButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
