namespace Clinica_Frba.Afiliados
{
    partial class FrmAfiliadoListado
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
            this.tbNroPrincipal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDocumento = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.cbTipoDoc = new System.Windows.Forms.ComboBox();
            this.tbPlanMedico = new System.Windows.Forms.TextBox();
            this.btnBuscarPlanMedico = new System.Windows.Forms.Button();
            this.tbNroSecundario = new System.Windows.Forms.TextBox();
            this.chTipoDoc = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.chFechaNac = new System.Windows.Forms.CheckBox();
            this.chSexo = new System.Windows.Forms.CheckBox();
            this.chEstadoCivil = new System.Windows.Forms.CheckBox();
            this.cbSexo = new System.Windows.Forms.ComboBox();
            this.cbEstadoCivil = new System.Windows.Forms.ComboBox();
            this.gbAcciones.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAcciones
            // 
            this.gbAcciones.Location = new System.Drawing.Point(11, 483);
            // 
            // btnBaja
            // 
            this.btnBaja.TabIndex = 22;
            // 
            // btnModificacion
            // 
            this.btnModificacion.TabIndex = 21;
            // 
            // btnAlta
            // 
            this.btnAlta.TabIndex = 20;
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Location = new System.Drawing.Point(11, 224);
            this.gbBusqueda.Size = new System.Drawing.Size(652, 253);
            this.gbBusqueda.Enter += new System.EventHandler(this.gbBusqueda_Enter);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.tbDireccion);
            this.gbFiltros.Controls.Add(this.tbNroSecundario);
            this.gbFiltros.Controls.Add(this.chSexo);
            this.gbFiltros.Controls.Add(this.cbEstadoCivil);
            this.gbFiltros.Controls.Add(this.chFechaNac);
            this.gbFiltros.Controls.Add(this.tbMail);
            this.gbFiltros.Controls.Add(this.cbSexo);
            this.gbFiltros.Controls.Add(this.tbTelefono);
            this.gbFiltros.Controls.Add(this.chEstadoCivil);
            this.gbFiltros.Controls.Add(this.dtpFechaNac);
            this.gbFiltros.Controls.Add(this.chTipoDoc);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.label7);
            this.gbFiltros.Controls.Add(this.tbApellido);
            this.gbFiltros.Controls.Add(this.label6);
            this.gbFiltros.Controls.Add(this.tbNroPrincipal);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.btnBuscarPlanMedico);
            this.gbFiltros.Controls.Add(this.label8);
            this.gbFiltros.Controls.Add(this.label5);
            this.gbFiltros.Controls.Add(this.tbPlanMedico);
            this.gbFiltros.Controls.Add(this.label4);
            this.gbFiltros.Controls.Add(this.tbDocumento);
            this.gbFiltros.Controls.Add(this.cbTipoDoc);
            this.gbFiltros.Controls.Add(this.label3);
            this.gbFiltros.Controls.Add(this.tbNombre);
            this.gbFiltros.Size = new System.Drawing.Size(651, 206);
            this.gbFiltros.Controls.SetChildIndex(this.tbNombre, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label3, 0);
            this.gbFiltros.Controls.SetChildIndex(this.cbTipoDoc, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbDocumento, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label4, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbPlanMedico, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label5, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label8, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnBuscarPlanMedico, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label2, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbNroPrincipal, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label6, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbApellido, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label7, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.chTipoDoc, 0);
            this.gbFiltros.Controls.SetChildIndex(this.dtpFechaNac, 0);
            this.gbFiltros.Controls.SetChildIndex(this.chEstadoCivil, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbTelefono, 0);
            this.gbFiltros.Controls.SetChildIndex(this.cbSexo, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbMail, 0);
            this.gbFiltros.Controls.SetChildIndex(this.chFechaNac, 0);
            this.gbFiltros.Controls.SetChildIndex(this.cbEstadoCivil, 0);
            this.gbFiltros.Controls.SetChildIndex(this.chSexo, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbNroSecundario, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbDireccion, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(6, 177);
            this.btnLimpiar.TabIndex = 18;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(570, 177);
            this.btnFiltrar.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "N° Afiliado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Plan Medico";
            // 
            // tbNroPrincipal
            // 
            this.tbNroPrincipal.Location = new System.Drawing.Point(80, 20);
            this.tbNroPrincipal.Name = "tbNroPrincipal";
            this.tbNroPrincipal.Size = new System.Drawing.Size(108, 20);
            this.tbNroPrincipal.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Apellido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Documento";
            // 
            // tbDocumento
            // 
            this.tbDocumento.Location = new System.Drawing.Point(498, 18);
            this.tbDocumento.Name = "tbDocumento";
            this.tbDocumento.Size = new System.Drawing.Size(100, 20);
            this.tbDocumento.TabIndex = 4;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(79, 49);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(219, 20);
            this.tbNombre.TabIndex = 5;
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(353, 52);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(219, 20);
            this.tbApellido.TabIndex = 6;
            // 
            // cbTipoDoc
            // 
            this.cbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDoc.FormattingEnabled = true;
            this.cbTipoDoc.ItemHeight = 13;
            this.cbTipoDoc.Location = new System.Drawing.Point(363, 17);
            this.cbTipoDoc.Name = "cbTipoDoc";
            this.cbTipoDoc.Size = new System.Drawing.Size(59, 21);
            this.cbTipoDoc.TabIndex = 3;
            this.cbTipoDoc.SelectedIndexChanged += new System.EventHandler(this.cbTipoDoc_SelectedIndexChanged);
            // 
            // tbPlanMedico
            // 
            this.tbPlanMedico.Location = new System.Drawing.Point(80, 144);
            this.tbPlanMedico.Name = "tbPlanMedico";
            this.tbPlanMedico.ReadOnly = true;
            this.tbPlanMedico.Size = new System.Drawing.Size(150, 20);
            this.tbPlanMedico.TabIndex = 12;
            // 
            // btnBuscarPlanMedico
            // 
            this.btnBuscarPlanMedico.Location = new System.Drawing.Point(240, 142);
            this.btnBuscarPlanMedico.Name = "btnBuscarPlanMedico";
            this.btnBuscarPlanMedico.Size = new System.Drawing.Size(58, 23);
            this.btnBuscarPlanMedico.TabIndex = 13;
            this.btnBuscarPlanMedico.Text = "Buscar";
            this.btnBuscarPlanMedico.UseVisualStyleBackColor = true;
            this.btnBuscarPlanMedico.Click += new System.EventHandler(this.btnBuscarPlanMedico_Click);
            // 
            // tbNroSecundario
            // 
            this.tbNroSecundario.Location = new System.Drawing.Point(195, 20);
            this.tbNroSecundario.Name = "tbNroSecundario";
            this.tbNroSecundario.Size = new System.Drawing.Size(48, 20);
            this.tbNroSecundario.TabIndex = 1;
            // 
            // chTipoDoc
            // 
            this.chTipoDoc.AutoSize = true;
            this.chTipoDoc.Location = new System.Drawing.Point(256, 20);
            this.chTipoDoc.Name = "chTipoDoc";
            this.chTipoDoc.Size = new System.Drawing.Size(103, 17);
            this.chTipoDoc.TabIndex = 2;
            this.chTipoDoc.Text = "Tipo documento";
            this.chTipoDoc.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Dirección";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(304, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Teléfono";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Mail";
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(80, 79);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(218, 20);
            this.tbDireccion.TabIndex = 7;
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(353, 78);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(158, 20);
            this.tbTelefono.TabIndex = 8;
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(79, 109);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(219, 20);
            this.tbMail.TabIndex = 9;
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Location = new System.Drawing.Point(433, 109);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaNac.TabIndex = 11;
            this.dtpFechaNac.ValueChanged += new System.EventHandler(this.dtpFechaNac_ValueChanged);
            // 
            // chFechaNac
            // 
            this.chFechaNac.AutoSize = true;
            this.chFechaNac.Location = new System.Drawing.Point(307, 111);
            this.chFechaNac.Name = "chFechaNac";
            this.chFechaNac.Size = new System.Drawing.Size(125, 17);
            this.chFechaNac.TabIndex = 10;
            this.chFechaNac.Text = "Fecha de nacimiento";
            this.chFechaNac.UseVisualStyleBackColor = true;
            // 
            // chSexo
            // 
            this.chSexo.AutoSize = true;
            this.chSexo.Location = new System.Drawing.Point(307, 140);
            this.chSexo.Name = "chSexo";
            this.chSexo.Size = new System.Drawing.Size(50, 17);
            this.chSexo.TabIndex = 14;
            this.chSexo.Text = "Sexo";
            this.chSexo.UseVisualStyleBackColor = true;
            // 
            // chEstadoCivil
            // 
            this.chEstadoCivil.AutoSize = true;
            this.chEstadoCivil.Location = new System.Drawing.Point(307, 167);
            this.chEstadoCivil.Name = "chEstadoCivil";
            this.chEstadoCivil.Size = new System.Drawing.Size(80, 17);
            this.chEstadoCivil.TabIndex = 16;
            this.chEstadoCivil.Text = "Estado civil";
            this.chEstadoCivil.UseVisualStyleBackColor = true;
            // 
            // cbSexo
            // 
            this.cbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSexo.FormattingEnabled = true;
            this.cbSexo.Location = new System.Drawing.Point(363, 135);
            this.cbSexo.Name = "cbSexo";
            this.cbSexo.Size = new System.Drawing.Size(121, 21);
            this.cbSexo.TabIndex = 15;
            // 
            // cbEstadoCivil
            // 
            this.cbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoCivil.FormattingEnabled = true;
            this.cbEstadoCivil.Location = new System.Drawing.Point(390, 163);
            this.cbEstadoCivil.Name = "cbEstadoCivil";
            this.cbEstadoCivil.Size = new System.Drawing.Size(121, 21);
            this.cbEstadoCivil.TabIndex = 17;
            // 
            // FrmAfiliadoListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 538);
            this.Name = "FrmAfiliadoListado";
            this.Text = "Clinica FRBA - Afiliados - Listado";
            this.gbAcciones.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbNroPrincipal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDocumento;
        private System.Windows.Forms.ComboBox cbTipoDoc;
        private System.Windows.Forms.Button btnBuscarPlanMedico;
        private System.Windows.Forms.TextBox tbPlanMedico;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNroSecundario;
        private System.Windows.Forms.CheckBox chTipoDoc;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.CheckBox chSexo;
        private System.Windows.Forms.ComboBox cbEstadoCivil;
        private System.Windows.Forms.CheckBox chFechaNac;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.CheckBox chEstadoCivil;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
    }
}