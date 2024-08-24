using PlanXFrontend.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.Entidades.Response
{
    public class ResObtenerHorarios:ResBase
    {
            public List<Horario> horarios = new List<Horario>();
    }
}
