using PlanXFrontend.Entidades.Entities;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.ViewModel;

public class TaskViewModel
{
	public ObservableCollection<SchedulerAppointment> SchedulerTasks { get; set; }
	public TaskViewModel()
	{
		this.SchedulerTasks = new ObservableCollection<SchedulerAppointment>();


            foreach (Tarea tarea in ListaTareas.tareas)
            {
            Color miColor;

            switch (tarea.prioridad)
            {
                case "Crítica":
                    miColor = Colors.Red; // Rojo
                    break;
                case "Alta":
                    miColor = Colors.Orange; // Naranja
                    break;
                case "Media":
                    miColor = Colors.Yellow; // Amarillo
                    break;
                case "Baja":
                    miColor = Colors.Green; // Verde
                    break;
                default:
                    miColor = Colors.AliceBlue; // Azul por defecto
                    break;
            }
            SchedulerTasks.Add(new SchedulerAppointment()
                {
                    StartTime = tarea.fecHoraInicio,
                    EndTime = tarea.fecHoraFin,
                    Subject = tarea.titulo,
                    Id = tarea.id,
                    Background = miColor

                });
            }


	}
}