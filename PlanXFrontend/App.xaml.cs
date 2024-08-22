using MauiApp1;
using Syncfusion.Maui.Core.Converters;

namespace PlanXFrontend
{
    public partial class App : Application
    {
        public const string API_URL = "https://localhost:44302/";
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage()){
                BarBackgroundColor = Colors.Black,
                BarTextColor = Colors.White
            };
        }
    }
}
