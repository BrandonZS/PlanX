using PlanXFrontend;
using PlanXFrontend.Entidades.Entities;
using Newtonsoft.Json;
using PlanXFrontend.Entidades.Request.ReqEvento;
using PlanXFrontend.Entidades.Response.ResEvento;
namespace MauiApp1;

public partial class Dashboard : ContentPage
{

    string laUrl = App.API_URL;

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ObtenerEvento();
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
	
    private async void tbiTask_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TasksPage());
    }
    private async void tbiAccount_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccountPage());
    }
    private async void btnCreateEvent_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateEventPage());

	}
    private async Task ObtenerEvento(){


        try
        {

            ReqObtenerListaEventos req = new ReqObtenerListaEventos();
            req.id = Sesion.id;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(laUrl + "api/evento/obtenerlistaevento", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                if(ListaEventos.eventos.Count != 0)
                {
                    ListaEventos.eventos.Clear();
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                ResObtenerListaEventos res = new ResObtenerListaEventos();

                res = JsonConvert.DeserializeObject<ResObtenerListaEventos>(responseContent);
                
                if (res.resultado && res.listaEventos.Count>0)
                {
                    foreach (Evento evento in res.listaEventos)
                    {
                        ListaEventos.eventos.Add(evento);
                    }
                    
                }
                else if (res.resultado)
                {
                    DisplayAlert("Error en backend", "Login incorrecto!", "Aceptar");
                }
            }
            else
            {
                DisplayAlert("Error de conexión", "Ocurrió un error de conexión", "Aceptar");
            }
        }
        catch (Exception ex)
        {

        }

    }
    private async void tbiJoinGroup_Clicked(object sender, EventArgs e)
    {

        string result = await DisplayPromptAsync("Join Event", "What's your Code?", maxLength: 6);
        try
        {
            ReqObtenerEvento req = new ReqObtenerEvento();
            req.codInv = result;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(laUrl + "api/evento/obtenerevento", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResObtenerEvento res = new ResObtenerEvento();

                res = JsonConvert.DeserializeObject<ResObtenerEvento>(responseContent);

                if (res.resultado)
                {
                    InvitacionEvento.evento.nombre = res.evento.nombre;
                    InvitacionEvento.evento.descripcion = res.evento.descripcion;
                    InvitacionEvento.evento.codInvitacion = res.evento.codInvitacion;
                    await Navigation.PushAsync(new JoinGroupPage());
                }
                else
                {
                    await DisplayAlert("Sorry!!", "Your Code Is Invalid", "OK");
                }
            }
            else
            {
                DisplayAlert("Error de conexión", "Ocurrió un error de conexión", "Aceptar");
            }
        }
        catch (Exception ex) 
        { 

        }


    }

}