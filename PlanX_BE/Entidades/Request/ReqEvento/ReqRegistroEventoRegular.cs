using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Request.ReqEvento
{
    public class ReqRegistroEventoRegular
    {
        public int idUser { get; set; }
        public string codInvi {  get; set; }
        public DateTime fecInicio { get; set; }
        public DateTime fecFinal {  get; set; }
    }
}
