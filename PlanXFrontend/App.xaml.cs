using MauiApp1;
using Syncfusion.Maui.Core.Converters;

namespace PlanXFrontend
{
    public partial class App : Application
    {
        public const string API_URL = "https://planxapi-ava5h8ayeje0erc3.mexicocentral-01.azurewebsites.net/";
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Dashboard()){
                BarBackgroundColor = Colors.Black,
                BarTextColor = Colors.White
            };
        }
    }
}
