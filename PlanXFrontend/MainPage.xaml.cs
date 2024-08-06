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
            //SignIn es en realidad LogIn se confuncieron los no,bres en el sistema
            
        }

        private async void btnLogIn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SignIn");
        }

 
    }

}
