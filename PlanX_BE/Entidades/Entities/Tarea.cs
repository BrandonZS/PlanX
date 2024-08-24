using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Entities
{
    public class Tarea
    {
        public int Id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecHoraInicio { get; set; }
        public DateTime fecHoraFin { get; set; }
        public string prioridad { get; set; }
    }
}
