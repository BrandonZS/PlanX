using MauiApp1;
using Syncfusion.Maui.Core.Converters;

namespace PlanXFrontend
{
    public partial class App : Application
    {
        public const string API_URL = "https://planexapi-evbcbxaeanb5c4bc.westus2-01.azurewebsites.net/";
        
        /// public const string API_URL = "https://localhost:44302/";
        
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF1cWWhBYVF/WmFZfVpgdVRMY1hbQH5PIiBoS35RckVrW31cc3dRQmhUVEZ3");
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage()){
                BarBackgroundColor = Colors.Black,
                BarTextColor = Colors.White
            };
        }
    }
}
