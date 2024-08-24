using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Request.ReqTarea
{
    public class ReqEliminarTarea
    {
        public int idUser { get; set; }
        public int idTarea { get; set; }
    }
}
