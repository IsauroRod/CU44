using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU44.Clases_de_Entidad
{
    public class CambioEstado
    {
        private DateTime fechaHoraInicio;
        private Estado estado;

        public CambioEstado(DateTime fechaHoraInicio, DateTime? fechaHoraFin, Estado estado)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.estado = estado;
        }

        public DateTime getFechaHoraInicio()
        {
            return fechaHoraInicio;
        }

        public void setFechaHoraInicio(DateTime fechaInicio)
        {
            this.fechaHoraInicio = fechaInicio;
        }
        public string getNombreEstado()
        {
            return estado.getNombre();
        }


        public bool esEstadoInicial()
        {
            return estado.esIniciada();
        }
        public bool esEstadoFinalizada()
        {
            return estado.esFinalizada();
        }


    }
}
