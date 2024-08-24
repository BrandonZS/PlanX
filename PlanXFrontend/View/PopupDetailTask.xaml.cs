using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using PlanXFrontend.Entidades.Entities;
using PlanXFrontend.Entidades.Request.ReqTarea;
using PlanXFrontend.Entidades.Response;

namespace PlanXFrontend.View;

public partial class PopupDetailTask : Popup
{
    string laUrl = App.API_URL;
    public PopupDetailTask()
	{
		InitializeComponent();
		enyTitle.Text = TareaEstatica.staticTask.titulo;
		enyDescription.Text = TareaEstatica.staticTask.descripcion;
		enyPriority.Text = TareaEstatica.staticTask.prioridad;
        datePicker.Date = TareaEstatica.staticTask.fecHoraInicio;
        timeBeginPicker.Time = TareaEstatica.staticTask.fecHoraInicio.TimeOfDay;
        timeEndPicker.Time = TareaEstatica.staticTask.fecHoraFin.TimeOfDay;
    }

    private async void btnEditEvent_Clicked(object sender, EventArgs e)
    {
        try
        {
            ReqActualizarTarea req = new ReqActualizarTarea();
            req.idUser = Sesion.id;
            req.idTarea = TareaEstatica.staticTask.id;
            req.titulo = enyTitle.Text;
            req.descripcion = enyDescription.Text;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PutAsync(laUrl + "api/tarea/actualizartarea", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResBase res = new ResBase();

                res = JsonConvert.DeserializeObject<ResBase>(responseContent);
                Close(true);


            }
            else
            {
            }
        }
        catch (Exception ex)
        {

        }
    }

    private async void btnDeleteEvent_Clicked(object sender, EventArgs e)
    {
        try
        {
            ReqEliminarTarea req = new ReqEliminarTarea();
            req.idUser = Sesion.id;
            req.idTarea = TareaEstatica.staticTask.id;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(laUrl + "api/tarea/eliminartarea", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResBase res = new ResBase();

                res = JsonConvert.DeserializeObject<ResBase>(responseContent);

                Close(true);


            }
            else
            {
            }
        }
        catch (Exception ex)
        {

        }
    }
}