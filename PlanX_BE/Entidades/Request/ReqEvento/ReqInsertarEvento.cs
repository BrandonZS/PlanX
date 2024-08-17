using PlanXBackend.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Request
{
    public class ReqInsertarEvento
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecHoraInicio { get; set; }
        public DateTime fecHoraFin { get; set; }
        public int? limUsers { get; set; }
        public float duracion { get; set; }
        public int idUsuario { get; set; }
    }
}
