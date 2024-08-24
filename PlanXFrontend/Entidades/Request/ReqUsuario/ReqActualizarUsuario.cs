using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.Entidades.Request.ReqUsuario
{
    public class ReqActualizarUsuario
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string contraAntigua { get; set; }
        public string contraNueva { get; set; }
        public string codPais { get; set; }
        public Int64 idUsuario { get; set; }
    }
}
