namespace PlanXFrontend;
using PlanXFrontend.Entidades.Entities;
using PlanXFrontend.Entidades.Request;
using PlanXFrontend.Entidades.Request.ReqTarea;
using PlanXFrontend.Entidades.Response;
using Newtonsoft.Json;
using PlanXFrontend.Entidades.Response.ResTarea;

public partial class CreateTaskPage : ContentPage
{
	string laUrl = App.API_URL;
	public CreateTaskPage()
	{
		InitializeComponent();
	}

	private async void btnCreateTask_Clicked(object sender, EventArgs e){
		try{
			DateTime selectedDate = datePickerTask.Date;
            TimeSpan beginTime = timeBeginPickerTask.Time;
            TimeSpan endTime = timeEndPickerTask.Time;
			ReqInsertarTarea req = new ReqInsertarTarea();
	        req.idUsuario = Sesion.id;		
			req.titulo = enyTitleTask.Text;
            req.descripcion = enyDescriptionTask.Text;
            req.fecHoraInicio = selectedDate.Add(beginTime);
            req.fecHoraFin = selectedDate.Add(endTime);
            req.prioridad = enyPriorityTask.SelectedItem.ToString();


            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(laUrl + "api/tarea/insertartarea", jsonContent);

			if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResInsertarTarea res = new ResInsertarTarea();
                res = JsonConvert.DeserializeObject<ResInsertarTarea>(responseContent);

                if (res.resultado)
                {
                    DisplayAlert("Nice!!", "Your Task Was Added", "OK");
                    await Navigation.PushAsync(new TasksPage());
                }

            }
            else
            {
                DisplayAlert("Sorry!!", "You Had An Conexion Error", "OK");
            }

		}catch{

		}
	}
}