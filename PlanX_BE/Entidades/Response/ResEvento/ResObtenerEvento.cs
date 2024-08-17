using PlanXBackend.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Response.ResEvento
{
    public class ResObtenerEvento : ResBase
    {
        public Evento evento {  get; set; }
    }
}
