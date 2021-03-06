﻿namespace Clinica_Frba.Planes
{
    partial class FrmPlanListado
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
            this.tbNombrePlan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBonoFarmacia = new System.Windows.Forms.TextBox();
            this.tbBonoConsulta = new System.Windows.Forms.TextBox();
            this.gbAcciones.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBaja
            // 
            this.btnBaja.Enabled = false;
            this.btnBaja.TabIndex = 7;
            // 
            // btnModificacion
            // 
            this.btnModificacion.Enabled = false;
            this.btnModificacion.TabIndex = 6;
            // 
            // btnAlta
            // 
            this.btnAlta.Enabled = false;
            this.btnAlta.TabIndex = 5;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.tbBonoConsulta);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.label3);
            this.gbFiltros.Controls.Add(this.tbBonoFarmacia);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.tbNombrePlan);
            this.gbFiltros.Controls.SetChildIndex(this.tbNombrePlan, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label2, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbBonoFarmacia, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label3, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbBonoConsulta, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre del plan";
            // 
            // tbNombrePlan
            // 
            this.tbNombrePlan.Location = new System.Drawing.Point(109, 24);
            this.tbNombrePlan.Name = "tbNombrePlan";
            this.tbNombrePlan.Size = new System.Drawing.Size(536, 20);
            this.tbNombrePlan.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Precio bono farmacia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Precio bono consulta";
            // 
            // tbBonoFarmacia
            // 
            this.tbBonoFarmacia.Location = new System.Drawing.Point(222, 50);
            this.tbBonoFarmacia.Name = "tbBonoFarmacia";
            this.tbBonoFarmacia.Size = new System.Drawing.Size(100, 20);
            this.tbBonoFarmacia.TabIndex = 1;
            this.tbBonoFarmacia.Text = "0";
            // 
            // tbBonoConsulta
            // 
            this.tbBonoConsulta.Location = new System.Drawing.Point(223, 77);
            this.tbBonoConsulta.Name = "tbBonoConsulta";
            this.tbBonoConsulta.Size = new System.Drawing.Size(100, 20);
            this.tbBonoConsulta.TabIndex = 2;
            this.tbBonoConsulta.Text = "0";
            // 
            // FrmPlanListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 440);
            this.Name = "FrmPlanListado";
            this.Text = "Clinica FRBA - Planes - Listado";
            this.Load += new System.EventHandler(this.FrmPlanListado_Load);
            this.gbAcciones.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNombrePlan;
        private System.Windows.Forms.TextBox tbBonoConsulta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBonoFarmacia;
        private System.Windows.Forms.Label label2;
    }
}