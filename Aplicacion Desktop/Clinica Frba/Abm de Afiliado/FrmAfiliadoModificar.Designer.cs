namespace Clinica_Frba.Afiliados
{
    partial class FrmAfiliadoModificar
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
            this.tbMail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.cbSexo = new System.Windows.Forms.ComboBox();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.tbPlanMedico = new System.Windows.Forms.TextBox();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbDatosFamiliares = new System.Windows.Forms.GroupBox();
            this.cbEstadoCivil = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ndCantHijos = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.dpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.gbDatosDeContacto = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarPlan = new System.Windows.Forms.Button();
            this.tbNroDocumento = new System.Windows.Forms.TextBox();
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbNroAfiliado = new System.Windows.Forms.TextBox();
            this.gbDatosFamiliares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndCantHijos)).BeginInit();
            this.gbDatosDeContacto.SuspendLayout();
            this.gbDatosPersonales.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(110, 75);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(270, 20);
            this.tbMail.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(206, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Sexo";
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDocumento.FormattingEnabled = true;
            this.cbTipoDocumento.Location = new System.Drawing.Point(78, 91);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Size = new System.Drawing.Size(121, 21);
            this.cbTipoDocumento.TabIndex = 11;
            // 
            // cbSexo
            // 
            this.cbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSexo.FormattingEnabled = true;
            this.cbSexo.Location = new System.Drawing.Point(244, 90);
            this.cbSexo.Name = "cbSexo";
            this.cbSexo.Size = new System.Drawing.Size(121, 21);
            this.cbSexo.TabIndex = 14;
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(110, 49);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(162, 20);
            this.tbTelefono.TabIndex = 8;
            // 
            // tbPlanMedico
            // 
            this.tbPlanMedico.Location = new System.Drawing.Point(339, 18);
            this.tbPlanMedico.Name = "tbPlanMedico";
            this.tbPlanMedico.ReadOnly = true;
            this.tbPlanMedico.Size = new System.Drawing.Size(210, 20);
            this.tbPlanMedico.TabIndex = 31;
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(110, 22);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(492, 20);
            this.tbDireccion.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(183, 365);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(21, 365);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 28;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbDatosFamiliares
            // 
            this.gbDatosFamiliares.Controls.Add(this.cbEstadoCivil);
            this.gbDatosFamiliares.Controls.Add(this.label12);
            this.gbDatosFamiliares.Controls.Add(this.ndCantHijos);
            this.gbDatosFamiliares.Controls.Add(this.label9);
            this.gbDatosFamiliares.Location = new System.Drawing.Point(429, 58);
            this.gbDatosFamiliares.Name = "gbDatosFamiliares";
            this.gbDatosFamiliares.Size = new System.Drawing.Size(200, 194);
            this.gbDatosFamiliares.TabIndex = 27;
            this.gbDatosFamiliares.TabStop = false;
            this.gbDatosFamiliares.Text = "Datos familiares";
            // 
            // cbEstadoCivil
            // 
            this.cbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoCivil.FormattingEnabled = true;
            this.cbEstadoCivil.Location = new System.Drawing.Point(12, 46);
            this.cbEstadoCivil.Name = "cbEstadoCivil";
            this.cbEstadoCivil.Size = new System.Drawing.Size(182, 21);
            this.cbEstadoCivil.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Estado civil";
            // 
            // ndCantHijos
            // 
            this.ndCantHijos.Location = new System.Drawing.Point(68, 89);
            this.ndCantHijos.Name = "ndCantHijos";
            this.ndCantHijos.Size = new System.Drawing.Size(126, 20);
            this.ndCantHijos.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Cant. hijos";
            // 
            // dpFechaNacimiento
            // 
            this.dpFechaNacimiento.Location = new System.Drawing.Point(90, 167);
            this.dpFechaNacimiento.Name = "dpFechaNacimiento";
            this.dpFechaNacimiento.Size = new System.Drawing.Size(206, 20);
            this.dpFechaNacimiento.TabIndex = 12;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(102, 365);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 29;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // gbDatosDeContacto
            // 
            this.gbDatosDeContacto.Controls.Add(this.tbMail);
            this.gbDatosDeContacto.Controls.Add(this.tbTelefono);
            this.gbDatosDeContacto.Controls.Add(this.tbDireccion);
            this.gbDatosDeContacto.Controls.Add(this.label5);
            this.gbDatosDeContacto.Controls.Add(this.label6);
            this.gbDatosDeContacto.Controls.Add(this.label7);
            this.gbDatosDeContacto.Location = new System.Drawing.Point(21, 258);
            this.gbDatosDeContacto.Name = "gbDatosDeContacto";
            this.gbDatosDeContacto.Size = new System.Drawing.Size(608, 101);
            this.gbDatosDeContacto.TabIndex = 26;
            this.gbDatosDeContacto.TabStop = false;
            this.gbDatosDeContacto.Text = "Datos de contacto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dirección completa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Telefono";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo Doc.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nro. Doc.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // btnBuscarPlan
            // 
            this.btnBuscarPlan.Location = new System.Drawing.Point(555, 16);
            this.btnBuscarPlan.Name = "btnBuscarPlan";
            this.btnBuscarPlan.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarPlan.TabIndex = 32;
            this.btnBuscarPlan.Text = "Buscar";
            this.btnBuscarPlan.UseVisualStyleBackColor = true;
            this.btnBuscarPlan.Click += new System.EventHandler(this.btnBuscarPlan_Click);
            // 
            // tbNroDocumento
            // 
            this.tbNroDocumento.Location = new System.Drawing.Point(78, 129);
            this.tbNroDocumento.Name = "tbNroDocumento";
            this.tbNroDocumento.Size = new System.Drawing.Size(194, 20);
            this.tbNroDocumento.TabIndex = 10;
            // 
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.cbSexo);
            this.gbDatosPersonales.Controls.Add(this.label13);
            this.gbDatosPersonales.Controls.Add(this.dpFechaNacimiento);
            this.gbDatosPersonales.Controls.Add(this.cbTipoDocumento);
            this.gbDatosPersonales.Controls.Add(this.tbNroDocumento);
            this.gbDatosPersonales.Controls.Add(this.tbApellido);
            this.gbDatosPersonales.Controls.Add(this.tbNombre);
            this.gbDatosPersonales.Controls.Add(this.label3);
            this.gbDatosPersonales.Controls.Add(this.label1);
            this.gbDatosPersonales.Controls.Add(this.label2);
            this.gbDatosPersonales.Controls.Add(this.label4);
            this.gbDatosPersonales.Controls.Add(this.label8);
            this.gbDatosPersonales.Location = new System.Drawing.Point(21, 58);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(393, 194);
            this.gbDatosPersonales.TabIndex = 25;
            this.gbDatosPersonales.TabStop = false;
            this.gbDatosPersonales.Text = "Datos personales";
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(78, 60);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(218, 20);
            this.tbApellido.TabIndex = 9;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(78, 24);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(218, 20);
            this.tbNombre.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Fecha de Nac.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Nro de afiliado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(252, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Plan médico";
            // 
            // tbNroAfiliado
            // 
            this.tbNroAfiliado.Enabled = false;
            this.tbNroAfiliado.Location = new System.Drawing.Point(99, 18);
            this.tbNroAfiliado.Name = "tbNroAfiliado";
            this.tbNroAfiliado.ReadOnly = true;
            this.tbNroAfiliado.Size = new System.Drawing.Size(147, 20);
            this.tbNroAfiliado.TabIndex = 24;
            // 
            // FrmAfiliadoModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 405);
            this.Controls.Add(this.tbPlanMedico);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbDatosFamiliares);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.gbDatosDeContacto);
            this.Controls.Add(this.btnBuscarPlan);
            this.Controls.Add(this.gbDatosPersonales);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbNroAfiliado);
            this.Name = "FrmAfiliadoModificar";
            this.Text = "Clinica FRBA - Afiliados - Modificar";
            this.Load += new System.EventHandler(this.FrmAfiliadoModificar_Load);
            this.gbDatosFamiliares.ResumeLayout(false);
            this.gbDatosFamiliares.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndCantHijos)).EndInit();
            this.gbDatosDeContacto.ResumeLayout(false);
            this.gbDatosDeContacto.PerformLayout();
            this.gbDatosPersonales.ResumeLayout(false);
            this.gbDatosPersonales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbTipoDocumento;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.TextBox tbPlanMedico;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbDatosFamiliares;
        private System.Windows.Forms.ComboBox cbEstadoCivil;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown ndCantHijos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dpFechaNacimiento;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox gbDatosDeContacto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarPlan;
        private System.Windows.Forms.TextBox tbNroDocumento;
        private System.Windows.Forms.GroupBox gbDatosPersonales;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbNroAfiliado;

    }
}