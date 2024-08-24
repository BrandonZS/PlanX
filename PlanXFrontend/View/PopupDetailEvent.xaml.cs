using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using PlanXFrontend.Entidades.Entities;
using PlanXFrontend.Entidades.Request;
using PlanXFrontend.Entidades.Request.ReqEvento;
using PlanXFrontend.Entidades.Response;

namespace PlanXFrontend.View;

public partial class PopupDetailEvent : Popup
{
    string laUrl = App.API_URL;
    public PopupDetailEvent()
	{
		InitializeComponent();
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
                        if(ListaHorarios.listaHorarios.Count != 0)
                        {
                            ListaHorarios.listaHorarios.Clear();
                        }
                        foreach (Horario horario in res.horarios)
                        {
                            ListaHorarios.listaHorarios.Add(horario);
                        }
                    Close(true);
                    }
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