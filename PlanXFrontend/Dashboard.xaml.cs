using PlanXFrontend;
using PlanXFrontend.Entidades.Entities;
using PlanXFrontend.Entidades.Request;
using Newtonsoft.Json;
using PlanXFrontend.Entidades.Response;
using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;
using Syncfusion.Maui.Popup;

namespace MauiApp1;

public partial class Dashboard : ContentPage
{
    public ObservableCollection<SchedulerAppointment> Appointments { get; set; }
    string laURL = "https://backendcursos.azurewebsites.net/";
	public Dashboard()
	{
        Appointments = new ObservableCollection<SchedulerAppointment>();
        ObtenerEvento();
		InitializeComponent();
        NavigationPage.SetHasBackButton(this, false);
	}

	private void myButton_Pressed(object sender, EventArgs e)
{
    btnCreateEvent.BorderColor = Colors.BlueViolet;
    btnCreateEvent.BorderWidth = 2;
    btnCreateEvent.TextColor = Colors.BlueViolet;
}
    private void myButton_Released(object sender, EventArgs e)
{
    btnCreateEvent.BorderColor = Colors.Black;
    btnCreateEvent.BorderWidth = 1;
    btnCreateEvent.TextColor= Colors.Black;

}
	private async void tbiJoinGroup_Clicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Join Event", "What's your Code?", maxLength:6);
        if(result == "123456"){
            await Navigation.PushAsync(new JoinGroupPage()); 
        }else{
            await DisplayAlert("Sorry!!", "Your Code Is Invalid", "OK");
        }
        
    }
    private async void tbiTask_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TasksPage());
    }
    private async void tbiAccount_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccountPage());
    }
    private async void btnCreateEvent_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateEventPage());

	}
    private void ObtenerEvento(){
       

            var mockEventos = new List<Evento>
{
    new Evento
    {
        codInvitacion = "ABC123",
        nombre = "Reunión de planificación",
        descripcion = "Reunión para planificar el próximo trimestre.",
        fecHoraInicio = DateTime.ParseExact("20082024 09:00:00", "ddMMyyyy HH:mm:ss", null),
        fecHoraFin = DateTime.ParseExact("20082024 10:30:00", "ddMMyyyy HH:mm:ss", null),
        limUsers = 20,
        duracion = 1.5f
    },
    new Evento
    {
        codInvitacion = "XYZ456",
        nombre = "Seminario de capacitación",
        descripcion = "Capacitación sobre nuevas herramientas de desarrollo.",
        fecHoraInicio = DateTime.ParseExact("21082024 11:00:00", "ddMMyyyy HH:mm:ss", null),
        fecHoraFin = DateTime.ParseExact("21082024 12:00:00", "ddMMyyyy HH:mm:ss", null),
        limUsers = 50,
        duracion = 1.0f
    },
    new Evento
    {
        codInvitacion = "LMN789",
        nombre = "Almuerzo con clientes",
        descripcion = "Almuerzo para discutir nuevas oportunidades de negocio.",
        fecHoraInicio = DateTime.ParseExact("22082024 13:00:00", "ddMMyyyy HH:mm:ss", null),
        fecHoraFin = DateTime.ParseExact("22082024 14:30:00", "ddMMyyyy HH:mm:ss", null),
        limUsers = 10,
        duracion = 1.5f
    },
    new Evento
    {
        codInvitacion = "DEF101",
        nombre = "Reunión de equipo",
        descripcion = "Reunión para revisar el progreso del proyecto.",
        fecHoraInicio = DateTime.ParseExact("23082024 15:00:00", "ddMMyyyy HH:mm:ss", null),
        fecHoraFin = DateTime.ParseExact("23082024 16:00:00", "ddMMyyyy HH:mm:ss", null),
        limUsers = 15,
        duracion = 1.0f
    },
    new Evento
    {
        codInvitacion = "GHI202",
        nombre = "Presentación de informe",
        descripcion = "Presentación del informe trimestral de resultados.",
        fecHoraInicio = DateTime.ParseExact("24082024 09:00:00", "ddMMyyyy HH:mm:ss", null),
        fecHoraFin = DateTime.ParseExact("24082024 10:00:00", "ddMMyyyy HH:mm:ss", null),
        limUsers = 25,
        duracion = 1.0f
    }
};

                    var appointments = new ObservableCollection<SchedulerAppointment>();


                    foreach (Evento appointment in mockEventos)
                    {
                        appointments.Add(new SchedulerAppointment()
                        {
                            StartTime = appointment.fecHoraInicio,
                            EndTime = appointment.fecHoraFin,
                            Subject = appointment.nombre,

                        });
                    }
                Appointments = appointments;
            


       
    }

}