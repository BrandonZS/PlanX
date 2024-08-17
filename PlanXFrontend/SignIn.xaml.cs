using Newtonsoft.Json;
using PlanXFrontend;
using PlanXFrontend.Entidades.Request.ReqUsuario;
using PlanXFrontend.Entidades.Response.ResUsuario;

namespace MauiApp1;

public partial class SignIn : ContentPage
{
    string laUrl = App.API_URL;
    public SignIn()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
	}
    private async void btnSignInPass_Clicked(object sender, EventArgs e)
    {
        try
        {
            ReqInsertarUsuario req = new ReqInsertarUsuario();
            req.nombre = enyName.Text;
            req.apellido = enyLastName.Text;
            req.email = enyMailReg.Text;
            req.codPais = enyCountry.SelectedItem.ToString();
            req.contrasenha = enyPasswordReg.Text;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(laUrl + "api/usuario/insertarusuario", jsonContent);

            if (response.IsSuccessStatusCode) 
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResInsertarUsuario res = new ResInsertarUsuario();

                res = JsonConvert.DeserializeObject<ResInsertarUsuario>(responseContent);

                if (res.resultado)
                {
                    DisplayAlert("Insercion correcta", "Usuario se añadio correctamente", "Aceptar");
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