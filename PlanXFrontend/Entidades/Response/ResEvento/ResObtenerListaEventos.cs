using PlanXFrontend.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.Entidades.Response.ResEvento
{
    public class ResObtenerListaEventos:ResBase
    {
        public List<Evento> listaEventos = new List<Evento>();
    }
}
