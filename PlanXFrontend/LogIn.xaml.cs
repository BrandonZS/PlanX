using PlanXFrontend;
using PlanXFrontend.Entidades.Entities;
using PlanXFrontend.Entidades.Response;
using PlanXFrontend.Entidades.Request;
using Newtonsoft.Json;



namespace MauiApp1;

public partial class LogIn : ContentPage
{
    string laUrl = App.API_URL;
    public LogIn()
	{
		InitializeComponent();
         NavigationPage.SetHasNavigationBar(this, false);
	}

	private async void btnLogInPass_Clicked(object sender, EventArgs e)
{
    try
	{
		//Validaciones
		
		ReqLogin req = new ReqLogin();
		req.email = enyMail.Text;
		req.password = enyPassword.Text;
 
		var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");
 
		HttpClient httpClient = new HttpClient();
 
		var response = await httpClient.PostAsync(laUrl + "api/login", jsonContent);
 
		if (response.IsSuccessStatusCode) //El API esta vivo???
		{
			//Si conectó
			var responseContent = await response.Content.ReadAsStringAsync();
			ResLogin res = new ResLogin();
 
			res = JsonConvert.DeserializeObject<ResLogin>(responseContent);
 
			if (res.resultado)
			{
				//Usuario y contraseña correctos. ¡Todo bien!
				Sesion.id = res.usuario.id;
				Sesion.nombre = res.usuario.nombre;
				Sesion.apellidos = res.usuario.apellidos;
				Sesion.token = res.usuario.token;
				Sesion.email = res.usuario.correoElectronico;
				Sesion.password = res.usuario.password;
				Sesion.codPais = res.usuario.codPais;
 
 
				//DisplayAlert("Login correcto", "¡Bienvenido(a) " + res.usuario.nombre +"!", "Aceptar");
				Navigation.PushAsync(new Dashboard());
			}
			else
			{
				DisplayAlert("Error en backend", "Login incorrecto!", "Aceptar");
			}
		}
		else
		{
			//No conectó
			DisplayAlert("Error de conexión", "Ocurrió un error de conexión", "Aceptar");
		}
	}
	catch (Exception ex)
	{
 
	}

}
}