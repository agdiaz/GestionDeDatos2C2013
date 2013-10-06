namespace Clinica_Frba.Especialidades
{
    partial class FrmEspecialidadListado
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbNombreEspecialidad = new System.Windows.Forms.TextBox();
            this.cbTipoEspecialidad = new System.Windows.Forms.ComboBox();
            this.gbAcciones.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.cbTipoEspecialidad);
            this.gbFiltros.Controls.Add(this.tbNombreEspecialidad);
            this.gbFiltros.Controls.SetChildIndex(this.tbNombreEspecialidad, 0);
            this.gbFiltros.Controls.SetChildIndex(this.cbTipoEspecialidad, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label2, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de especialidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo de especialidad";
            // 
            // tbNombreEspecialidad
            // 
            this.tbNombreEspecialidad.Location = new System.Drawing.Point(134, 17);
            this.tbNombreEspecialidad.Name = "tbNombreEspecialidad";
            this.tbNombreEspecialidad.Size = new System.Drawing.Size(511, 20);
            this.tbNombreEspecialidad.TabIndex = 4;
            // 
            // cbTipoEspecialidad
            // 
            this.cbTipoEspecialidad.FormattingEnabled = true;
            this.cbTipoEspecialidad.Location = new System.Drawing.Point(134, 43);
            this.cbTipoEspecialidad.Name = "cbTipoEspecialidad";
            this.cbTipoEspecialidad.Size = new System.Drawing.Size(511, 21);
            this.cbTipoEspecialidad.TabIndex = 5;
            // 
            // FrmEspecialidadListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 441);
            this.Name = "FrmEspecialidadListado";
            this.Text = "Clinica FRBA - Especialidades médicas - Listado";
            this.gbAcciones.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombreEspecialidad;
        private System.Windows.Forms.ComboBox cbTipoEspecialidad;
    }
}