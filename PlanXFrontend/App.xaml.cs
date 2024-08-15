using MauiApp1;
using Syncfusion.Maui.Core.Converters;

namespace PlanXFrontend
{
    public partial class App : Application
    {
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
