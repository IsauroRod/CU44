
namespace CU44
{
    partial class PantallaConsultarEncuesta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaConsultarEncuesta));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgLlamadas = new System.Windows.Forms.DataGridView();
            this.btnIngresarPeriodo = new System.Windows.Forms.Button();
            this.dgEncuesta = new System.Windows.Forms.DataGridView();
            this.fechaInicioPer = new System.Windows.Forms.DateTimePicker();
            this.fechaFinPer = new System.Windows.Forms.DateTimePicker();
            this.btnImprimirCSV = new System.Windows.Forms.Button();
            this.lbNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgLlamadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEncuesta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha Inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Fin: ";
            // 
            // dgLlamadas
            // 
            this.dgLlamadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLlamadas.Enabled = false;
            this.dgLlamadas.Location = new System.Drawing.Point(64, 118);
            this.dgLlamadas.Name = "dgLlamadas";
            this.dgLlamadas.RowTemplate.Height = 25;
            this.dgLlamadas.Size = new System.Drawing.Size(512, 352);
            this.dgLlamadas.TabIndex = 4;
            // 
            // btnIngresarPeriodo
            // 
            this.btnIngresarPeriodo.Location = new System.Drawing.Point(654, 69);
            this.btnIngresarPeriodo.Name = "btnIngresarPeriodo";
            this.btnIngresarPeriodo.Size = new System.Drawing.Size(195, 23);
            this.btnIngresarPeriodo.TabIndex = 6;
            this.btnIngresarPeriodo.Text = "Filtrar Por Periodo";
            this.btnIngresarPeriodo.UseVisualStyleBackColor = true;
            // 
            // dgEncuesta
            // 
            this.dgEncuesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEncuesta.Location = new System.Drawing.Point(606, 118);
            this.dgEncuesta.Name = "dgEncuesta";
            this.dgEncuesta.RowTemplate.Height = 25;
            this.dgEncuesta.Size = new System.Drawing.Size(431, 352);
            this.dgEncuesta.TabIndex = 7;
            // 
            // fechaInicioPer
            // 
            this.fechaInicioPer.Location = new System.Drawing.Point(104, 69);
            this.fechaInicioPer.Name = "fechaInicioPer";
            this.fechaInicioPer.Size = new System.Drawing.Size(210, 23);
            this.fechaInicioPer.TabIndex = 8;
            // 
            // fechaFinPer
            // 
            this.fechaFinPer.Location = new System.Drawing.Point(407, 69);
            this.fechaFinPer.Name = "fechaFinPer";
            this.fechaFinPer.Size = new System.Drawing.Size(211, 23);
            this.fechaFinPer.TabIndex = 9;
            // 
            // btnImprimirCSV
            // 
            this.btnImprimirCSV.Enabled = false;
            this.btnImprimirCSV.Location = new System.Drawing.Point(925, 509);
            this.btnImprimirCSV.Name = "btnImprimirCSV";
            this.btnImprimirCSV.Size = new System.Drawing.Size(112, 23);
            this.btnImprimirCSV.TabIndex = 10;
            this.btnImprimirCSV.Text = "Imprimir Encuesta";
            this.btnImprimirCSV.UseVisualStyleBackColor = true;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbNombre.Location = new System.Drawing.Point(779, 95);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(59, 25);
            this.lbNombre.TabIndex = 11;
            this.lbNombre.Text = "label3";
            this.lbNombre.Visible = false;
            // 
            // PantallaConsultarEncuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1086, 544);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.btnImprimirCSV);
            this.Controls.Add(this.fechaFinPer);
            this.Controls.Add(this.fechaInicioPer);
            this.Controls.Add(this.dgEncuesta);
            this.Controls.Add(this.btnIngresarPeriodo);
            this.Controls.Add(this.dgLlamadas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PantallaConsultarEncuesta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar   Encuesta";
            this.Load += new System.EventHandler(this.PantallaConsultarEncuesta_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgLlamadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEncuesta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgLlamadas;
        private System.Windows.Forms.Button btnIngresarPeriodo;
        private System.Windows.Forms.DataGridView dgEncuesta;
        private System.Windows.Forms.DateTimePicker fechaInicioPer;
        private System.Windows.Forms.DateTimePicker fechaFinPer;
        private System.Windows.Forms.Button btnImprimirCSV;
        private System.Windows.Forms.Label lbNombre;
    }
}