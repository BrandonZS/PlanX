using PlanXBackend.Entidades.Request;
using PlanXBackend.Entidades.Response;
using PlanXBackend.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PLANX_API.Controllers
{
    public class EventoController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/evento/insertarEvento")]
        public ResInsertarEvento ingresarEvento(ReqInsertarEvento req)
        {
            return new LogEvento().insertarEvento(req);
        }
    }
}
