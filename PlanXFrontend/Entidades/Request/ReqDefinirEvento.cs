using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.Entidades.Request
{
    public class ReqDefinirEvento
    {
        public Int64 id { get; set; }
        public string codInvitacion { get; set; }
        public DateTime horaInicial { get; set; }
        public DateTime horaFinal { get; set; }
    }
}
