using System;
using PlanXFrontend.Entidades.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.Entidades.Response.ResTarea 
{
    public class ResObtenerListaTarea : ResBase
    {
        public List<Tarea> listaTareas = new List<Tarea>();
    }

}

