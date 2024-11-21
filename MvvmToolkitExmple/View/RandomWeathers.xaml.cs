namespace MvvmToolkitExmple.View;

public partial class RandomWeathers : ContentPage
{
	public RandomWeathers()
	{
		InitializeComponent();
	}

    private async void OnCalculButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

}