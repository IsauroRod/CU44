using CU44.Clases_de_Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CU44.Clases_de_Soporte
{
    class CSV
    {
        public CSV()
        {

        }



        public void imprimirCSVdeEncuesta(Encuesta e, Llamada l)
        {
            CambioEstado cambioEstadoActual = l.ObtenerEstadoActual();
            String ruta = ".\\" + "Encuesta.csv", linea; 
            TextWriter file = new StreamWriter(ruta);
            file.WriteLine("Nombre Cliente, Estado Actual, Duracion de Llamada");
            file.WriteLine(l.getNombreCliente() + "," + cambioEstadoActual.getNombreEstado() + "," + l.getDuracion.ToString());
            file.WriteLine();
            file.WriteLine("Pregunta, Respuesta");
            
            foreach (Pregunta pregunta in e.getPreguntas())
            {
                linea = "";
                linea += pregunta.getPregunta() + ", ";
                foreach (RespuestaPosible preguntaPosible in pregunta.getRespuestasPosible())
                {
                    foreach (RespuestaDeCliente respuestaDeCliente in l.getRespuestaDeClientes())
                    {
                        if ((preguntaPosible.getDescripcion()).Equals(respuestaDeCliente.DescripcionRta))
                        {
                            linea += respuestaDeCliente.DescripcionRta;
                        }
                    }
                }
                file.WriteLine(linea);
            }
            file.Close();

            MessageBox.Show("Escritura Exitosa");
        }
    }
}
