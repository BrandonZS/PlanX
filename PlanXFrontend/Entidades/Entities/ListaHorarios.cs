using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.Entidades.Entities
{
    public class ListaHorarios
    {
        public static List<Horario> listaHorarios = new List<Horario>
    {
        new Horario
        {
            horaInicio = new DateTime(2024, 8, 23, 9, 0, 0), // 9:00 AM
            horaFinal = new DateTime(2024, 8, 23, 10, 0, 0), // 10:00 AM
            registros = new List<Registro>
            {
                new Registro
                {
                    nombre = "Juan",
                    apellido = "Pérez",
                    fecInicial = new DateTime(2024, 8, 23, 9, 0, 0),
                    fecFinal = new DateTime(2024, 8, 23, 9, 30, 0)
                },
                new Registro
                {
                    nombre = "María",
                    apellido = "González",
                    fecInicial = new DateTime(2024, 8, 23, 9, 30, 0),
                    fecFinal = new DateTime(2024, 8, 23, 10, 0, 0)
                }
            }
        },
        new Horario
        {
            horaInicio = new DateTime(2024, 8, 23, 10, 0, 0), // 10:00 AM
            horaFinal = new DateTime(2024, 8, 23, 11, 0, 0), // 11:00 AM
            registros = new List<Registro>
            {
                new Registro
                {
                    nombre = "Carlos",
                    apellido = "López",
                    fecInicial = new DateTime(2024, 8, 23, 10, 0, 0),
                    fecFinal = new DateTime(2024, 8, 23, 10, 45, 0)
                },
                new Registro
                {
                    nombre = "Ana",
                    apellido = "Ramírez",
                    fecInicial = new DateTime(2024, 8, 23, 10, 45, 0),
                    fecFinal = new DateTime(2024, 8, 23, 11, 0, 0)
                }
            }
        },
        new Horario
        {
            horaInicio = new DateTime(2024, 8, 23, 11, 0, 0), // 11:00 AM
            horaFinal = new DateTime(2024, 8, 23, 12, 0, 0), // 12:00 PM
            registros = new List<Registro>
            {
                new Registro
                {
                    nombre = "Luis",
                    apellido = "Martínez",
                    fecInicial = new DateTime(2024, 8, 23, 11, 0, 0),
                    fecFinal = new DateTime(2024, 8, 23, 11, 30, 0)
                },
                new Registro
                {
                    nombre = "Laura",
                    apellido = "Hernández",
                    fecInicial = new DateTime(2024, 8, 23, 11, 30, 0),
                    fecFinal = new DateTime(2024, 8, 23, 12, 0, 0)
                }
            }
        }
    };


    }

}
