using PlanXFrontend;

namespace MauiApp1;

public partial class LogIn : ContentPage
{
	public LogIn()
	{
		InitializeComponent();
         NavigationPage.SetHasNavigationBar(this, false);
	}

	private async void btnLogInPass_Clicked(object sender, EventArgs e)
{
    if (enyMail.Text == "angel" && enyPassword.Text == "1"){
        await Navigation.PushAsync(new Dashboard());
    }
    else{
        await DisplayAlert("Error", "El email o la contraseña son incorrectos.", "OK");
    }
}
}