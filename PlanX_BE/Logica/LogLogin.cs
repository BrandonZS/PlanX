using PlanXBackend.Acceso_Datos;
using PlanXBackend.Entidades.Entities;
using PlanXBackend.Entidades.Request;
using PlanXBackend.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanXBackend.Logica
{
    public class LogLogin
    {
        public ResLogin solicitudLogin(ReqLogin req)
        {
            ResLogin res = new ResLogin();
            short tipoRegistro = 0; //1 Exitoso - 2 Error en Logica - 3 Error No Controlado
            try
            {
                if (String.IsNullOrEmpty(req.email))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Correo electronico faltante");
                    tipoRegistro = 2; //No Exitoso
                }
                if (String.IsNullOrEmpty(req.password))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Password faltante");
                    tipoRegistro = 2; //No Exitoso
                }

                if (!res.listaDeErrores.Any()) /*Lista vacia*/
                {
                    //No hay errores
                    //Enviar a linq
                    ConexionLINQDataContext linq = new ConexionLINQDataContext();
                    int? idReturn = 0;
                    int? idError = 0;
                    string errorBd = "";
                    SP_LOGINResult resultado = new SP_LOGINResult();
                    resultado = linq.SP_LOGIN(req.email, req.password, ref idReturn, ref idError, ref errorBd).ToList().First();
                    if (idError == null || idError == 0)
                    {
                            //Usuario verificado
                            res.resultado = true;
                            res.usuario = this.armarUsuario(resultado);      
                    }
                    else
                    {
                        res.resultado = false;
                        res.listaDeErrores.Add(errorBd); //GRAVISIMO!!!
                        tipoRegistro = 2; //No Exitoso
                    }
                }
            }
            catch (Exception ex)
            {
                //Se bitacorea todo resultado. Exitoso o no exitoso.
                //Utilitarios.Utilitarios.crearBitacora(res.listaDeErrores, tipoRegistro, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }

            return res;
        }
        private Usuario armarUsuario(SP_LOGINResult usuarioLinq)
        {
            Usuario usuario = new Usuario();
            usuario.Id = usuarioLinq.ID_USUARIO;
            usuario.nombre = usuarioLinq.NOMBRE;
            usuario.apellido = usuarioLinq.APELLIDOS;
            usuario.email = usuarioLinq.CORREO_ELECTRONICO;
            usuario.codPais = usuarioLinq.CODIGO_PAIS;
            Guid guid = Guid.NewGuid();
            usuario.token = guid.ToString();

            return usuario;
        }

    }
}
