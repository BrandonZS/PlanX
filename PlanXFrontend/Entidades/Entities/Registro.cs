using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend.Entidades.Entities
{
    public class Registro
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecInicial { get; set; }
        public DateTime fecFinal { get; set; }



        public string FecInicialString => fecInicial.ToString("dd/MM/yyyy HH:mm");
        public string FecFinalString => fecFinal.ToString("dd/MM/yyyy HH:mm");
    }
}
