using System;

namespace PlanXFrontend.Entidades.Entities;

public class Usuario
{
    	public Int64 id { get; set; }
		public string nombre { get; set; }
		public string apellido { get; set; }
		public string email { get; set; }
		public string codPais { get; set; }
		public string password { get; set; }
		public string token { get; set; }

}
