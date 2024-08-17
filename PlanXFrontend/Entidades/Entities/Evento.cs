using System;

namespace PlanXFrontend.Entidades.Entities;

public class Evento
{
       public string codInvitacion { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecHoraInicio { get; set; }
        public DateTime fecHoraFin { get; set; }
        public int limUsers { get; set; }
        public float duracion  { get; set; }

}
