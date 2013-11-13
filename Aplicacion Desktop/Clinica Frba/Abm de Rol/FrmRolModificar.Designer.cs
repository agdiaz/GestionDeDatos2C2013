namespace Clinica_Frba.Roles
{
    partial class FrmRolModificar
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbFuncionalidades = new System.Windows.Forms.GroupBox();
            this.clsFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.gbDetalles = new System.Windows.Forms.GroupBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFuncionalidades.SuspendLayout();
            this.gbDetalles.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(104, 398);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(185, 398);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(23, 398);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gbFuncionalidades
            // 
            this.gbFuncionalidades.Controls.Add(this.clsFuncionalidades);
            this.gbFuncionalidades.Location = new System.Drawing.Point(13, 97);
            this.gbFuncionalidades.Name = "gbFuncionalidades";
            this.gbFuncionalidades.Size = new System.Drawing.Size(259, 294);
            this.gbFuncionalidades.TabIndex = 6;
            this.gbFuncionalidades.TabStop = false;
            this.gbFuncionalidades.Text = "Funcionalidades asociadas";
            // 
            // clsFuncionalidades
            // 
            this.clsFuncionalidades.FormattingEnabled = true;
            this.clsFuncionalidades.Location = new System.Drawing.Point(10, 20);
            this.clsFuncionalidades.Name = "clsFuncionalidades";
            this.clsFuncionalidades.Size = new System.Drawing.Size(243, 259);
            this.clsFuncionalidades.TabIndex = 3;
            // 
            // gbDetalles
            // 
            this.gbDetalles.Controls.Add(this.chkActivo);
            this.gbDetalles.Controls.Add(this.tbNombre);
            this.gbDetalles.Controls.Add(this.label1);
            this.gbDetalles.Location = new System.Drawing.Point(13, 11);
            this.gbDetalles.Name = "gbDetalles";
            this.gbDetalles.Size = new System.Drawing.Size(259, 79);
            this.gbDetalles.TabIndex = 5;
            this.gbDetalles.TabStop = false;
            this.gbDetalles.Text = "Detalles del rol";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(60, 43);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 2;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(60, 17);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(193, 20);
            this.tbNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // FrmRolModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 432);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbFuncionalidades);
            this.Controls.Add(this.gbDetalles);
            this.Name = "FrmRolModificar";
            this.Text = "Clinica FRBA - Roles de usuario - Modificar";
            this.Load += new System.EventHandler(this.FrmRolModificar_Load);
            this.gbFuncionalidades.ResumeLayout(false);
            this.gbDetalles.ResumeLayout(false);
            this.gbDetalles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gbFuncionalidades;
        private System.Windows.Forms.CheckedListBox clsFuncionalidades;
        private System.Windows.Forms.GroupBox gbDetalles;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label1;
    }
}