using PlanXBackend.Acceso_Datos;
using PlanXBackend.Entidades.Entities;
using PlanXBackend.Entidades.Request;
using PlanXBackend.Entidades.Request.ReqEvento;
using PlanXBackend.Entidades.Response;
using PlanXBackend.Entidades.Response.ResEvento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Logica
{
    public class LogEvento
    {
        public ResInsertarEvento insertarEvento(ReqInsertarEvento req)
        {
            ResInsertarEvento res = new ResInsertarEvento();
            try
            {
                //Faltan Comprobaciones de otros datos
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Req null");
                }
                else if (String.IsNullOrEmpty(req.nombre))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Titulo faltante");
                }
                else if (String.IsNullOrEmpty(req.descripcion))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Descripcion faltante");
                }
                else if (req.idUsuario < 1)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Usuario Faltante");
                }
                else if (req.limUsers != null && req.limUsers < 1) 
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Limite incorrecto");
                }
                else if(req.duracion < 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Duracion incorrecta");
                }
                else
                {
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = null;
                    ConexionLINQDataContext linq = new ConexionLINQDataContext();
                    linq.SP_INSERTAR_EVENTO(req.nombre, req.descripcion, req.fecHoraInicio, req.fecHoraFin, req.limUsers, req.duracion, req.idUsuario, ref idReturn, ref errorId, ref errorDescripcion);
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
        public ResObtenerEvento obtenerEvento(ReqObtenerEvento req)
        {
            ResObtenerEvento res = new ResObtenerEvento();
            try
            {
                //Faltan Comprobaciones de otros datos
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Req null");
                }
                else if (String.IsNullOrEmpty(req.codInv))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Codigo faltante");
                }
                else
                {
                    int? errorId = 0;
                    string errorDescripcion = null;
                    ConexionLINQDataContext linq = new ConexionLINQDataContext();
                    SP_OBTENER_EVENTOResult resultado = new SP_OBTENER_EVENTOResult();
                    resultado = linq.SP_OBTENER_EVENTO( req.codInv, ref errorId, ref errorDescripcion).ToList().First();
                    if (errorId != 0)
                    {
                        res.resultado = false;
                        res.listaDeErrores.Add(errorDescripcion);

                    }
                    else
                    {
                        res.resultado = true;
                        res.evento = armarEvento(resultado);
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
        public ResObtenerListaEvento obtenerListaEvento(ReqObtenerListaEvento req)
        {
            ResObtenerListaEvento res = new ResObtenerListaEvento();
            try
            {
                //Faltan Comprobaciones de otros datos
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Req null");
                }
                else if (req.id < 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Error en el usuario");
                }
                else
                {
                    int? errorId = 0;
                    string errorDescripcion = null;
                    ConexionLINQDataContext linq = new ConexionLINQDataContext();
                    List<SP_OBTENER_LISTA_EVENTOSResult> resultado = new List<SP_OBTENER_LISTA_EVENTOSResult>();
                    resultado = linq.SP_OBTENER_LISTA_EVENTOS(req.id, ref errorId, ref errorDescripcion).ToList();
                    if (errorId != 0)
                    {
                        res.resultado = false;
                        res.listaDeErrores.Add(errorDescripcion);

                    }
                    else
                    {
                        res.resultado = true;
                        foreach (SP_OBTENER_LISTA_EVENTOSResult evento in resultado)
                        {
                            res.listaEventos.Add(armarListaEvento(evento));
                        }


                        
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

        public ResRegistroEventoRegular registrarEventoRegular(ReqRegistroEventoRegular req)
        {
            ResRegistroEventoRegular res = new ResRegistroEventoRegular();
            try
            {
                //Faltan Comprobaciones de otros datos
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Req null");
                }
                else if (req.idUser < 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Error en Usuario");
                }
                else if (String.IsNullOrEmpty(req.codInvi))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Codigo Faltate");
                }
                else if (req.fecFinal == DateTime.MinValue)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Fecha Final NO Valida");
                }
                else if (req.fecInicio == DateTime.MinValue)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Fecha Inicial NO Valida");
                }
                else
                {
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = null;
                    ConexionLINQDataContext linq = new ConexionLINQDataContext();
                    linq.SP_REGISTRO_EVENTO_REGULAR(req.idUser, req.codInvi, req.fecInicio, req.fecFinal, ref idReturn, ref errorId, ref errorDescripcion);
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
        private Evento armarEvento(SP_OBTENER_EVENTOResult eventoLinq)
        {
            Evento evento = new Evento();
            evento.nombre = eventoLinq.NOMBRE_EVENTO;
            evento.descripcion = eventoLinq.DESCRIPCION;
            evento.duracion = float.Parse(eventoLinq.DURACION.ToString());
            evento.limUsers = eventoLinq.LIM_USERS;
            evento.fecHoraInicio = eventoLinq.HORA_INICIO;
            evento.fecHoraFin = eventoLinq.HORA_FINAL;
            evento.codInvitacion = eventoLinq.COD_INV;

            return evento;
        }
        private Evento armarListaEvento(SP_OBTENER_LISTA_EVENTOSResult eventoLinq)
        {
            Evento evento = new Evento();
            evento.nombre = eventoLinq.NOMBRE_EVENTO;
            evento.descripcion = eventoLinq.DESCRIPCION;
            evento.duracion = float.Parse(eventoLinq.DURACION.ToString());
            evento.limUsers = eventoLinq.LIM_USERS;
            evento.fecHoraInicio = eventoLinq.HORA_INICIO;
            evento.fecHoraFin = eventoLinq.HORA_FINAL;
            evento.codInvitacion = eventoLinq.COD_INVI;

            return evento;
        }
    }
}
