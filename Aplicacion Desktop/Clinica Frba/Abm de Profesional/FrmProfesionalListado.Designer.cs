namespace Clinica_Frba.Profesionales
{
    partial class FrmProfesionalListado
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tbEspecialidad = new System.Windows.Forms.TextBox();
            this.btnBuscarEspecialidad = new System.Windows.Forms.Button();
            this.gbAcciones.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.btnBuscarEspecialidad);
            this.gbFiltros.Controls.Add(this.tbEspecialidad);
            this.gbFiltros.Controls.Add(this.textBox4);
            this.gbFiltros.Controls.Add(this.tbApellido);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.label5);
            this.gbFiltros.Controls.Add(this.label3);
            this.gbFiltros.Controls.Add(this.tbNombre);
            this.gbFiltros.Controls.Add(this.textBox1);
            this.gbFiltros.Controls.Add(this.label4);
            this.gbFiltros.Controls.SetChildIndex(this.label4, 0);
            this.gbFiltros.Controls.SetChildIndex(this.textBox1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbNombre, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label3, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label5, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label2, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbApellido, 0);
            this.gbFiltros.Controls.SetChildIndex(this.textBox4, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbEspecialidad, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnBuscarEspecialidad, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Documento";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(347, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 20);
            this.textBox1.TabIndex = 5;
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(70, 44);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(178, 20);
            this.tbApellido.TabIndex = 6;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(69, 18);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(179, 20);
            this.tbNombre.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Especialidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Matricula";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(347, 44);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(179, 20);
            this.textBox4.TabIndex = 11;
            // 
            // tbEspecialidad
            // 
            this.tbEspecialidad.Location = new System.Drawing.Point(255, 80);
            this.tbEspecialidad.Name = "tbEspecialidad";
            this.tbEspecialidad.ReadOnly = true;
            this.tbEspecialidad.Size = new System.Drawing.Size(211, 20);
            this.tbEspecialidad.TabIndex = 12;
            // 
            // btnBuscarEspecialidad
            // 
            this.btnBuscarEspecialidad.Location = new System.Drawing.Point(473, 80);
            this.btnBuscarEspecialidad.Name = "btnBuscarEspecialidad";
            this.btnBuscarEspecialidad.Size = new System.Drawing.Size(53, 23);
            this.btnBuscarEspecialidad.TabIndex = 13;
            this.btnBuscarEspecialidad.Text = "Buscar";
            this.btnBuscarEspecialidad.UseVisualStyleBackColor = true;
            this.btnBuscarEspecialidad.Click += new System.EventHandler(this.btnBuscarEspecialidad_Click);
            // 
            // FrmProfesionalListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 441);
            this.Name = "FrmProfesionalListado";
            this.Text = "Clinica FRBA - Profesionales - Listado";
            this.gbAcciones.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscarEspecialidad;
        private System.Windows.Forms.TextBox tbEspecialidad;
    }
}