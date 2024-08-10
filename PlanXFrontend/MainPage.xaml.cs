using MauiApp1;

namespace PlanXFrontend
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Tap_SignIn(object sender, TappedEventArgs e)
        {

            await Navigation.PushAsync(new SignIn());
        }

        private async void btnLogIn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogIn());
        }

 
    }

}
