using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CU44.Clases_de_Entidad
{
    public class Pregunta
    {
        private string pregunta;
        private List<RespuestaPosible> respuestasPosibles;
        public Pregunta(string preg) 
        { 
            this.pregunta = preg;
            this.respuestasPosibles = new List<RespuestaPosible>();
        }

        public void agregarRespuesta(RespuestaPosible rta)
        {
            if(!respuestasPosibles.Contains(rta)) respuestasPosibles.Add(rta);
        }

        public void agregarRespuesta(String descripcion, String valor)
        {
            agregarRespuesta(new RespuestaPosible(descripcion, valor));
        }

        public string ListarRespuestasPosibles()
        {
            StringBuilder cadena = new StringBuilder();

            foreach (RespuestaPosible respuestaInd in respuestasPosibles)
            {
                cadena.AppendLine(respuestaInd.getValor());
            }

            return cadena.ToString();
        }

        public string getPregunta()
        {
            return pregunta;
        }

        public List<RespuestaPosible> getRespuestasPosible()
        {
            return respuestasPosibles;
        }

        public RespuestaPosible getRespuestaPosible(int i)
        {
            i--; // Correcion al colocar 1 es 0.
            RespuestaPosible respuestaPosible = default;
            try
            {
                respuestaPosible = respuestasPosibles[i];
            }
            catch (Exception)
            {
                MessageBox.Show("Respuesta inexistente");
            }
            return respuestaPosible;
        }

    }
}
