using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.Entidades.Entities
{
    public class Horario
    {
        public DateTime horaInicio { get; set; }
        public DateTime horaFinal { get; set; }
        public List<Registro> registros = new List<Registro>();

    }
}
