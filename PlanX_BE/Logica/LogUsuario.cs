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
    public class LogUsuario
    {
        public ResInsertarUsuario insertarUsuario(ReqInsertarUsuario req)
        {
            ResInsertarUsuario res = new ResInsertarUsuario();
            try
            {
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
                else if (String.IsNullOrEmpty(req.apellido))
                {
                    res.resultado = false;
                    res.error = "Apellido faltante";
                }
                else if (String.IsNullOrEmpty(req.email))
                {
                    res.resultado = false;
                    res.error = "Correo Electronico faltante";
                }
                else if (String.IsNullOrEmpty(req.contrasenha))
                {
                    res.resultado = false;
                    res.error = "Contraseña faltante";
                }
                else if (String.IsNullOrEmpty(req.codPais))
                {
                    res.resultado = false;
                    res.error = "pais faltante";
                }
                else
                {
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = null;
                    ConexionLINQDataContext con = new ConexionLINQDataContext();
                    con.SP_REGISTRO_USUARIO_REGULAR(req.nombre, req.apellido, req.email, req.contrasenha, req.codPais, ref idReturn, ref errorId, ref errorDescripcion);
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

        public ResActualizarUsuario actualizarUsuario(ReqActualizarUsuario req)
        {
            ResActualizarUsuario res = new ResActualizarUsuario();
            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Req null";
                }
                else if (req.nombre == "")
                {
                    res.resultado = false;
                    res.error = "Nombre faltante";
                }
                else if (req.apellido == "")
                {
                    res.resultado = false;
                    res.error = "Apellido faltante";
                }
                else if (req.contraAntigua == "")
                {
                    res.resultado = false;
                    res.error = "Contraseña faltante";
                }
                else if (req.contraNueva == "")
                {
                    res.resultado = false;
                    res.error = "Contraseña faltante";
                }
                else
                {
                    int? errorId = 0;
                    string errorDescripcion = null;
                    ConexionLINQDataContext con = new ConexionLINQDataContext();
                    con.SP_ACTUALIZAR_USUARIO_REGULAR(req.nombre, req.apellido, req.contraAntigua, req.contraNueva, req.idUsuario, ref errorId, ref errorDescripcion);
                    if (errorDescripcion != null)
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
