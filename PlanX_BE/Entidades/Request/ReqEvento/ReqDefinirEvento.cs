using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Request.ReqEvento
{
    public class ReqDefinirEvento
    {
        public int id {  get; set; }
        public string codInvitacion { get; set; }
        public DateTime horaInicial {  get; set; }
        public DateTime horaFinal { get; set; }
    }
}
