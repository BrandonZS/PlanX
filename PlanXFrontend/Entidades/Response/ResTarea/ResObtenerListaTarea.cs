using System;
using PlanXFrontend.Entidades.Entities;

namespace PlanXFrontend.Entidades.Response.ResTarea;

public class ResObtenerListaTarea : ResBase
{
    public List<Tarea> listaTareas = new List<Tarea>();
}
