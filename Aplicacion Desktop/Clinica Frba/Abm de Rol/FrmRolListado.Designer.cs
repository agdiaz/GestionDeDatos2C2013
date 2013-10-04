namespace Clinica_Frba.Roles
{
    partial class FrmRolListado
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
            this.lblRol = new System.Windows.Forms.Label();
            this.tbRol = new System.Windows.Forms.TextBox();
            this.lblFuncionalidad = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbAcciones.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.lblFuncionalidad);
            this.gbFiltros.Controls.Add(this.tbRol);
            this.gbFiltros.Controls.Add(this.textBox1);
            this.gbFiltros.Controls.Add(this.lblRol);
            this.gbFiltros.Controls.SetChildIndex(this.lblRol, 0);
            this.gbFiltros.Controls.SetChildIndex(this.textBox1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbRol, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblFuncionalidad, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(75, 19);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(26, 13);
            this.lblRol.TabIndex = 2;
            this.lblRol.Text = "Rol:";
            // 
            // tbRol
            // 
            this.tbRol.Location = new System.Drawing.Point(107, 16);
            this.tbRol.Name = "tbRol";
            this.tbRol.Size = new System.Drawing.Size(181, 20);
            this.tbRol.TabIndex = 3;
            // 
            // lblFuncionalidad
            // 
            this.lblFuncionalidad.AutoSize = true;
            this.lblFuncionalidad.Location = new System.Drawing.Point(27, 49);
            this.lblFuncionalidad.Name = "lblFuncionalidad";
            this.lblFuncionalidad.Size = new System.Drawing.Size(76, 13);
            this.lblFuncionalidad.TabIndex = 4;
            this.lblFuncionalidad.Text = "Funcionalidad:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 20);
            this.textBox1.TabIndex = 5;
            // 
            // FrmRolListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 450);
            this.Name = "FrmRolListado";
            this.Text = "Clinica FRBA - Roles de usuario - Listado";
            this.gbAcciones.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbRol;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblFuncionalidad;
        private System.Windows.Forms.TextBox textBox1;

    }
}