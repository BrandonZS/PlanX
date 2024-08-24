using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Request.ReqTarea
{
    public class ReqActualizarTarea
    {
        public int idTarea { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int idUser { get; set; }
    }
}
