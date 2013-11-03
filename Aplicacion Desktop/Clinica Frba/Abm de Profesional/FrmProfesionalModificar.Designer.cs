namespace Clinica_Frba.Profesionales
{
    partial class FrmProfesionalModificar
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
            this.tbMatriculaProfesional = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbSexo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.gbDatosDeContacto = new System.Windows.Forms.GroupBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.tbNroDocumento = new System.Windows.Forms.TextBox();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.gbDatosMedicos = new System.Windows.Forms.GroupBox();
            this.lstEspecialidades = new System.Windows.Forms.ListBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbDatosDeContacto.SuspendLayout();
            this.gbDatosPersonales.SuspendLayout();
            this.gbDatosMedicos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMatriculaProfesional
            // 
            this.tbMatriculaProfesional.Location = new System.Drawing.Point(415, 129);
            this.tbMatriculaProfesional.Name = "tbMatriculaProfesional";
            this.tbMatriculaProfesional.Size = new System.Drawing.Size(270, 20);
            this.tbMatriculaProfesional.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(311, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Matricula profesional";
            // 
            // cbSexo
            // 
            this.cbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSexo.FormattingEnabled = true;
            this.cbSexo.Location = new System.Drawing.Point(348, 166);
            this.cbSexo.Name = "cbSexo";
            this.cbSexo.Size = new System.Drawing.Size(121, 21);
            this.cbSexo.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(311, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Sexo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(176, 384);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dpFechaNacimiento
            // 
            this.dpFechaNacimiento.Location = new System.Drawing.Point(90, 167);
            this.dpFechaNacimiento.Name = "dpFechaNacimiento";
            this.dpFechaNacimiento.Size = new System.Drawing.Size(206, 20);
            this.dpFechaNacimiento.TabIndex = 12;
            // 
            // gbDatosDeContacto
            // 
            this.gbDatosDeContacto.Controls.Add(this.tbMail);
            this.gbDatosDeContacto.Controls.Add(this.tbTelefono);
            this.gbDatosDeContacto.Controls.Add(this.tbDireccion);
            this.gbDatosDeContacto.Controls.Add(this.label5);
            this.gbDatosDeContacto.Controls.Add(this.label6);
            this.gbDatosDeContacto.Controls.Add(this.label7);
            this.gbDatosDeContacto.Location = new System.Drawing.Point(305, 19);
            this.gbDatosDeContacto.Name = "gbDatosDeContacto";
            this.gbDatosDeContacto.Size = new System.Drawing.Size(389, 101);
            this.gbDatosDeContacto.TabIndex = 25;
            this.gbDatosDeContacto.TabStop = false;
            this.gbDatosDeContacto.Text = "Datos de contacto";
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(110, 75);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(270, 20);
            this.tbMail.TabIndex = 9;
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(110, 49);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(162, 20);
            this.tbTelefono.TabIndex = 8;
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(110, 22);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(270, 20);
            this.tbDireccion.TabIndex = 7;
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
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.tbMatriculaProfesional);
            this.gbDatosPersonales.Controls.Add(this.label10);
            this.gbDatosPersonales.Controls.Add(this.cbSexo);
            this.gbDatosPersonales.Controls.Add(this.label9);
            this.gbDatosPersonales.Controls.Add(this.dpFechaNacimiento);
            this.gbDatosPersonales.Controls.Add(this.gbDatosDeContacto);
            this.gbDatosPersonales.Controls.Add(this.cbTipoDocumento);
            this.gbDatosPersonales.Controls.Add(this.tbNroDocumento);
            this.gbDatosPersonales.Controls.Add(this.tbApellido);
            this.gbDatosPersonales.Controls.Add(this.tbNombre);
            this.gbDatosPersonales.Controls.Add(this.label3);
            this.gbDatosPersonales.Controls.Add(this.label1);
            this.gbDatosPersonales.Controls.Add(this.label2);
            this.gbDatosPersonales.Controls.Add(this.label4);
            this.gbDatosPersonales.Controls.Add(this.label8);
            this.gbDatosPersonales.Location = new System.Drawing.Point(12, 12);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(700, 201);
            this.gbDatosPersonales.TabIndex = 31;
            this.gbDatosPersonales.TabStop = false;
            this.gbDatosPersonales.Text = "Datos personales";
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
            // tbNroDocumento
            // 
            this.tbNroDocumento.Location = new System.Drawing.Point(78, 129);
            this.tbNroDocumento.Name = "tbNroDocumento";
            this.tbNroDocumento.Size = new System.Drawing.Size(100, 20);
            this.tbNroDocumento.TabIndex = 10;
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
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(48, 47);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(48, 77);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 2;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            // 
            // gbDatosMedicos
            // 
            this.gbDatosMedicos.Controls.Add(this.btnQuitar);
            this.gbDatosMedicos.Controls.Add(this.btnAgregar);
            this.gbDatosMedicos.Controls.Add(this.lstEspecialidades);
            this.gbDatosMedicos.Location = new System.Drawing.Point(12, 220);
            this.gbDatosMedicos.Name = "gbDatosMedicos";
            this.gbDatosMedicos.Size = new System.Drawing.Size(700, 158);
            this.gbDatosMedicos.TabIndex = 35;
            this.gbDatosMedicos.TabStop = false;
            this.gbDatosMedicos.Text = "Especialidades médicas";
            // 
            // lstEspecialidades
            // 
            this.lstEspecialidades.FormattingEnabled = true;
            this.lstEspecialidades.Location = new System.Drawing.Point(129, 19);
            this.lstEspecialidades.Name = "lstEspecialidades";
            this.lstEspecialidades.Size = new System.Drawing.Size(556, 121);
            this.lstEspecialidades.TabIndex = 0;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(95, 384);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 33;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(14, 384);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 32;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmProfesionalModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 419);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbDatosPersonales);
            this.Controls.Add(this.gbDatosMedicos);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "FrmProfesionalModificar";
            this.Text = "Clinica FRBA - Profesionales - Modificar";
            this.Load += new System.EventHandler(this.FrmProfesionalModificar_Load);
            this.gbDatosDeContacto.ResumeLayout(false);
            this.gbDatosDeContacto.PerformLayout();
            this.gbDatosPersonales.ResumeLayout(false);
            this.gbDatosPersonales.PerformLayout();
            this.gbDatosMedicos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbMatriculaProfesional;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker dpFechaNacimiento;
        private System.Windows.Forms.GroupBox gbDatosDeContacto;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbDatosPersonales;
        private System.Windows.Forms.ComboBox cbTipoDocumento;
        private System.Windows.Forms.TextBox tbNroDocumento;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.GroupBox gbDatosMedicos;
        private System.Windows.Forms.ListBox lstEspecialidades;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
    }
}