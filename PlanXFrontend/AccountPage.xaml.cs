namespace PlanXFrontend;

public partial class AccountPage : ContentPage
{
	public AccountPage()
	{
		InitializeComponent();
	}

	        public async void ChangePassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePasswordPage());
        }
}