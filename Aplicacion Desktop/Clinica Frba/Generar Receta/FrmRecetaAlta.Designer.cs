namespace Clinica_Frba.Recetas
{
    partial class FrmRecetaAlta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnValidar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbCantMedicamentos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.ndCantidad = new System.Windows.Forms.NumericUpDown();
            this.tbMedicamento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lstMedicamentos = new System.Windows.Forms.ListBox();
            this.tbBonoFarmacia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAfiliado = new System.Windows.Forms.TextBox();
            this.btnBuscarAfiliado = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarAfiliado);
            this.groupBox1.Controls.Add(this.tbAfiliado);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.btnValidar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tbBonoFarmacia);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 447);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Receta";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(98, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(530, 411);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(263, 33);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(75, 23);
            this.btnValidar.TabIndex = 6;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Preescripción";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbCantMedicamentos);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbCantidad);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.ndCantidad);
            this.groupBox2.Controls.Add(this.tbMedicamento);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnQuitar);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.lstMedicamentos);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(6, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(605, 297);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Medicamentos";
            // 
            // tbCantMedicamentos
            // 
            this.tbCantMedicamentos.Location = new System.Drawing.Point(178, 269);
            this.tbCantMedicamentos.Name = "tbCantMedicamentos";
            this.tbCantMedicamentos.ReadOnly = true;
            this.tbCantMedicamentos.Size = new System.Drawing.Size(100, 20);
            this.tbCantMedicamentos.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Cantidad de medicamentos";
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(243, 57);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.ReadOnly = true;
            this.tbCantidad.Size = new System.Drawing.Size(100, 20);
            this.tbCantidad.TabIndex = 10;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(422, 94);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // ndCantidad
            // 
            this.ndCantidad.Location = new System.Drawing.Point(116, 56);
            this.ndCantidad.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ndCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ndCantidad.Name = "ndCantidad";
            this.ndCantidad.Size = new System.Drawing.Size(120, 20);
            this.ndCantidad.TabIndex = 8;
            this.ndCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ndCantidad.ValueChanged += new System.EventHandler(this.ndCantidad_ValueChanged);
            // 
            // tbMedicamento
            // 
            this.tbMedicamento.Location = new System.Drawing.Point(116, 30);
            this.tbMedicamento.Name = "tbMedicamento";
            this.tbMedicamento.ReadOnly = true;
            this.tbMedicamento.Size = new System.Drawing.Size(354, 20);
            this.tbMedicamento.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cantidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Medicamento";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(503, 94);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 4;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(476, 28);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lstMedicamentos
            // 
            this.lstMedicamentos.FormattingEnabled = true;
            this.lstMedicamentos.Location = new System.Drawing.Point(26, 123);
            this.lstMedicamentos.Name = "lstMedicamentos";
            this.lstMedicamentos.Size = new System.Drawing.Size(573, 134);
            this.lstMedicamentos.TabIndex = 2;
            // 
            // tbBonoFarmacia
            // 
            this.tbBonoFarmacia.Location = new System.Drawing.Point(98, 37);
            this.tbBonoFarmacia.Name = "tbBonoFarmacia";
            this.tbBonoFarmacia.Size = new System.Drawing.Size(158, 20);
            this.tbBonoFarmacia.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bono farmacia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Afiliado";
            // 
            // tbAfiliado
            // 
            this.tbAfiliado.Location = new System.Drawing.Point(98, 11);
            this.tbAfiliado.Name = "tbAfiliado";
            this.tbAfiliado.ReadOnly = true;
            this.tbAfiliado.Size = new System.Drawing.Size(158, 20);
            this.tbAfiliado.TabIndex = 15;
            // 
            // btnBuscarAfiliado
            // 
            this.btnBuscarAfiliado.Location = new System.Drawing.Point(263, 11);
            this.btnBuscarAfiliado.Name = "btnBuscarAfiliado";
            this.btnBuscarAfiliado.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarAfiliado.TabIndex = 16;
            this.btnBuscarAfiliado.Text = "Buscar";
            this.btnBuscarAfiliado.UseVisualStyleBackColor = true;
            this.btnBuscarAfiliado.Click += new System.EventHandler(this.btnBuscarAfiliado_Click);
            // 
            // FrmRecetaAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 465);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRecetaAlta";
            this.Text = "z";
            this.Load += new System.EventHandler(this.FrmRecetaAlta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndCantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbBonoFarmacia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ListBox lstMedicamentos;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.TextBox tbMedicamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ndCantidad;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCantMedicamentos;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox tbAfiliado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBuscarAfiliado;
    }
}