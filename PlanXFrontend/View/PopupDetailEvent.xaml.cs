using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using PlanXFrontend.Entidades.Entities;
using PlanXFrontend.Entidades.Request;
using PlanXFrontend.Entidades.Request.ReqEvento;
using PlanXFrontend.Entidades.Response;
using PlanXFrontend.Entidades.Response.ResEvento;

namespace PlanXFrontend.View;

public partial class PopupDetailEvent : Popup
{
    string laUrl = App.API_URL;
    public PopupDetailEvent()
	{
        InitializeComponent();
        if (InvitacionEvento.eventoPropio.estado)
        {
            btnViewScheduleEvent.IsVisible = false;
        }
        enyTitle.Text = InvitacionEvento.eventoPropio.nombre;
		enyDescription.Text = InvitacionEvento.eventoPropio.descripcion;
		enyDuracion.Text = InvitacionEvento.eventoPropio.duracion.ToString();
		enyMaxPersonas.Text = InvitacionEvento.eventoPropio.limUsers.ToString();
		datePicker.Date = InvitacionEvento.eventoPropio.fecHoraInicio;
		timeBeginPicker.Time = InvitacionEvento.eventoPropio.fecHoraInicio.TimeOfDay;
		timeEndPicker.Time = InvitacionEvento.eventoPropio.fecHoraFin.TimeOfDay;

		
    }

    private async void btnViewScheduleEvent_Clicked(object sender, EventArgs e)
    {

            try
            {

                ReqObtenerEvento req = new ReqObtenerEvento();
                req.codInv = InvitacionEvento.eventoPropio.codInvitacion;

                var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();

                var response = await httpClient.PostAsync(laUrl + "api/evento/obtenerhorario", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    if (ListaEventos.eventos.Count != 0)
                    {
                        ListaEventos.eventos.Clear();
                    }
                    var responseContent = await response.Content.ReadAsStringAsync();
                    ResObtenerHorarios res = new ResObtenerHorarios();

                    res = JsonConvert.DeserializeObject<ResObtenerHorarios>(responseContent);

                    if (res.horarios.Count > 0)
                    {
                        if (ListaHorarios.listaHorarios.Count != 0)
                        {
                            ListaHorarios.listaHorarios.Clear();
                        }
                        foreach (Horario horario in res.horarios)
                        {
                            ListaHorarios.listaHorarios.Add(horario);
                        }
                        Close(true);
                    }
                    else
                    {
                    Close();
                    }
                }
                else
                {
                btnViewScheduleEvent.Text = "Sin Registos";
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
            ReqEliminarEvento req = new ReqEliminarEvento();
            req.id = Sesion.id;
            req.codInvi = InvitacionEvento.eventoPropio.codInvitacion;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(laUrl + "api/evento/eliminarevento", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResEliminarEvento res = new ResEliminarEvento();

                res = JsonConvert.DeserializeObject<ResEliminarEvento>(responseContent);

                    Close();
                

            }
            else
            {
            }
        }
        catch (Exception ex)
        {

        }
    }

    private async void btnEditEvent_Clicked(object sender, EventArgs e)
    {
        try
        {
            ReqActualizarEvento req = new ReqActualizarEvento();
            req.id = Sesion.id;
            req.codInvi = InvitacionEvento.eventoPropio.codInvitacion;
            req.titulo = enyTitle.Text;
            req.descripcion = enyDescription.Text;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PutAsync(laUrl + "api/evento/actualizarevento", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResActualizarEvento res = new ResActualizarEvento();

                res = JsonConvert.DeserializeObject<ResActualizarEvento>(responseContent);
                Close();


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