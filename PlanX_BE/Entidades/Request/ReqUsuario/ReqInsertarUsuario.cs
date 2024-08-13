using PlanXBackend.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Request
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
