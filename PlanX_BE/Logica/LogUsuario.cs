using PlanXBackend.Acceso_Datos;
using PlanXBackend.Entidades.Entities;
using PlanXBackend.Entidades.Request;
using PlanXBackend.Entidades.Response;
using PlanXBackend.Entidades.Response.ResUsuario;
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
                    res.listaDeErrores.Add("Req null");
                }
                else if (String.IsNullOrEmpty(req.nombre))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Nombre faltante");
                }
                else if (String.IsNullOrEmpty(req.apellido))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Apellido faltante");
                }
                else if (String.IsNullOrEmpty(req.email))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Correo electronico faltante");
                }
                else if (String.IsNullOrEmpty(req.contrasenha))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Contraseña faltante");
                }
                else if (String.IsNullOrEmpty(req.codPais))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("pais faltante");
                }
                else
                {
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = null;

                    string hashedPassword = Encriptador.HashPassword(req.contrasenha);
                    ConexionLINQDataContext con = new ConexionLINQDataContext();
                    con.SP_REGISTRO_USUARIO_REGULAR(req.nombre, req.apellido, req.email, hashedPassword, req.codPais, ref idReturn, ref errorId, ref errorDescripcion);
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

        public ResActualizarUsuario actualizarUsuario(ReqActualizarUsuario req)
        {
            ResActualizarUsuario res = new ResActualizarUsuario();
            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Req null");
                }
                else if (req.nombre == "")
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Nombre faltante");
                }
                else if (req.apellido == "")
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Apellido faltante");
                }
                else if (req.contraAntigua == "")
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Contraseña faltante");
                }
                else if (req.contraNueva == "")
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Contraseña faltante");
                }
                else if (req.codPais == "")
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Error en Pais");
                }
                else
                {
                    int? errorId = 0;
                    string errorDescripcion = null;

                    string hashedPassword1 = null; 
                    string hashedPassword2 = null; 
                    if (req.contraNueva!=null && req.contraAntigua != null)
                    {
                        hashedPassword1 = Encriptador.HashPassword(req.contraAntigua);
                        hashedPassword2 = Encriptador.HashPassword(req.contraNueva);
                    }
                    ConexionLINQDataContext con = new ConexionLINQDataContext();
                    con.SP_ACTUALIZAR_USUARIO_REGULAR(req.nombre, req.apellido, hashedPassword1, hashedPassword2, req.idUsuario, req.codPais, ref errorId, ref errorDescripcion);
                    if (errorDescripcion != null)
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
        public ResEliminarUsuario eliminarUsuario(ReqEliminarUsuario req)
        {
            ResEliminarUsuario res = new ResEliminarUsuario();
            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Req null");
                }
                else if (req.idUsuario <1)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Nombre faltante");
                }
                else if (String.IsNullOrEmpty(req.contrasenha))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Contraseña faltante");
                }
                else
                {
                    int? errorId = 0;
                    string errorDescripcion = null;

                    string hashedPassword = Encriptador.HashPassword(req.contrasenha);
                    ConexionLINQDataContext con = new ConexionLINQDataContext();
                    con.SP_ELIMINAR_USUARIO_REGULAR(req.idUsuario, hashedPassword, ref errorId, ref errorDescripcion);
                    if (errorDescripcion != null)
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



    }
}
