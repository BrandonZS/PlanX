using PlanXFrontend.Entidades.Entities;
using PlanXFrontend.Entidades.Request.ReqTarea;
using Newtonsoft.Json;
using PlanXFrontend.Entidades.Response.ResTarea;

namespace PlanXFrontend;

public partial class TasksPage : ContentPage
{
	string laUrl = App.API_URL;
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await ObtenerTarea();
		InitializeComponent();
	}

	private async void btnAddTask_Clicked(object sender, EventArgs e){
		await Navigation.PushAsync(new CreateTaskPage());
	}

	private async Task ObtenerTarea(){


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
} 