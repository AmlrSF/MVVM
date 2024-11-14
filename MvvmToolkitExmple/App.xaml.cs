using System.Resources;

namespace MvvmToolkitExmple
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            ResourceManager rm = new ResourceManager("FactureResource", typeof(App).Assembly);
            var globalSetting = new ApplicationContext(rm);

        }
    }
}
