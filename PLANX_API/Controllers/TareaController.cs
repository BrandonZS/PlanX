using PlanXBackend.Entidades.Request;
using PlanXBackend.Entidades.Request.ReqTarea;
using PlanXBackend.Entidades.Response;
using PlanXBackend.Entidades.Response.ResTarea;
using PlanXBackend.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PLANX_API.Controllers
{
    public class TareaController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/tarea/insertartarea")]
        public ResInsertarTarea insertarTarea(ReqInsertarTarea req)
        {
            return new LogTarea().insertarTarea(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/tarea/obtenertarea")]
        public ResObtenerTarea obtenerTarea(ReqObtenerTarea req)
        {
            return new LogTarea().obtenerListaTarea(req);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/tarea/actualizartarea")]
        public ResActualizarTarea actualizarTarea(ReqActualizarTarea req)
        {
            return new LogTarea().actualizarTarea(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/tarea/eliminartarea")]
        public ResBase eliminarTarea(ReqEliminarTarea req)
        {
            return new LogTarea().eliminarTarea(req);
        }

    }
}
