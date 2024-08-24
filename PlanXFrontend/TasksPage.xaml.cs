using PlanXFrontend.Entidades.Entities;
using PlanXFrontend.Entidades.Request.ReqTarea;
using Newtonsoft.Json;
using PlanXFrontend.Entidades.Response.ResTarea;
using PlanXFrontend.View;
using CommunityToolkit.Maui.Views;
using Syncfusion.Maui.Scheduler;

namespace PlanXFrontend;

public partial class TasksPage : ContentPage
{
	string laUrl = App.API_URL;
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await ObtenerTarea();
        this.ToolbarItems.Clear();
		InitializeComponent();
	}

	private async void btnAddTask_Clicked(object sender, EventArgs e){
		await Navigation.PushAsync(new CreateTaskPage());
	}

	private async Task ObtenerTarea(){
        if (ListaTareas.tareas.Count != 0)
        {
            ListaTareas.tareas.Clear();
        }

        try
        {

            ReqObtenerListaTarea req = new ReqObtenerListaTarea();
            req.id = Sesion.id;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(laUrl + "api/tarea/obtenertarea", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResObtenerListaTarea res = new ResObtenerListaTarea();

                res = JsonConvert.DeserializeObject<ResObtenerListaTarea>(responseContent);
                
                if (res.resultado && res.listaTareas.Count>0)
                {
                    foreach (Tarea tarea in res.listaTareas)
                    {
                        ListaTareas.tareas.Add(tarea);
                    }
                    
                }
                else if (res.resultado)
                {
                    DisplayAlert("Nice!!", "", "Aceptar");
                }
            }
            else
            {
                DisplayAlert("Ohh!!", "There Might Be An Error In The Connection", "OK");
            }
        }
        catch (Exception ex)
        {

        }

    }

    private async void Onscheduler_Tapped(object sender, Syncfusion.Maui.Scheduler.SchedulerTappedEventArgs e)
    {
        if (e.Appointments != null)
        {
            var defineTask = e.Appointments.FirstOrDefault() as SchedulerAppointment;


            foreach(Tarea tarea in ListaTareas.tareas)
            {
                if(tarea.id.ToString() == defineTask.Id.ToString())
                {
                    TareaEstatica.staticTask = tarea;
                }
            }

            var popup = new PopupDetailTask();
            var result = await this.ShowPopupAsync(popup);
            if (result is bool shouldNavigate && shouldNavigate)
            {
                await Navigation.PushAsync(new TasksPage());
            }
        }
    }
}