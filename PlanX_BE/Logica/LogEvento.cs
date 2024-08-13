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
                //Faltan Comprobaciones de otros datos
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Req null";
                }
                else if (String.IsNullOrEmpty(req.nombre))
                {
                    res.resultado = false;
                    res.error = "Titulo faltante";
                }
                else if (String.IsNullOrEmpty(req.descripcion))
                {
                    res.resultado = false;
                    res.error = "Descripcion faltante";
                }
                else if (req.idUsuario < 1)
                {
                    res.resultado = false;
                    res.error = "Usuario Faltante";
                }
                else if (req.limUsers != null && req.limUsers < 1) 
                {
                    res.resultado = false;
                    res.error = "Limite incorrecto";
                }
                else if(req.duracion < 0)
                {
                    res.resultado = false;
                    res.error = "Duracion incorrecta";
                }
                else
                {
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = null;
                    ConexionLINQDataContext linq = new ConexionLINQDataContext();
                    linq.SP_INSERTAR_EVENTO(req.nombre, req.descripcion, req.fecHoraInicio, req.fecHoraFin, req.limUsers, req.duracion, req.idUsuario, ref idReturn, ref errorId, ref errorDescripcion);
                    if (idReturn == 0)
                    {
                        res.resultado = false;
                        res.error = errorDescripcion;

                    }
                    else
                    {
                        res.resultado = true;
                        res.error = errorDescripcion;

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
