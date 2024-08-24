using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.Entidades.Request.ReqEvento
{
    public class ReqActualizarEvento
    {
        public string titulo {  get; set; }
        public string descripcion {  get; set; }
        public Int64 id { get; set; }
        public string codInvi {  get; set; }
    }
}
