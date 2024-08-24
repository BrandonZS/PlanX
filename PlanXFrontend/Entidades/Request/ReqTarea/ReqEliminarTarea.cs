using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.Entidades.Request.ReqTarea
{
    public class ReqEliminarTarea
    {
        public Int64 idUser { get; set; }
        public int idTarea { get; set; }
    }
}
