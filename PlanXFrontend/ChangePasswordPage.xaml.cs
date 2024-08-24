using Newtonsoft.Json;
using PlanXFrontend.Entidades.Entities;
using PlanXFrontend.Entidades.Request.ReqUsuario;
using PlanXFrontend.Entidades.Response;
using System.Text.RegularExpressions;

namespace PlanXFrontend;

public partial class ChangePasswordPage : ContentPage
{
    string laUrl = App.API_URL;
    public ChangePasswordPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(NewPasswordEntry.Text))
        {
            DisplayAlert("Error", "Enter a password", "Acept");
        }
        else if (ValidatePassword(NewPasswordEntry.Text) != "")
        {
            DisplayAlert("Error", ValidatePassword(NewPasswordEntry.Text), "Acept");
        }
        else if (NewPasswordEntry.Text != ConfirmPasswordEntry.Text) 
        {
            DisplayAlert("Error", "Passwords do not match.", "Acept");
        }
        else
        {
            try
            {
                ReqActualizarUsuario req = new ReqActualizarUsuario();
                req.idUsuario = Sesion.id;
                req.contraAntigua = CurrentPasswordEntry.Text;
                req.contraNueva = NewPasswordEntry.Text;


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
    private string ValidatePassword(string password)
    {
        var errors = new List<string>();

        if (password.Length < 8)
        {
            errors.Add("The password must be at least 8 characters long.");
        }
        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            errors.Add("The password must include uppercase letters.");
        }
        if (!Regex.IsMatch(password, @"[a-z]"))
        {
            errors.Add("The password must include lowercase letters.");
        }
        if (!Regex.IsMatch(password, @"[0-9]"))
        {
            errors.Add("The password must include a number.");
        }
        if (!Regex.IsMatch(password, @"[\W_]"))
        {
            errors.Add("The password must include a special character.");
        }

        return errors.Count > 0 ? string.Join("\n", errors) : string.Empty;
    }
}
