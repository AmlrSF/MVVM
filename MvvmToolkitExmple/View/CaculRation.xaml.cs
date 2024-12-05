namespace MvvmToolkitExmple.View;

public partial class CaculRation : ContentPage
{
	public CaculRation()
	{
		InitializeComponent();
	}


    private async void NavigateToForragePage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//FourragePage");
    }

}