﻿namespace Clinica_Frba.Afiliados
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
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbDatosFamiliares = new System.Windows.Forms.GroupBox();
            this.ndCantHijos = new System.Windows.Forms.NumericUpDown();
            this.gbEstadoCivil = new System.Windows.Forms.GroupBox();
            this.rbEstadoCivilDivorciado = new System.Windows.Forms.RadioButton();
            this.rbEstadoCivilConcubinato = new System.Windows.Forms.RadioButton();
            this.rbEstadoCivilViudo = new System.Windows.Forms.RadioButton();
            this.rbEstadoCivilCasado = new System.Windows.Forms.RadioButton();
            this.rbEstadoCivilSoltero = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.dpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.tbNroDocumento = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbDatosDeContacto = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.cbPlanMedico = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNroAfiliado = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gbDatosFamiliares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndCantHijos)).BeginInit();
            this.gbEstadoCivil.SuspendLayout();
            this.gbDatosDeContacto.SuspendLayout();
            this.gbDatosPersonales.SuspendLayout();
            this.SuspendLayout();
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
            this.btnCancelar.Location = new System.Drawing.Point(183, 369);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // gbDatosFamiliares
            // 
            this.gbDatosFamiliares.Controls.Add(this.ndCantHijos);
            this.gbDatosFamiliares.Controls.Add(this.gbEstadoCivil);
            this.gbDatosFamiliares.Controls.Add(this.label9);
            this.gbDatosFamiliares.Location = new System.Drawing.Point(429, 62);
            this.gbDatosFamiliares.Name = "gbDatosFamiliares";
            this.gbDatosFamiliares.Size = new System.Drawing.Size(200, 194);
            this.gbDatosFamiliares.TabIndex = 26;
            this.gbDatosFamiliares.TabStop = false;
            this.gbDatosFamiliares.Text = "Datos familiares";
            // 
            // ndCantHijos
            // 
            this.ndCantHijos.Location = new System.Drawing.Point(68, 167);
            this.ndCantHijos.Name = "ndCantHijos";
            this.ndCantHijos.Size = new System.Drawing.Size(45, 20);
            this.ndCantHijos.TabIndex = 10;
            // 
            // gbEstadoCivil
            // 
            this.gbEstadoCivil.Controls.Add(this.rbEstadoCivilDivorciado);
            this.gbEstadoCivil.Controls.Add(this.rbEstadoCivilConcubinato);
            this.gbEstadoCivil.Controls.Add(this.rbEstadoCivilViudo);
            this.gbEstadoCivil.Controls.Add(this.rbEstadoCivilCasado);
            this.gbEstadoCivil.Controls.Add(this.rbEstadoCivilSoltero);
            this.gbEstadoCivil.Location = new System.Drawing.Point(6, 24);
            this.gbEstadoCivil.Name = "gbEstadoCivil";
            this.gbEstadoCivil.Size = new System.Drawing.Size(188, 137);
            this.gbEstadoCivil.TabIndex = 9;
            this.gbEstadoCivil.TabStop = false;
            this.gbEstadoCivil.Text = "Estado civil";
            // 
            // rbEstadoCivilDivorciado
            // 
            this.rbEstadoCivilDivorciado.AutoSize = true;
            this.rbEstadoCivilDivorciado.Location = new System.Drawing.Point(3, 113);
            this.rbEstadoCivilDivorciado.Name = "rbEstadoCivilDivorciado";
            this.rbEstadoCivilDivorciado.Size = new System.Drawing.Size(87, 17);
            this.rbEstadoCivilDivorciado.TabIndex = 4;
            this.rbEstadoCivilDivorciado.TabStop = true;
            this.rbEstadoCivilDivorciado.Text = "Divorciado/a";
            this.rbEstadoCivilDivorciado.UseVisualStyleBackColor = true;
            // 
            // rbEstadoCivilConcubinato
            // 
            this.rbEstadoCivilConcubinato.AutoSize = true;
            this.rbEstadoCivilConcubinato.Location = new System.Drawing.Point(3, 90);
            this.rbEstadoCivilConcubinato.Name = "rbEstadoCivilConcubinato";
            this.rbEstadoCivilConcubinato.Size = new System.Drawing.Size(85, 17);
            this.rbEstadoCivilConcubinato.TabIndex = 3;
            this.rbEstadoCivilConcubinato.TabStop = true;
            this.rbEstadoCivilConcubinato.Text = "Concubinato";
            this.rbEstadoCivilConcubinato.UseVisualStyleBackColor = true;
            // 
            // rbEstadoCivilViudo
            // 
            this.rbEstadoCivilViudo.AutoSize = true;
            this.rbEstadoCivilViudo.Location = new System.Drawing.Point(3, 67);
            this.rbEstadoCivilViudo.Name = "rbEstadoCivilViudo";
            this.rbEstadoCivilViudo.Size = new System.Drawing.Size(63, 17);
            this.rbEstadoCivilViudo.TabIndex = 2;
            this.rbEstadoCivilViudo.TabStop = true;
            this.rbEstadoCivilViudo.Text = "Viudo/a";
            this.rbEstadoCivilViudo.UseVisualStyleBackColor = true;
            // 
            // rbEstadoCivilCasado
            // 
            this.rbEstadoCivilCasado.AutoSize = true;
            this.rbEstadoCivilCasado.Location = new System.Drawing.Point(3, 44);
            this.rbEstadoCivilCasado.Name = "rbEstadoCivilCasado";
            this.rbEstadoCivilCasado.Size = new System.Drawing.Size(72, 17);
            this.rbEstadoCivilCasado.TabIndex = 1;
            this.rbEstadoCivilCasado.TabStop = true;
            this.rbEstadoCivilCasado.Text = "Casado/a";
            this.rbEstadoCivilCasado.UseVisualStyleBackColor = true;
            // 
            // rbEstadoCivilSoltero
            // 
            this.rbEstadoCivilSoltero.AutoSize = true;
            this.rbEstadoCivilSoltero.Location = new System.Drawing.Point(3, 20);
            this.rbEstadoCivilSoltero.Name = "rbEstadoCivilSoltero";
            this.rbEstadoCivilSoltero.Size = new System.Drawing.Size(69, 17);
            this.rbEstadoCivilSoltero.TabIndex = 0;
            this.rbEstadoCivilSoltero.TabStop = true;
            this.rbEstadoCivilSoltero.Text = "Soltero/a";
            this.rbEstadoCivilSoltero.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Cant. hijos";
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(110, 49);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(162, 20);
            this.tbTelefono.TabIndex = 8;
            // 
            // dpFechaNacimiento
            // 
            this.dpFechaNacimiento.Location = new System.Drawing.Point(90, 167);
            this.dpFechaNacimiento.Name = "dpFechaNacimiento";
            this.dpFechaNacimiento.Size = new System.Drawing.Size(206, 20);
            this.dpFechaNacimiento.TabIndex = 12;
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(110, 75);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(270, 20);
            this.tbMail.TabIndex = 9;
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDocumento.FormattingEnabled = true;
            this.cbTipoDocumento.Items.AddRange(new object[] {
            "DNI",
            "LE",
            "CUIT"});
            this.cbTipoDocumento.Location = new System.Drawing.Point(78, 91);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Size = new System.Drawing.Size(121, 21);
            this.cbTipoDocumento.TabIndex = 11;
            // 
            // tbNroDocumento
            // 
            this.tbNroDocumento.Location = new System.Drawing.Point(78, 129);
            this.tbNroDocumento.Name = "tbNroDocumento";
            this.tbNroDocumento.Size = new System.Drawing.Size(100, 20);
            this.tbNroDocumento.TabIndex = 10;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(102, 369);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(21, 369);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // gbDatosDeContacto
            // 
            this.gbDatosDeContacto.Controls.Add(this.tbMail);
            this.gbDatosDeContacto.Controls.Add(this.tbTelefono);
            this.gbDatosDeContacto.Controls.Add(this.tbDireccion);
            this.gbDatosDeContacto.Controls.Add(this.label5);
            this.gbDatosDeContacto.Controls.Add(this.label6);
            this.gbDatosDeContacto.Controls.Add(this.label7);
            this.gbDatosDeContacto.Location = new System.Drawing.Point(21, 262);
            this.gbDatosDeContacto.Name = "gbDatosDeContacto";
            this.gbDatosDeContacto.Size = new System.Drawing.Size(608, 101);
            this.gbDatosDeContacto.TabIndex = 25;
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
            // cbPlanMedico
            // 
            this.cbPlanMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlanMedico.FormattingEnabled = true;
            this.cbPlanMedico.Items.AddRange(new object[] {
            "210",
            "310",
            "410"});
            this.cbPlanMedico.Location = new System.Drawing.Point(323, 21);
            this.cbPlanMedico.Name = "cbPlanMedico";
            this.cbPlanMedico.Size = new System.Drawing.Size(279, 21);
            this.cbPlanMedico.TabIndex = 30;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // gbDatosPersonales
            // 
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
            this.gbDatosPersonales.Location = new System.Drawing.Point(21, 62);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(393, 194);
            this.gbDatosPersonales.TabIndex = 24;
            this.gbDatosPersonales.TabStop = false;
            this.gbDatosPersonales.Text = "Datos personales";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Fecha de Nac.";
            // 
            // tbNroAfiliado
            // 
            this.tbNroAfiliado.Enabled = false;
            this.tbNroAfiliado.Location = new System.Drawing.Point(99, 22);
            this.tbNroAfiliado.Name = "tbNroAfiliado";
            this.tbNroAfiliado.Size = new System.Drawing.Size(147, 20);
            this.tbNroAfiliado.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Nro de afiliado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(252, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Plan médico";
            // 
            // FrmAfiliadoModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 405);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbDatosFamiliares);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbDatosDeContacto);
            this.Controls.Add(this.cbPlanMedico);
            this.Controls.Add(this.gbDatosPersonales);
            this.Controls.Add(this.tbNroAfiliado);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Name = "FrmAfiliadoModificar";
            this.Text = "Clinica FRBA - Afiliados - Modificar";
            this.Load += new System.EventHandler(this.FrmAfiliadoModificar_Load);
            this.gbDatosFamiliares.ResumeLayout(false);
            this.gbDatosFamiliares.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndCantHijos)).EndInit();
            this.gbEstadoCivil.ResumeLayout(false);
            this.gbEstadoCivil.PerformLayout();
            this.gbDatosDeContacto.ResumeLayout(false);
            this.gbDatosDeContacto.PerformLayout();
            this.gbDatosPersonales.ResumeLayout(false);
            this.gbDatosPersonales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gbDatosFamiliares;
        private System.Windows.Forms.NumericUpDown ndCantHijos;
        private System.Windows.Forms.GroupBox gbEstadoCivil;
        private System.Windows.Forms.RadioButton rbEstadoCivilDivorciado;
        private System.Windows.Forms.RadioButton rbEstadoCivilConcubinato;
        private System.Windows.Forms.RadioButton rbEstadoCivilViudo;
        private System.Windows.Forms.RadioButton rbEstadoCivilCasado;
        private System.Windows.Forms.RadioButton rbEstadoCivilSoltero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.DateTimePicker dpFechaNacimiento;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.ComboBox cbTipoDocumento;
        private System.Windows.Forms.TextBox tbNroDocumento;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbDatosDeContacto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.ComboBox cbPlanMedico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDatosPersonales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNroAfiliado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}