﻿namespace Clinica_Frba.Agendas
{
    partial class FrmAgendaConsultar
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbProfesional = new System.Windows.Forms.TextBox();
            this.btnBuscarProfesional = new System.Windows.Forms.Button();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.btnTurnos = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.mcDesde = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profesional";
            // 
            // tbProfesional
            // 
            this.tbProfesional.Location = new System.Drawing.Point(100, 12);
            this.tbProfesional.Name = "tbProfesional";
            this.tbProfesional.ReadOnly = true;
            this.tbProfesional.Size = new System.Drawing.Size(286, 20);
            this.tbProfesional.TabIndex = 1;
            // 
            // btnBuscarProfesional
            // 
            this.btnBuscarProfesional.Location = new System.Drawing.Point(392, 10);
            this.btnBuscarProfesional.Name = "btnBuscarProfesional";
            this.btnBuscarProfesional.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarProfesional.TabIndex = 2;
            this.btnBuscarProfesional.Text = "Buscar";
            this.btnBuscarProfesional.UseVisualStyleBackColor = true;
            this.btnBuscarProfesional.Click += new System.EventHandler(this.btnBuscarProfesional_Click);
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Location = new System.Drawing.Point(24, 213);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnos.Size = new System.Drawing.Size(680, 227);
            this.dgvTurnos.TabIndex = 5;
            // 
            // btnTurnos
            // 
            this.btnTurnos.Enabled = false;
            this.btnTurnos.Location = new System.Drawing.Point(600, 175);
            this.btnTurnos.Name = "btnTurnos";
            this.btnTurnos.Size = new System.Drawing.Size(104, 23);
            this.btnTurnos.TabIndex = 4;
            this.btnTurnos.Text = "Turnos disponibles";
            this.btnTurnos.UseVisualStyleBackColor = true;
            this.btnTurnos.Click += new System.EventHandler(this.btnTurnos_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(629, 446);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // mcDesde
            // 
            this.mcDesde.Enabled = false;
            this.mcDesde.Location = new System.Drawing.Point(479, 10);
            this.mcDesde.MaxSelectionCount = 1;
            this.mcDesde.Name = "mcDesde";
            this.mcDesde.TabIndex = 3;
            // 
            // FrmAgendaConsultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 472);
            this.Controls.Add(this.mcDesde);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnTurnos);
            this.Controls.Add(this.dgvTurnos);
            this.Controls.Add(this.btnBuscarProfesional);
            this.Controls.Add(this.tbProfesional);
            this.Controls.Add(this.label1);
            this.Name = "FrmAgendaConsultar";
            this.Text = "Clinica FRBA - Agenda - Consultar";
            this.Load += new System.EventHandler(this.FrmAgendaConsultar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProfesional;
        private System.Windows.Forms.Button btnBuscarProfesional;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.Button btnTurnos;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.MonthCalendar mcDesde;
    }
}