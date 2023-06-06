using CU44.Clases_de_Entidad;
using CU44.Clases_de_Soporte;
using CU44.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace CU44
{
    public partial class PantallaConsultarEncuesta : Form
    {

        ControladorConsultarEncuesta controlador;

        public PantallaConsultarEncuesta()
        {
            InitializeComponent();
            controlador = new ControladorConsultarEncuesta(this);
        }

        private void btnIngresarPeriodo_Click(object sender, EventArgs e)
        {
            controlador.tomarDatosPeriodoLlamada(fechaInicioPer.Value, fechaFinPer.Value);
        }
        public void pedirSeleccionLlamada(List<Llamada> llamadasRespondidas)
        {
            DataTable dtLlamadas = controlador.llamadasToDataTable(llamadasRespondidas);
            dgLlamadas.DataSource = dtLlamadas;
            dgLlamadas.Enabled = true;
        }


        private void tomarSeleccionLlamada(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            controlador.tomarSeleccionLlamada(indice);
            //String nombre = controlador.getLlamadaSeleccionada().getNombreCliente();
            //Encuesta encuesta = controlador.getEncuestaLlamada();
            //DataTable dtEncuesta = controlador.encuestasToDataTable(encuesta);
            //lbNombre.Text = "Encuestado: " + nombre;
            //lbNombre.Visible = true;
            //dgEncuesta.DataSource = dtEncuesta;
            //btnImprimirCSV.Enabled = true;

        }

        public void mostrarDatosLlamada(String nombre, DataTable dtEncuesta)
        {
            lbNombre.Text = "Encuestado: " + nombre;
            lbNombre.Visible = true;
            dgEncuesta.DataSource = dtEncuesta;
            btnImprimirCSV.Enabled = true;
        }

        private void btnImprimirCSV_Click(object sender, EventArgs e)
        {
            CSV c = new CSV();
            Encuesta encuesta = controlador.getEncuestaLlamada();
            Llamada llamada = controlador.getLlamadaSeleccionada();
            c.imprimirCSVdeEncuesta(encuesta, llamada);
            controlador.finCU();
        }

        private void PantallaConsultarEncuesta_Load_1(object sender, EventArgs e)
        {
            List<Llamada> llamadas = controlador.getLlamadas();
            DataTable dtLlamadas = controlador.llamadasToDataTable(llamadas);
            dgLlamadas.DataSource = dtLlamadas;
        }
    }
}
