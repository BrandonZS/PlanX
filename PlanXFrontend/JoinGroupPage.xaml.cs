namespace PlanXFrontend;

public partial class JoinGroupPage : ContentPage
{
	public JoinGroupPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
	}

	public async void btnBackJoinEvent_Clicked(object sender, EventArgs e){
		await Navigation.PopAsync();
	}
}