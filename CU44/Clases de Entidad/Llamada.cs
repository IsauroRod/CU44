﻿using CU44.Clases_de_Soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CU44.Clases_de_Entidad
{
    public class Llamada
    {
        private int? duracion;
        private List<CambioEstado> cambiosEstado;
        private List<RespuestaDeCliente> respuestasDeClientes;
        private Cliente cliente;
        private Encuesta encuestaLlamada;

        

        public Llamada(Cliente cliente, Encuesta encuesta) 
        {
        this.duracion = null;
        this.cambiosEstado = new List<CambioEstado>();
        this.respuestasDeClientes = new List<RespuestaDeCliente>();
        this.cliente = cliente;
        this.encuestaLlamada = encuesta;
        }


        public void agregarCambioEstado(CambioEstado cambioEstado) 
        {
            cambiosEstado.Add(cambioEstado);
            if(this.buscarCambioEstadoFinal() != default) { 
                if(this.duracion == null) { this.duracion = this.calcularDuracion();  }
            }
        }

        public string getNombreCliente() 
        {
            return cliente.getNombreCompleto();
        }

        public void agregarRespuestaDeCliente(RespuestaDeCliente respuestaDeCliente) 
        {
            respuestasDeClientes.Add(respuestaDeCliente);
        }

        public DateTime getFechaInicio()
        {
            return buscarCambioEstadoInicial().getFechaHoraInicio();
        }

        public DateTime getFechaFin()
        {
            return buscarCambioEstadoFinal().getFechaHoraInicio();
        }


        public CambioEstado buscarCambioEstadoInicial()
        {
            CambioEstado cE = default;
            foreach (CambioEstado cambio in cambiosEstado)
            {
                if (cambio.esEstadoInicial())
                {
                    cE = cambio;
                    break;
                }
            }
            return cE;
        }
        public CambioEstado buscarCambioEstadoFinal()
        {
            CambioEstado cE = default;
            foreach (CambioEstado cambio in cambiosEstado)
            {
                if (cambio.esEstadoFinalizada())
                {
                    cE = cambio;
                    break;
                }
            }
            return cE;
        }

        public int calcularDuracion() 
        {
            CambioEstado estadoInicial = this.buscarCambioEstadoInicial();     
            CambioEstado estadoFinal = this.buscarCambioEstadoFinal();
            TimeSpan diferencia = estadoFinal.getFechaHoraInicio().Subtract(estadoInicial.getFechaHoraInicio());
            int minutos = (int)diferencia.TotalMinutes;
            return minutos;
            
        }

        public Boolean esDePeriodo(DateTime fechaInicio, DateTime? fechaFinal)
        {
            CambioEstado inicial = buscarCambioEstadoInicial();
            CambioEstado final = buscarCambioEstadoFinal();
            DateTime fechaHoraComienzoLlamado = inicial.getFechaHoraInicio(), fechaHoraFinLlamado = final.getFechaHoraInicio();
            Boolean estaEnPeriodo = fechaHoraComienzoLlamado.CompareTo(fechaInicio) >= 0;
            estaEnPeriodo = estaEnPeriodo && fechaHoraFinLlamado.CompareTo(fechaFinal) <= 0;
            return estaEnPeriodo;
        }
        public int? getDuracion
        {
            get => duracion;
            set => duracion = value;
        }

        public Boolean tieneRespuestas()
        {
            return (respuestasDeClientes.Count > 0);
        }

        public Encuesta getEncuesta()
        {
            return encuestaLlamada;
        }

        public List<String> getDescripcionRespuestasDeClientes()
        {
            List<String> listaRta = new List<String>();
            foreach (RespuestaDeCliente respuesta in respuestasDeClientes)
            {
                listaRta.Add(respuesta.DescripcionRta);
            }
            return listaRta;
        }

        public List<RespuestaDeCliente> getRespuestaDeClientes()
        {
            return respuestasDeClientes;
        }

        public CambioEstado ObtenerEstadoActual()
        {
            CambioEstado estadoActual = null;
            DateTime fechaMasReciente = DateTime.MinValue;

            foreach (CambioEstado cambio in cambiosEstado)
            {
                DateTime fechaHoraDeCambio = cambio.getFechaHoraInicio();
                if (fechaHoraDeCambio > fechaMasReciente)
                {
                    fechaMasReciente = fechaHoraDeCambio;
                    estadoActual = cambio;
                }
            }

            return estadoActual;
        }


        internal string getNombreEstadoActual()
        {
            return buscarCambioEstadoFinal().getNombreEstado();
        }

        public void iniciar(DateTime dateTime)
        {
            Estado iniciada = default;
            foreach (Estado estado in Mockup.traerTodosLosEstados())
            {
                if (estado.esIniciada()) { iniciada = estado; break; }
            }
            CambioEstado cambio = new CambioEstado(dateTime, iniciada);
            agregarCambioEstado(cambio);
        }

        public void iniciar()
        {
            iniciar(DateTime.Now);
        }

        public void finalizar(DateTime dateTime)
        {
            Estado finalizada = default;
            foreach (Estado estado in Mockup.traerTodosLosEstados())
            {
                if (estado.esFinalizada()) { finalizada = estado; break; }
            }
            CambioEstado cambio = new CambioEstado(dateTime, finalizada);
            agregarCambioEstado(cambio);
        }

        public void finalizar()
        {
            finalizar(DateTime.Now);
        }

        public void atender(DateTime fecha)
        {
            Estado enCurso = default;
            foreach (Estado estado in Mockup.traerTodosLosEstados())
            {
                if (estado.esEnCurso()) { enCurso = estado; break; }
            }
            CambioEstado cambio = new CambioEstado(fecha, enCurso);
            agregarCambioEstado(cambio);
        }

        public void atender() { 
            atender(DateTime.Now); 
        }

        public void escuchar(DateTime fecha)
        {
            Estado escuchada = default;
            foreach (Estado estado in Mockup.traerTodosLosEstados())
            {
                if (estado.esEscuchada()) { escuchada = estado; break; }
            }
            CambioEstado cambio = new CambioEstado(fecha, escuchada);
            agregarCambioEstado(cambio);
        }

        public void escuchar()
        {
            escuchar(DateTime.Now);
        }

        public List<CambioEstado> GetCambioEstados()
        {
            return cambiosEstado;
        }
    }
}
