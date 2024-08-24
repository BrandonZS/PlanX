using Newtonsoft.Json;
using PlanXFrontend;
using PlanXFrontend.Entidades.Entities;
using PlanXFrontend.Entidades.Request.ReqEvento;
using PlanXFrontend.Entidades.Response.ResEvento;

namespace MauiApp1;

public partial class CreateEventPage : ContentPage
{
    string laUrl = App.API_URL;
    public CreateEventPage()
	{
		InitializeComponent();
	}
    private async void btnCreateEvent_Clicked(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(enyTitle.Text))
        {
            DisplayAlert("Error", "Please enter a title", "Acept");
        }
        else if (String.IsNullOrEmpty(enyDescription.Text))
        {
            DisplayAlert("Error", "Please enter a description", "Acept");
        }
        else if (enyDuracion == null)
        {
            DisplayAlert("Error", "Please enter duration", "Acept");
        }
        else if (enyMaxPersonas.Text == "0")
        {
            DisplayAlert("Error", "Enter Max people", "Acept");
        }
        else
        {

            try
            {
                DateTime selectedDate = datePicker.Date;
                TimeSpan beginTime = timeBeginPicker.Time;
                TimeSpan endTime = timeEndPicker.Time;


                ReqInsertarEvento req = new ReqInsertarEvento();
                req.nombre = enyTitle.Text;
                req.descripcion = enyDescription.Text;
                req.fecHoraInicio = selectedDate.Add(beginTime);
                req.fecHoraFin = selectedDate.Add(endTime);
                req.limUsers = int.Parse(enyMaxPersonas.Text);
                req.duracion = float.Parse(enyDuracion.SelectedItem.ToString());
                req.idUsuario = Sesion.id;

                var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();

                var response = await httpClient.PostAsync(laUrl + "api/evento/insertarevento", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    ResInsertarEvento res = new ResInsertarEvento();

                    res = JsonConvert.DeserializeObject<ResInsertarEvento>(responseContent);

                    if (res.resultado)
                    {
                        DisplayAlert("Nice!", "Task Added", "OK");
                        await Navigation.PopAsync();
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
}