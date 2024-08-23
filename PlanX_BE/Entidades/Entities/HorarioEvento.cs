using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Entities
{
    public class HorarioEvento
    {
        public DateTime horaInicio {  get; set; }
        public DateTime horaFinal { get; set;}
        public List<Registro> registros = new List<Registro>();
    }
}

