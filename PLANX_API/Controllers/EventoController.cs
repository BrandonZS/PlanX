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

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/evento/obtenerevento")]
        public ResObtenerEvento obtenerEvento(ReqObtenerEvento req)
        {
            return new LogEvento().obtenerEvento(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/evento/obtenerlistaevento")]
        public ResObtenerListaEvento obtenerListaEvento(ReqObtenerListaEvento req)
        {
            return new LogEvento().obtenerListaEvento(req);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/evento/registrareventoregular")]
        public ResRegistroEventoRegular registrarEventoRegular(ReqRegistroEventoRegular req)
        {
            return new LogEvento().registrarEventoRegular(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/evento/obtenerhorario")]
        public ResObtenerRegistros obtenerHorarios(ReqObtenerEvento req)
        {
            return new LogRegistro().obtenerRegistros(req);
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/evento/definirevento")]
        public ResDefinirEvento definirEvento(ReqDefinirEvento req)
        {
            return new LogEvento().definirEvento(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/evento/eliminarevento")]
        public ResEliminarEvento eliminarEvento(ReqEliminarEvento req)
        {
            return new LogEvento().eliminarEvento(req);
        }
    }
}
