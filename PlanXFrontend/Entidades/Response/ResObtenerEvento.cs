using System;
using PlanXFrontend.Entidades.Entities;

namespace PlanXFrontend.Entidades.Response;

public class ResObtenerEvento : ResBase
{
    public List<Evento> listaEventos {get; set;}
}
