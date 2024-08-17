using PlanXBackend.Entidades.Request;
using PlanXBackend.Entidades.Request.ReqEvento;
using PlanXBackend.Entidades.Response;
using PlanXBackend.Entidades.Response.ResEvento;
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
        [System.Web.Http.Route("api/evento/insertarevento")]
        public ResInsertarEvento ingresarEvento(ReqInsertarEvento req)
        {
            return new LogEvento().insertarEvento(req);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/evento/obtenerevento")]
        public ResObtenerEvento obtenerEvento(ReqObtenerEvento req)
        {
            return new LogEvento().obtenerEvento(req);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/evento/obtenerlistaevento")]
        public ResObtenerListaEvento obtenerListaEvento(ReqObtenerListaEvento req)
        {
            return new LogEvento().obtenerListaEvento(req);
        }
    }
}
