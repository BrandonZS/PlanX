using System;

namespace PlanXFrontend.Entidades.Entities;

public static class Sesion
{
    	public static long id { get; set; }
		public static string nombre { get; set; }
		public static string apellidos { get; set; }
		public static string token {  get; set; }
 
		public static bool validarSesion()
		{
			if(String.IsNullOrEmpty(Sesion.token))
			{
				return false;
			}
			else
			{
				return true;
			}
		}
 
		public static void cerrarSesion()
		{
			Sesion.id = 0;
			Sesion.nombre = String.Empty;
			Sesion.apellidos = String.Empty;
			Sesion.token = String.Empty;
 
		}

}
