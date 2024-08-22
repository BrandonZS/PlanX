using PlanXBackend.Acceso_Datos;
using PlanXBackend.Entidades.Entities;
using PlanXBackend.Entidades.Request;
using PlanXBackend.Entidades.Request.ReqEvento;
using PlanXBackend.Entidades.Request.ReqTarea;
using PlanXBackend.Entidades.Response;
using PlanXBackend.Entidades.Response.ResEvento;
using PlanXBackend.Entidades.Response.ResTarea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Logica
{
    public class LogTarea
    {
        public ResInsertarTarea insertarTarea(ReqInsertarTarea req)
        {
            ResInsertarTarea res = new ResInsertarTarea();
            try
            {
                //Faltan Comprobaciones
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Req null");
                }
                else if (String.IsNullOrEmpty(req.titulo))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Titulo faltante");
                }
                else if (String.IsNullOrEmpty(req.descripcion))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Apellido faltante");
                }
                else if (req.idUsuario < 1)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Correo Electronico faltante");
                }
                else
                {
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = null;
                    ConexionLINQDataContext linq = new ConexionLINQDataContext();
                    linq.SP_INSERTAR_TAREA(req.titulo, req.descripcion, req.fecHoraInicio, req.fecHoraFin, req.idUsuario, req.prioridad, ref idReturn, ref errorId, ref errorDescripcion);
                    if (idReturn == 0)
                    {
                        res.resultado = false;
                        res.listaDeErrores.Add(errorDescripcion);

                    }
                    else
                    {
                        
                        res.resultado = true;
                        

                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add("Excepcion ha ocurrido");
            }

            return res;
        }

        public ResObtenerTarea obtenerListaTarea(ReqObtenerTarea req)
        {
            ResObtenerTarea res = new ResObtenerTarea();
            try
            {
                //Faltan Comprobaciones de otros datos
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Req null");
                }
                else if (req.id < 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Error en el usuario");
                }
                else
                {
                    int? errorId = 0;
                    string errorDescripcion = null;
                    ConexionLINQDataContext linq = new ConexionLINQDataContext();
                    List<SP_OBTENER_TAREAResult> resultado = new List<SP_OBTENER_TAREAResult>();
                    resultado = linq.SP_OBTENER_TAREA(req.id, ref errorId, ref errorDescripcion).ToList();
                    if (errorId != 0)
                    {
                        res.resultado = false;
                        res.listaDeErrores.Add(errorDescripcion);

                    }
                    else
                    {
                        res.resultado = true;
                        foreach (SP_OBTENER_TAREAResult tarea in resultado)
                        {
                            res.listaTareas.Add(armarTarea(tarea));
                        }



                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add("Excepcion ha ocurrido");
            }

            return res;
        }
        private Tarea armarTarea(SP_OBTENER_TAREAResult tareaLinq)
        {
            Tarea tarea = new Tarea();
            tarea.titulo = tareaLinq.TITULO;
            tarea.descripcion = tareaLinq.DESCRIPCION;
            tarea.fecHoraInicio = tareaLinq.FECINICIAL;
            tarea.fecHoraFin = tareaLinq.FECFINAL;
            tarea.prioridad = tareaLinq.PRIORIDAD;
            return tarea;
        }
    }
}
