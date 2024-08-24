using PlanXFrontend.Entidades.Entities;
using Newtonsoft.Json;
using PlanXFrontend.Entidades.Request.ReqEvento;
using PlanXFrontend.Entidades.Response.ResEvento;
using MauiApp1;

namespace PlanXFrontend;

public partial class JoinGroupPage : ContentPage
{
    string laUrl = App.API_URL;
    public JoinGroupPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
        enyJoinTitle.Text = InvitacionEvento.evento.nombre;
        enyJoinDescription.Text = InvitacionEvento.evento.descripcion;
        enyEventDuration.Text = InvitacionEvento.evento.duracion.ToString();
        dpEventExpectedDate.Date = InvitacionEvento.evento.fecHoraInicio.Date;
	}

	public async void btnBackJoinEvent_Clicked(object sender, EventArgs e){
		await Navigation.PopAsync();
	}

	public async void btnJoinEvent_Clicked(object sender, EventArgs e)
	{
        try
        {
            DateTime selectedDate = dpEventExpectedDate.Date;
            TimeSpan beginTime = tpRangeOne.Time;
            TimeSpan endTime = tpRangeTwo.Time;

            ReqRegistroEventoRegular req = new ReqRegistroEventoRegular();
            req.fecInicio = selectedDate.Add(beginTime);
            req.fecFinal = selectedDate.Add(endTime);
            req.idUser = Sesion.id;
            req.codInvi = InvitacionEvento.evento.codInvitacion;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(laUrl + "api/evento/registrareventoregular", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResRegistroEventoRegular res = new ResRegistroEventoRegular();

                res = JsonConvert.DeserializeObject<ResRegistroEventoRegular>(responseContent);

                if (res.resultado)
                {
                    DisplayAlert("Registro correcto", "Usuario se añadio correctamente", "Aceptar");
                    await Navigation.PushAsync(new Dashboard());
                }

            }
            else
            {
                DisplayAlert("Error de conexion", "Ocurrio un error de conexion", "Aceptar");
            }
        }
        catch (Exception ex)
        {

        }
    }
}