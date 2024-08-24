using PlanXFrontend.Entidades.Entities;

namespace PlanXFrontend;

public partial class AccountPage : ContentPage
{
	public AccountPage()
	{
		InitializeComponent();
		enyNameAccount.Text = Sesion.nombre;
		enyLastNameAccount.Text = Sesion.apellido;
		enyEmail.Text = Sesion.email;
		pickerCountry.SelectedItem = Sesion.codPais;
	}

	        public async void ChangePassword_Clicked(object sender, EventArgs e){
            await Navigation.PushAsync(new ChangePasswordPage());
        }

		public async void btnLogOut(object sender, EventArgs e){
            Sesion.cerrarSesion();
			await Navigation.PushAsync(new MainPage());
    }
}