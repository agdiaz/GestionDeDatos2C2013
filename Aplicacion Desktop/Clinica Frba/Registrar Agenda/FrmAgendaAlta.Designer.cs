namespace Clinica_Frba.Agendas
{
    partial class FrmAgendaAlta
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbProfesional = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbDatosAgenda = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCargarDetalles = new System.Windows.Forms.Button();
            this.dpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuitarDia = new System.Windows.Forms.Button();
            this.tbHorasSemanales = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listCronograma = new System.Windows.Forms.ListBox();
            this.btnAgregarDia = new System.Windows.Forms.Button();
            this.gbDetalleDiario = new System.Windows.Forms.GroupBox();
            this.btnCargarExc = new System.Windows.Forms.Button();
            this.nudHastaMinuto = new System.Windows.Forms.NumericUpDown();
            this.nudDesdeMinuto = new System.Windows.Forms.NumericUpDown();
            this.nudHasta = new System.Windows.Forms.NumericUpDown();
            this.nudDesde = new System.Windows.Forms.NumericUpDown();
            this.cbDia = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.gbExcepciones = new System.Windows.Forms.GroupBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnQuitarExc = new System.Windows.Forms.Button();
            this.btnAgregarExc = new System.Windows.Forms.Button();
            this.listExcepciones = new System.Windows.Forms.ListBox();
            this.dpExcepcion = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbDatosAgenda.SuspendLayout();
            this.gbDetalleDiario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHastaMinuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesdeMinuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesde)).BeginInit();
            this.gbExcepciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profesional";
            // 
            // tbProfesional
            // 
            this.tbProfesional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProfesional.Location = new System.Drawing.Point(88, 44);
            this.tbProfesional.Name = "tbProfesional";
            this.tbProfesional.ReadOnly = true;
            this.tbProfesional.Size = new System.Drawing.Size(492, 20);
            this.tbProfesional.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(586, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(85, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbDatosAgenda
            // 
            this.gbDatosAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatosAgenda.Controls.Add(this.label10);
            this.gbDatosAgenda.Controls.Add(this.btnCargarDetalles);
            this.gbDatosAgenda.Controls.Add(this.dpFechaHasta);
            this.gbDatosAgenda.Controls.Add(this.dpFechaDesde);
            this.gbDatosAgenda.Controls.Add(this.label3);
            this.gbDatosAgenda.Controls.Add(this.label2);
            this.gbDatosAgenda.Controls.Add(this.label1);
            this.gbDatosAgenda.Controls.Add(this.btnBuscar);
            this.gbDatosAgenda.Controls.Add(this.tbProfesional);
            this.gbDatosAgenda.Location = new System.Drawing.Point(12, 12);
            this.gbDatosAgenda.Name = "gbDatosAgenda";
            this.gbDatosAgenda.Size = new System.Drawing.Size(677, 128);
            this.gbDatosAgenda.TabIndex = 3;
            this.gbDatosAgenda.TabStop = false;
            this.gbDatosAgenda.Text = "Datos de la agenda";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(623, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "En esta sección debe seleccionar el profesional y el rango de fechas a cargar las" +
                " horas. Cuando finalice presione \"Cargar detalles\"";
            // 
            // btnCargarDetalles
            // 
            this.btnCargarDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarDetalles.Location = new System.Drawing.Point(571, 99);
            this.btnCargarDetalles.Name = "btnCargarDetalles";
            this.btnCargarDetalles.Size = new System.Drawing.Size(100, 23);
            this.btnCargarDetalles.TabIndex = 6;
            this.btnCargarDetalles.Text = "Cargar detalles";
            this.btnCargarDetalles.UseVisualStyleBackColor = true;
            this.btnCargarDetalles.Click += new System.EventHandler(this.btnCargarDetalles_Click);
            // 
            // dpFechaHasta
            // 
            this.dpFechaHasta.Location = new System.Drawing.Point(367, 72);
            this.dpFechaHasta.Name = "dpFechaHasta";
            this.dpFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.dpFechaHasta.TabIndex = 4;
            // 
            // dpFechaDesde
            // 
            this.dpFechaDesde.Location = new System.Drawing.Point(88, 73);
            this.dpFechaDesde.Name = "dpFechaDesde";
            this.dpFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.dpFechaDesde.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha hasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha desde";
            // 
            // btnQuitarDia
            // 
            this.btnQuitarDia.Location = new System.Drawing.Point(243, 104);
            this.btnQuitarDia.Name = "btnQuitarDia";
            this.btnQuitarDia.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarDia.TabIndex = 10;
            this.btnQuitarDia.Text = "Quitar día";
            this.btnQuitarDia.UseVisualStyleBackColor = true;
            this.btnQuitarDia.Click += new System.EventHandler(this.btnQuitarDia_Click);
            // 
            // tbHorasSemanales
            // 
            this.tbHorasSemanales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHorasSemanales.Location = new System.Drawing.Point(561, 107);
            this.tbHorasSemanales.Name = "tbHorasSemanales";
            this.tbHorasSemanales.ReadOnly = true;
            this.tbHorasSemanales.Size = new System.Drawing.Size(100, 20);
            this.tbHorasSemanales.TabIndex = 3;
            this.tbHorasSemanales.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total horas semanales";
            // 
            // listCronograma
            // 
            this.listCronograma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listCronograma.FormattingEnabled = true;
            this.listCronograma.Location = new System.Drawing.Point(324, 19);
            this.listCronograma.Name = "listCronograma";
            this.listCronograma.Size = new System.Drawing.Size(347, 82);
            this.listCronograma.TabIndex = 9;
            // 
            // btnAgregarDia
            // 
            this.btnAgregarDia.Location = new System.Drawing.Point(162, 104);
            this.btnAgregarDia.Name = "btnAgregarDia";
            this.btnAgregarDia.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarDia.TabIndex = 8;
            this.btnAgregarDia.Text = "Agregar día";
            this.btnAgregarDia.UseVisualStyleBackColor = true;
            this.btnAgregarDia.Click += new System.EventHandler(this.AgregarDia_Click);
            // 
            // gbDetalleDiario
            // 
            this.gbDetalleDiario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetalleDiario.Controls.Add(this.btnCargarExc);
            this.gbDetalleDiario.Controls.Add(this.label4);
            this.gbDetalleDiario.Controls.Add(this.tbHorasSemanales);
            this.gbDetalleDiario.Controls.Add(this.btnQuitarDia);
            this.gbDetalleDiario.Controls.Add(this.nudHastaMinuto);
            this.gbDetalleDiario.Controls.Add(this.listCronograma);
            this.gbDetalleDiario.Controls.Add(this.nudDesdeMinuto);
            this.gbDetalleDiario.Controls.Add(this.nudHasta);
            this.gbDetalleDiario.Controls.Add(this.btnAgregarDia);
            this.gbDetalleDiario.Controls.Add(this.nudDesde);
            this.gbDetalleDiario.Controls.Add(this.cbDia);
            this.gbDetalleDiario.Controls.Add(this.label7);
            this.gbDetalleDiario.Controls.Add(this.label6);
            this.gbDetalleDiario.Controls.Add(this.label5);
            this.gbDetalleDiario.Location = new System.Drawing.Point(12, 146);
            this.gbDetalleDiario.Name = "gbDetalleDiario";
            this.gbDetalleDiario.Size = new System.Drawing.Size(677, 165);
            this.gbDetalleDiario.TabIndex = 1;
            this.gbDetalleDiario.TabStop = false;
            this.gbDetalleDiario.Text = "Detalle diario";
            // 
            // btnCargarExc
            // 
            this.btnCargarExc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarExc.Location = new System.Drawing.Point(561, 136);
            this.btnCargarExc.Name = "btnCargarExc";
            this.btnCargarExc.Size = new System.Drawing.Size(110, 23);
            this.btnCargarExc.TabIndex = 11;
            this.btnCargarExc.Text = "Cargar excepciones";
            this.btnCargarExc.UseVisualStyleBackColor = true;
            this.btnCargarExc.Click += new System.EventHandler(this.btnCargarExc_Click);
            // 
            // nudHastaMinuto
            // 
            this.nudHastaMinuto.Location = new System.Drawing.Point(198, 75);
            this.nudHastaMinuto.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudHastaMinuto.Name = "nudHastaMinuto";
            this.nudHastaMinuto.Size = new System.Drawing.Size(120, 20);
            this.nudHastaMinuto.TabIndex = 10;
            this.nudHastaMinuto.ValueChanged += new System.EventHandler(this.nudHastaMinuto_ValueChanged);
            // 
            // nudDesdeMinuto
            // 
            this.nudDesdeMinuto.Location = new System.Drawing.Point(198, 49);
            this.nudDesdeMinuto.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudDesdeMinuto.Name = "nudDesdeMinuto";
            this.nudDesdeMinuto.Size = new System.Drawing.Size(120, 20);
            this.nudDesdeMinuto.TabIndex = 9;
            this.nudDesdeMinuto.ValueChanged += new System.EventHandler(this.nudDesdeMinuto_ValueChanged);
            // 
            // nudHasta
            // 
            this.nudHasta.Location = new System.Drawing.Point(58, 75);
            this.nudHasta.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudHasta.Name = "nudHasta";
            this.nudHasta.Size = new System.Drawing.Size(133, 20);
            this.nudHasta.TabIndex = 7;
            // 
            // nudDesde
            // 
            this.nudDesde.Location = new System.Drawing.Point(58, 49);
            this.nudDesde.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudDesde.Name = "nudDesde";
            this.nudDesde.Size = new System.Drawing.Size(133, 20);
            this.nudDesde.TabIndex = 6;
            // 
            // cbDia
            // 
            this.cbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDia.FormattingEnabled = true;
            this.cbDia.Location = new System.Drawing.Point(58, 21);
            this.cbDia.Name = "cbDia";
            this.cbDia.Size = new System.Drawing.Size(260, 21);
            this.cbDia.TabIndex = 5;
            this.cbDia.SelectedValueChanged += new System.EventHandler(this.cbDia_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Hasta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Desde";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Día";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(452, 449);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(533, 449);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Limpiar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(614, 449);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Cancelar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // gbExcepciones
            // 
            this.gbExcepciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExcepciones.Controls.Add(this.btnFinalizar);
            this.gbExcepciones.Controls.Add(this.btnQuitarExc);
            this.gbExcepciones.Controls.Add(this.btnAgregarExc);
            this.gbExcepciones.Controls.Add(this.listExcepciones);
            this.gbExcepciones.Controls.Add(this.dpExcepcion);
            this.gbExcepciones.Controls.Add(this.label9);
            this.gbExcepciones.Controls.Add(this.label8);
            this.gbExcepciones.Location = new System.Drawing.Point(12, 317);
            this.gbExcepciones.Name = "gbExcepciones";
            this.gbExcepciones.Size = new System.Drawing.Size(677, 126);
            this.gbExcepciones.TabIndex = 14;
            this.gbExcepciones.TabStop = false;
            this.gbExcepciones.Text = "Excepciones";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.Location = new System.Drawing.Point(561, 97);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(110, 23);
            this.btnFinalizar.TabIndex = 6;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnQuitarExc
            // 
            this.btnQuitarExc.Location = new System.Drawing.Point(264, 71);
            this.btnQuitarExc.Name = "btnQuitarExc";
            this.btnQuitarExc.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarExc.TabIndex = 5;
            this.btnQuitarExc.Text = "Quitar exc.";
            this.btnQuitarExc.UseVisualStyleBackColor = true;
            this.btnQuitarExc.Click += new System.EventHandler(this.btnQuitarExc_Click);
            // 
            // btnAgregarExc
            // 
            this.btnAgregarExc.Location = new System.Drawing.Point(264, 44);
            this.btnAgregarExc.Name = "btnAgregarExc";
            this.btnAgregarExc.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarExc.TabIndex = 4;
            this.btnAgregarExc.Text = "Agregar exc.";
            this.btnAgregarExc.UseVisualStyleBackColor = true;
            this.btnAgregarExc.Click += new System.EventHandler(this.btnAgregarExc_Click);
            // 
            // listExcepciones
            // 
            this.listExcepciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listExcepciones.FormattingEnabled = true;
            this.listExcepciones.Location = new System.Drawing.Point(370, 19);
            this.listExcepciones.Name = "listExcepciones";
            this.listExcepciones.Size = new System.Drawing.Size(291, 69);
            this.listExcepciones.TabIndex = 3;
            // 
            // dpExcepcion
            // 
            this.dpExcepcion.Location = new System.Drawing.Point(58, 47);
            this.dpExcepcion.Name = "dpExcepcion";
            this.dpExcepcion.Size = new System.Drawing.Size(200, 20);
            this.dpExcepcion.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Fecha";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(358, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cargue en esta sección los días dentro del rango que no vendrá a trabajar";
            // 
            // FrmAgendaAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 484);
            this.Controls.Add(this.gbExcepciones);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbDetalleDiario);
            this.Controls.Add(this.gbDatosAgenda);
            this.Name = "FrmAgendaAlta";
            this.Text = "Clinica FRBA - Agenda - Administrar";
            this.Load += new System.EventHandler(this.FrmAgendaAlta_Load);
            this.gbDatosAgenda.ResumeLayout(false);
            this.gbDatosAgenda.PerformLayout();
            this.gbDetalleDiario.ResumeLayout(false);
            this.gbDetalleDiario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHastaMinuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesdeMinuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesde)).EndInit();
            this.gbExcepciones.ResumeLayout(false);
            this.gbExcepciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProfesional;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gbDatosAgenda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHorasSemanales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbDetalleDiario;
        private System.Windows.Forms.ListBox listCronograma;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnQuitarDia;
        private System.Windows.Forms.Button btnAgregarDia;
        private System.Windows.Forms.NumericUpDown nudHasta;
        private System.Windows.Forms.NumericUpDown nudDesde;
        private System.Windows.Forms.ComboBox cbDia;
        private System.Windows.Forms.DateTimePicker dpFechaHasta;
        private System.Windows.Forms.DateTimePicker dpFechaDesde;
        private System.Windows.Forms.NumericUpDown nudHastaMinuto;
        private System.Windows.Forms.NumericUpDown nudDesdeMinuto;
        private System.Windows.Forms.Button btnCargarDetalles;
        private System.Windows.Forms.GroupBox gbExcepciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listExcepciones;
        private System.Windows.Forms.DateTimePicker dpExcepcion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAgregarExc;
        private System.Windows.Forms.Button btnQuitarExc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCargarExc;
        private System.Windows.Forms.Button btnFinalizar;
    }
}