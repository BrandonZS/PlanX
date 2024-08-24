using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.Entidades.Request.ReqTarea
{
    public class ReqActualizarTarea
    {
        public int idTarea { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public Int64 idUser { get; set; }
    }
}
