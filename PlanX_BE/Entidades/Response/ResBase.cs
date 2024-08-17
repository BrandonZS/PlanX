using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Response
{
    public class ResBase
    {
        public bool resultado { get; set; }
        public List<String> listaDeErrores = new List<String>();
    }
}
