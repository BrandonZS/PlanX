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
    public class LogEvento
    {
        public ResInsertarEvento insertarEvento(ReqInsertarEvento req)
        {
            ResInsertarEvento res = new ResInsertarEvento();
            try
            {
                //Faltan Comprobaciones
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Req null";
                }
                else if (String.IsNullOrEmpty(req.nombre))
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
                    linq.SP_CREAR_EVENTO(req.nombre, req.descripcion, req.fecHoraInicio, req.fecHoraFin, req.limUsers, req.duracion, req.email);
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
