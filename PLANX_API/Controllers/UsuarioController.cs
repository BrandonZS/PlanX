
using PlanXBackend.Entidades.Request;
using PlanXBackend.Entidades.Response;
using PlanXBackend.Entidades.Response.ResUsuario;
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

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/usuario/actualizarusuario")]
        public ResActualizarUsuario actualizarUsuario(ReqActualizarUsuario req)
        {
            return new LogUsuario().actualizarUsuario(req);
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/usuario/eliminarusuario")]
        public ResEliminarUsuario eliminarUsuario(ReqEliminarUsuario req)
        {
            return new LogUsuario().eliminarUsuario(req);
        }
    }
}