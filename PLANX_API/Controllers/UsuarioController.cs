
using PlanXBackend.Entidades.Request;
using PlanXBackend.Entidades.Response;
using PlanXBackend.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PLANX_API.Controllers
{
    public class UsuarioController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/usuario/insertarusuario")]
        public ResInsertarUsuario insertarUsuario(ReqInsertarUsuario req)
        {
            return new LogUsuario().insertarUsuario(req);
        }
    }
}