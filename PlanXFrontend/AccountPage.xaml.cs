using PlanXFrontend.Entidades.Entities;

namespace PlanXFrontend;

public partial class AccountPage : ContentPage
{
	public AccountPage()
	{
		InitializeComponent();
		enyNameAccount.Text = Sesion.nombre;
		enyLastNameAccount.Text = Sesion.apellidos;
		enyEmail.Text = Sesion.email;
		pickerCountry.Title = Sesion.codPais;
	}

	        public async void ChangePassword_Clicked(object sender, EventArgs e){
            await Navigation.PushAsync(new ChangePasswordPage());
        }

		public async void btnLogOut(object sender, EventArgs e){
            Sesion.cerrarSesion();
        }
}