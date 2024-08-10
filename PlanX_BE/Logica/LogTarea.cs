using PlanXBackend.Acceso_Datos;
using PlanXBackend.Entidades.Request;
using PlanXBackend.Entidades.Response;
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
                    res.error = "Req null";
                }
                else if (String.IsNullOrEmpty(req.titulo))
                {
                    res.resultado = false;
                    res.error = "Nombre faltante";
                }
                else if (String.IsNullOrEmpty(req.descripcion))
                {
                    res.resultado = false;
                    res.error = "Apellido faltante";
                }
                else if (String.IsNullOrEmpty(req.email))
                {
                    res.resultado = false;
                    res.error = "Correo Electronico faltante";
                }
                else
                {
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = null;
                    ConexionLINQDataContext linq = new ConexionLINQDataContext();
                    linq.SP_INSERTAR_TAREA(req.titulo, req.descripcion, req.fecHoraInicio, req.fecHoraFin, req.email, req.prioridad);
                    if (idReturn == 0)
                    {
                        res.resultado = false;
                        res.error = errorDescripcion;

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
                res.error = "Excepcion ha ocurrido";
            }

            return res;
        }
    }
}
