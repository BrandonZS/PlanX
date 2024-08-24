using PlanXBackend.Acceso_Datos;
using PlanXBackend.Entidades.Entities;
using PlanXBackend.Entidades.Request;
using PlanXBackend.Entidades.Request.ReqEvento;
using PlanXBackend.Entidades.Response;
using PlanXBackend.Entidades.Response.ResEvento;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Logica
{
    public class LogRegistro
    {
        public ResObtenerRegistros obtenerRegistros(ReqObtenerEvento req)
        {
            ResObtenerRegistros res = new ResObtenerRegistros();
            LogEvento logEvento = new LogEvento();
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
                    res.listaDeErrores.Add("Error en el codigo");
                }
                else
                {
                    Evento evento = new Evento();
                    evento = logEvento.obtenerEvento(req).evento;
                    List<Registro> listaRegistros = new List<Registro>();
                    int? errorId = 0;
                    string errorDescripcion = null;
                    ConexionLINQDataContext linq = new ConexionLINQDataContext();
                    List<SP_OBTENER_REGISTROResult> resultado = new List<SP_OBTENER_REGISTROResult>();
                    resultado = linq.SP_OBTENER_REGISTRO(req.codInv, ref errorId, ref errorDescripcion).ToList();
                    if (errorId != 0)
                    {
                        res.resultado = false;
                        res.listaDeErrores.Add(errorDescripcion);

                    }
                    else
                    {
                        foreach (SP_OBTENER_REGISTROResult registro in resultado)
                        {
                            listaRegistros.Add(armarEvento(registro));
                        }
                        List<HorarioEvento> listaHorario = new List<HorarioEvento>();

                        DateTime tiempoInicial = evento.fecHoraInicio;
                        DateTime tiempoFinal = tiempoInicial.AddMinutes(evento.duracion);
                        while (tiempoFinal <= evento.fecHoraFin)
                        {
                            HorarioEvento horario = new HorarioEvento();
                            
                            foreach (Registro register in listaRegistros)
                            {
                                if (register.fecInicial >= tiempoInicial && register.fecFinal <= tiempoFinal)
                                {
                                    horario.registros.Add(register);
                                }
                            }
                            if (horario.registros.Count > 0) 
                            {
                                horario.horaInicio = tiempoInicial;
                                horario.horaFinal = tiempoInicial.AddMinutes(evento.duracion);
                                res.horarios.Add(horario);
                            }

                            tiempoInicial = tiempoInicial.AddMinutes(30);
                            tiempoFinal = tiempoFinal.AddMinutes(30);
                        }
                        res.horarios = res.horarios.OrderByDescending(h => h.registros.Count).Take(3).ToList();

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

        private Registro armarEvento(SP_OBTENER_REGISTROResult registroLinq)
        {
            Registro registro = new Registro();
            registro.nombre = registroLinq.NOMBRE_USUARIO;
            registro.apellido = registroLinq.APELLIDO_USUARIO;
            registro.fecInicial = registroLinq.FEC_INICIAL;
            registro.fecFinal = registroLinq.FEC_FINAL;
            return registro;
        }



    }

}
