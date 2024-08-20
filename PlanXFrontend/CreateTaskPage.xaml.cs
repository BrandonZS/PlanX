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
			ReqCrearTarea req = new ReqCrearTarea();
			req.tarea = new Tarea();
	        req.tarea.idUsuario = Sesion.id;		
			req.tarea.titulo = enyTitleTask.Text;
            req.tarea.descripcion = enyDescriptionTask.Text;
            req.tarea.fecHoraInicio = selectedDate.Add(beginTime);
            req.tarea.fecHoraFin = selectedDate.Add(endTime);

			var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(laUrl + "api/tarea/insertartarea", jsonContent);

			if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResCrearTarea res = new ResCrearTarea();
                res = JsonConvert.DeserializeObject<ResCrearTarea>(responseContent);

                if (res.resultado)
                {
                    DisplayAlert("Nice!!", "Your Task Was Added", "OK");
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