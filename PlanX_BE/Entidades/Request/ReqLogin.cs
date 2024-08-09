using PlanXBackend.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Request
{
    public class ReqLogin
    {
        public string email { get; set; }

        public string password { get; set; }
    }
}
