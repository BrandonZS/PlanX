using System.ComponentModel.DataAnnotations;
using PlanXFrontend;

namespace MauiApp1;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
		InitializeComponent();
        NavigationPage.SetHasBackButton(this, false);

	}

	private void myButton_Pressed(object sender, EventArgs e)
{
    btnCreateEvent.BorderColor = Colors.BlueViolet;
    btnCreateEvent.BorderWidth = 2;
    btnCreateEvent.TextColor = Colors.BlueViolet;
}
    private void myButton_Released(object sender, EventArgs e)
{
    btnCreateEvent.BorderColor = Colors.Black;
    btnCreateEvent.BorderWidth = 1;
    btnCreateEvent.TextColor= Colors.Black;

}
	private async void tbiJoinGroup_Clicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Join Event", "What's your Code?", maxLength:6);
        if(result == "123456"){
            await Navigation.PushAsync(new JoinGroupPage()); 
        }else{
            await DisplayAlert("Sorry!!", "Your Code Is Invalid", "OK");
        }
        
    }
    private async void tbiTask_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new);
    }
    private async void tbiAccount_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccountPage());
    }
    private async void btnCreateEvent_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateEventPage());

	}
}