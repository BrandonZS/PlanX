using Newtonsoft.Json;
using PlanXFrontend.Entidades.Entities;
using PlanXFrontend.Entidades.Request.ReqUsuario;
using PlanXFrontend.Entidades.Response;

namespace PlanXFrontend;

public partial class AccountPage : ContentPage
{
    string laUrl = App.API_URL;
    public AccountPage()
	{
		InitializeComponent();
		enyNameAccount.Text = Sesion.nombre;
		enyLastNameAccount.Text = Sesion.apellido;
		enyEmail.Text = Sesion.email;
        pickerCountry.SelectedItem = pickerCountry.Items.FirstOrDefault(item => item == Sesion.codPais);
    }

	        public async void ChangePassword_Clicked(object sender, EventArgs e){
            await Navigation.PushAsync(new ChangePasswordPage());
        }

		public async void btnLogOut(object sender, EventArgs e){
            Sesion.cerrarSesion();
			await Navigation.PushAsync(new MainPage());
    }

    private async void Save_Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            ReqActualizarUsuario req = new ReqActualizarUsuario();
            req.idUsuario = Sesion.id;
            req.nombre = enyNameAccount.Text;
            req.apellido = enyLastNameAccount.Text;
            if (pickerCountry.SelectedItem != null)
            {
                req.codPais = pickerCountry.SelectedItem.ToString();
            }
            

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PutAsync(laUrl + "api/usuario/actualizarusuario", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ResBase res = new ResBase();

                res = JsonConvert.DeserializeObject<ResBase>(responseContent);

                DisplayAlert("Nice!", "Usuario se actualizo correctamente", "Aceptar");

            }
            else
            {
                DisplayAlert("Error", "Usuario no se actualizo", "Aceptar");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", "Error en backend", "Aceptar");
        }
    }
}