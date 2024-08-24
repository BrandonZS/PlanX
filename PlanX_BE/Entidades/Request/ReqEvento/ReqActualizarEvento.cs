using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Request.ReqEvento
{
    public class ReqActualizarEvento
    {
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int id { get; set; }
        public string codInvi { get; set; }
    }
}
