using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Request
{
    public class ReqEliminarUsuario
    {
        public int idUsuario {  get; set; }
        public string contrasenha { get; set; }
    }
}
