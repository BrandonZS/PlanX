using System;

namespace PlanXFrontend.Entidades.Entities
{
    public class Tarea
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecHoraInicio { get; set; }
        public DateTime fecHoraFin { get; set; }
        public string prioridad { get; set; }

    }
    public class TareaEstatica
    {
        public static Tarea staticTask { get; set; }
    }
}


