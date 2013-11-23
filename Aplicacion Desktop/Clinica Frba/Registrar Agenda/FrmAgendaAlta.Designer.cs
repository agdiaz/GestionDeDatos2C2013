﻿namespace Clinica_Frba.Agendas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHastaMinuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesdeMinuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesde)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profesional";
            // 
            // tbProfesional
            // 
            this.tbProfesional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProfesional.Location = new System.Drawing.Point(81, 29);
            this.tbProfesional.Name = "tbProfesional";
            this.tbProfesional.ReadOnly = true;
            this.tbProfesional.Size = new System.Drawing.Size(499, 20);
            this.tbProfesional.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(586, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(85, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCargarDetalles);
            this.groupBox1.Controls.Add(this.dpFechaHasta);
            this.groupBox1.Controls.Add(this.dpFechaDesde);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.tbProfesional);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 128);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la agenda";
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
            // 
            // dpFechaHasta
            // 
            this.dpFechaHasta.Location = new System.Drawing.Point(81, 91);
            this.dpFechaHasta.Name = "dpFechaHasta";
            this.dpFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.dpFechaHasta.TabIndex = 4;
            // 
            // dpFechaDesde
            // 
            this.dpFechaDesde.Location = new System.Drawing.Point(81, 59);
            this.dpFechaDesde.Name = "dpFechaDesde";
            this.dpFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.dpFechaDesde.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha hasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha desde";
            // 
            // btnQuitarDia
            // 
            this.btnQuitarDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.tbHorasSemanales.Location = new System.Drawing.Point(561, 142);
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
            this.label4.Location = new System.Drawing.Point(442, 145);
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
            this.listCronograma.Size = new System.Drawing.Size(337, 108);
            this.listCronograma.TabIndex = 9;
            // 
            // btnAgregarDia
            // 
            this.btnAgregarDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregarDia.Location = new System.Drawing.Point(162, 104);
            this.btnAgregarDia.Name = "btnAgregarDia";
            this.btnAgregarDia.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarDia.TabIndex = 8;
            this.btnAgregarDia.Text = "Agregar día";
            this.btnAgregarDia.UseVisualStyleBackColor = true;
            this.btnAgregarDia.Click += new System.EventHandler(this.AgregarDia_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbHorasSemanales);
            this.groupBox3.Controls.Add(this.btnQuitarDia);
            this.groupBox3.Controls.Add(this.nudHastaMinuto);
            this.groupBox3.Controls.Add(this.listCronograma);
            this.groupBox3.Controls.Add(this.nudDesdeMinuto);
            this.groupBox3.Controls.Add(this.nudHasta);
            this.groupBox3.Controls.Add(this.btnAgregarDia);
            this.groupBox3.Controls.Add(this.nudDesde);
            this.groupBox3.Controls.Add(this.cbDia);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(677, 165);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalle diario";
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
            // FrmAgendaAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 484);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAgendaAlta";
            this.Text = "Clinica FRBA - Agenda - Administrar";
            this.Load += new System.EventHandler(this.FrmAgendaAlta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHastaMinuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesdeMinuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesde)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProfesional;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHorasSemanales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
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
    }
}