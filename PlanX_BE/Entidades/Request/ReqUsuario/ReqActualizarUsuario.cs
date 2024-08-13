using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Request
{
    public class ReqActualizarUsuario
    {
        public string nombre {  get; set; }
        public string apellido { get; set; }
        public string contraAntigua { get; set; }
        public string contraNueva { get; set; }
        public int idUsuario { get; set; }
    }
}
