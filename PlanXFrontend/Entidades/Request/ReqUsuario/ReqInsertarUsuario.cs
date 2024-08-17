using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.Entidades.Request.ReqUsuario
{
    public class ReqInsertarUsuario
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string codPais { get; set; }
        public string contrasenha { get; set; }
    }
}
