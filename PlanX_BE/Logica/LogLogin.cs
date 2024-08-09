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
    public class LogLogin
    {
        public ResLogin solicitudLogin(ReqLogin req)
        {
            //Instancio mi respuesta
            ResLogin res = new ResLogin();

            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Req null";
                }
                else if (String.IsNullOrEmpty(req.email))
                {
                    res.resultado = false;
                    res.error = "Email faltante";
                }
                else if (String.IsNullOrEmpty(req.password))
                {
                    res.resultado = false;
                    res.error = "Contraseña faltante";
                }
                else
                {

                    //Todos los datos son correctos
                    //Enviarlos a LINQ
                    int? idReturn = 0;
                    int? estado = 0;
                    string nombre = null;
                    string apellido = null;
                    ConexionLINQDataContext linq = new ConexionLINQDataContext();   //Instancio linq
                    linq.sp_Login(req.email, req.password, ref idReturn, ref nombre, ref apellido);
                    if (idReturn == 0)
                    {
                        res.resultado = false;
                        res.error = "Error en BD";

                    }
                    else
                    {
                        res.nombre = nombre;
                        res.apellido = apellido;
                        res.resultado = true;
                        res.Token = GeneradorToken.GenerateToken(nombre);
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "Ni idea xq se cayó XD";
            }

            return res;


        }

    }
}
