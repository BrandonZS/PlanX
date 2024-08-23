using PlanXBackend.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Response
{
    public class ResObtenerRegistros : ResBase
    {
        public List<HorarioEvento> horarios = new List<HorarioEvento>();
    }
}
