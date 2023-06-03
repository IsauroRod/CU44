using CU44.Clases_de_Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CU44.Controlador
{
    class ControladorConsultarEncuesta
    {
        private DateTime fechaInicio, fechaFin;
        private PantallaConsultarEncuesta pantalla;
        private List<Llamada> llamadas;
        private Llamada llamadaSeleccionada;
        private List<Llamada> llamadasRespondidas;
        public ControladorConsultarEncuesta()
        {

        }
        public ControladorConsultarEncuesta(PantallaConsultarEncuesta v)
        {
            this.pantalla = v;
            llamadas = getAll();
            llamadasRespondidas = buscarLlamadasRespondidas();
        }
        public void tomarDatosPeriodoLlamada(DateTime fechaInicio, DateTime fechaFin)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            List<Llamada> llamadasRespondidas = buscarLlamadasRespondidas();
            pantalla.pedirSeleccionLlamada(llamadasRespondidas);
        }

        public List<Llamada> buscarLlamadasRespondidas()
        {
            llamadasRespondidas = new List<Llamada>();
            foreach (Llamada llamada in llamadas)
            {
                if (llamada.esDePeriodo(fechaInicio, fechaFin) && llamada.tieneRespuestas())
                {
                    llamadasRespondidas.Add(llamada);
                }
            }


            return llamadasRespondidas;
        }

        public List<Llamada> getAll()
        {

            llamadas = Llamada.traerTodasLasLlamadas();
            return llamadas;

        }

        public List<Llamada> getLlamadasRespondidas()
        {
            return llamadasRespondidas;
        }

        public List<Llamada> getLlamadas()
        {
            return llamadas;
        }

        public DataTable llamadasToDataTable(List<Llamada> llamadas)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Duracion");
            dt.Columns.Add("Cliente");
            dt.Columns.Add("Fecha Inicio");
            dt.Columns.Add("Fecha Fin");
            dt.Columns.Add("Estado Actual");
            foreach (Llamada llamada in llamadas)
            {
                string nombreCliente = llamada.getNombreCliente();
                int? duracion = llamada.getDuracion;
                CambioEstado estadoActual = llamada.ObtenerEstadoActual();
                string nombreEstado = estadoActual.getNombreEstado();

                DataRow fila = dt.NewRow();
                fila["Duracion"] = duracion;
                fila["Cliente"] = nombreCliente;
                fila["Fecha Inicio"] = llamada.getFechaInicio();
                fila["Fecha Fin"] = llamada.getFechaFin();
                fila["Estado Actual"] = nombreEstado;
                dt.Rows.Add(fila);
            }
            return dt;
        }
        public DataTable encuestasToDataTable(Encuesta encuesta)
        {
            List<Encuesta> encuestas = new List<Encuesta> { encuesta };
            return encuestasToDataTable(encuestas);

        }



        public DataTable encuestasToDataTable(List<Encuesta> encuestas)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Descripcion Encuesta");
            dt.Columns.Add("Pregunta");
            dt.Columns.Add("Fecha Vigencia");
            dt.Columns.Add("Respuesta");
            dt.Columns.Add("Respuesta Respondida");


            foreach (Encuesta encuesta in encuestas)
            {
                DataRow fila = dt.NewRow();
                //fila["Fecha Vigencia"] = encuesta.getFechaVigencia();
                //dt.Rows.Add(fila);
                //fila = dt.NewRow();
                foreach (Pregunta pregunta in encuesta.getPreguntas())
                {
                    //fila["Pregunta"] = pregunta.getPregunta();
                    foreach (RespuestaPosible respuestaPosible in pregunta.getRespuestaPosible())
                    {

                        fila = dt.NewRow();
                        fila["Descripcion Encuesta"] = encuesta.getDescripcion();
                        fila["Fecha Vigencia"] = encuesta.getFechaVigencia();
                        fila["Pregunta"] = pregunta.getPregunta();
                        fila["Respuesta"] = respuestaPosible.getValor();


                        foreach (RespuestaDeCliente respuestaDeCliente in llamadaSeleccionada.getRespuestaDeClientes())
                        {
                            if ((respuestaPosible.getDescripcion()).Equals(respuestaDeCliente.DescripcionRta))
                            {
                                fila["Respuesta Respondida"] = "x";
                                break;
                            }

                        }

                        dt.Rows.Add(fila);

                    }

                }


            }

            return dt;
        }

        public void finCU()
        {
            MessageBox.Show("Fin de Caso de Uso");
        }
        public void getDatosLlamada()
        {
            String nombreCliente = llamadaSeleccionada.getNombreCliente();
            Encuesta encuesta = getEncuestaLlamada();
            DataTable dtEncuesta = encuestasToDataTable(encuesta);
            pantalla.mostrarDatosLlamada(nombreCliente, dtEncuesta);
        }

        public void tomarSeleccionLlamada(int indice)
        {
            try
            {
                llamadaSeleccionada = llamadasRespondidas[indice];
                getDatosLlamada();
            }
            catch (Exception)
            {
                MessageBox.Show(indice.ToString() + " Fuera de Termino ");
            }
        }

        public Encuesta getEncuestaLlamada()
        {
            return llamadaSeleccionada.getEncuesta();

        }

        public Llamada getLlamadaSeleccionada()
        {
            return llamadaSeleccionada;
        }
    }
}
