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
            this.cbFuncionalidad = new System.Windows.Forms.ComboBox();
            this.chFuncionalidad = new System.Windows.Forms.CheckBox();
            this.gbAcciones.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBaja
            // 
            this.btnBaja.TabIndex = 7;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnModificacion
            // 
            this.btnModificacion.TabIndex = 6;
            // 
            // btnAlta
            // 
            this.btnAlta.TabIndex = 5;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.tbRol);
            this.gbFiltros.Controls.Add(this.cbFuncionalidad);
            this.gbFiltros.Controls.Add(this.lblRol);
            this.gbFiltros.Controls.Add(this.chFuncionalidad);
            this.gbFiltros.Controls.SetChildIndex(this.chFuncionalidad, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblRol, 0);
            this.gbFiltros.Controls.SetChildIndex(this.cbFuncionalidad, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbRol, 0);
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
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(57, 19);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(44, 13);
            this.lblRol.TabIndex = 2;
            this.lblRol.Text = "Nombre";
            // 
            // tbRol
            // 
            this.tbRol.Location = new System.Drawing.Point(107, 16);
            this.tbRol.Name = "tbRol";
            this.tbRol.Size = new System.Drawing.Size(181, 20);
            this.tbRol.TabIndex = 1;
            // 
            // cbFuncionalidad
            // 
            this.cbFuncionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuncionalidad.FormattingEnabled = true;
            this.cbFuncionalidad.Location = new System.Drawing.Point(107, 49);
            this.cbFuncionalidad.Name = "cbFuncionalidad";
            this.cbFuncionalidad.Size = new System.Drawing.Size(181, 21);
            this.cbFuncionalidad.TabIndex = 2;
            // 
            // chFuncionalidad
            // 
            this.chFuncionalidad.AutoSize = true;
            this.chFuncionalidad.Location = new System.Drawing.Point(9, 51);
            this.chFuncionalidad.Name = "chFuncionalidad";
            this.chFuncionalidad.Size = new System.Drawing.Size(92, 17);
            this.chFuncionalidad.TabIndex = 5;
            this.chFuncionalidad.Text = "Funcionalidad";
            this.chFuncionalidad.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.ComboBox cbFuncionalidad;
        private System.Windows.Forms.CheckBox chFuncionalidad;

    }
}