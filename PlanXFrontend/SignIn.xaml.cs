using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using PlanXFrontend;
using PlanXFrontend.Entidades.Request.ReqUsuario;
using PlanXFrontend.Entidades.Response.ResUsuario;
using System.Net;
using System.Text.RegularExpressions;

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
        if (String.IsNullOrEmpty(enyMailReg.Text))
        {
            DisplayAlert("Error", "Enter a email", "Acept");
        }
        else if (!IsValidEmail(enyMailReg.Text))
        {
            DisplayAlert("Error", "The email address you entered is not valid", "Acept");
        }
        else if (String.IsNullOrEmpty(enyPasswordReg.Text))
        {
            DisplayAlert("Error", "Enter a password", "Acept");
        }
        else if (ValidatePassword(enyPasswordReg.Text) != "")
        {
            DisplayAlert("Error", ValidatePassword(enyPasswordReg.Text), "Acept");
        }
        else if (String.IsNullOrEmpty(enyName.Text))
        {
            DisplayAlert("Error", "Please enter a name", "Acept");
        }
        else if (string.IsNullOrEmpty(enyLastName.Text))
        {
            DisplayAlert("Error", "Please enter a lastname", "Acept");
        }
        else if (enyPasswordReg.Text != enyVerifyassword.Text)
        {
            DisplayAlert("Error", "Passwords do not match.", "Acept");
        }
        else if (String.IsNullOrEmpty(enyCountry.SelectedItem.ToString()))
        {
            DisplayAlert("Error", "Enter a country", "Acept");
        }
        else
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
                        DisplayAlert("Nice!", "Usuario se añadio correctamente", "Aceptar");
                        await Navigation.PushAsync(new LogIn());
                    }

                }
                else
                {
                    DisplayAlert("Error", "Ocurrio un error de conexion", "Aceptar");
                }
            }
            catch (Exception ex)
            {

            }
        }
        

    }
    private bool IsValidEmail(string email)
    {
        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }

    //Los mensajes los puede cambiar por lo que quiera
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