using System;

namespace PlanXFrontend.Entidades.Response;

public class ResBase
{
    public bool resultado {  get; set; }
	public List<string> listaDeErrores { get; set; }

}
