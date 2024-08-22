using PlanXBackend.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Response.ResTarea
{
    public class ResObtenerTarea: ResBase
    {
        public List<Tarea> listaTareas = new List<Tarea>();

    }
}
