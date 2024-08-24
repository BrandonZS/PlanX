using MauiApp1;
using Newtonsoft.Json;
using PlanXFrontend.Entidades.Entities;
using PlanXFrontend.Entidades.Request;
using PlanXFrontend.Entidades.Response;

namespace PlanXFrontend;

public partial class DefineEventPage : ContentPage
{
    string laUrl = App.API_URL;
    public class ObjectList()
	{

		public string fecInicio { get; set; }
		public string fecFinal { get; set; }
		public int usersCount { get; set; }
	}
	public class CollectionObjectList()
	{
		public List<ObjectList> list = new List<ObjectList>();
	}
    
    public DefineEventPage()
	{
		InitializeComponent();
        this.ToolbarItems.Clear();
		
		CollectionObjectList collection = new CollectionObjectList();
		

		foreach(Horario horarios in ListaHorarios.listaHorarios)
		{
            ObjectList objectList = new ObjectList();

            objectList.fecInicio = horarios.horaInicio.ToString();
            objectList.fecFinal = horarios.horaFinal.ToString();
            objectList.usersCount = horarios.registros.Count;

			collection.list.Add(objectList);
        }


        listView.ItemsSource = collection.list;
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        // Aqu� puedes manejar el item seleccionado
        var selectedHorario = e.SelectedItem as ObjectList;

        // Por ejemplo, mostrar una alerta con la informaci�n del horario seleccionado
        bool answer = await DisplayAlert("Horario Seleccionado",
            $"Inicio: {selectedHorario.fecInicio}, Final: {selectedHorario.fecFinal}",
            "Continuar", "Cancelar");

        if (answer)
        {
            definirEvento(selectedHorario.fecInicio, selectedHorario.fecFinal);
            Navigation.PushAsync(new Dashboard());
        }

        // Deselect the item to allow future selection
        listView.SelectedItem = null;
    }


    private async void definirEvento(string fecInicial, string fecFinal)
    {
        //Validaciones
        try 
        { 
            ReqDefinirEvento req = new ReqDefinirEvento();
            req.horaInicial = DateTime.Parse(fecInicial);
            req.horaFinal = DateTime.Parse(fecFinal);
            req.id = Sesion.id;
            req.codInvitacion = InvitacionEvento.eventoPropio.codInvitacion;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PutAsync(laUrl + "api/evento/definirevento", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResDefinirEvento res = new ResDefinirEvento();

                res = JsonConvert.DeserializeObject<ResDefinirEvento>(responseContent);

                if (res.resultado)
                {
                    DisplayAlert("Insercion correcta", "Usuario se a�adio correctamente", "Aceptar");
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