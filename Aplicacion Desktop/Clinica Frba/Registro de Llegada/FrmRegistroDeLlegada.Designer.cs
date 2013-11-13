namespace Clinica_Frba.RegistrosDeLLegada
{
    partial class FrmRegistroDeLlegada
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarAfiliado = new System.Windows.Forms.Button();
            this.tbAfiliado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarTurno = new System.Windows.Forms.Button();
            this.tbTurno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnValidarBono = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.tbBonoConsulta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarAfiliado);
            this.groupBox1.Controls.Add(this.tbAfiliado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBuscarTurno);
            this.groupBox1.Controls.Add(this.tbTurno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Validación de turno";
            // 
            // btnBuscarAfiliado
            // 
            this.btnBuscarAfiliado.Location = new System.Drawing.Point(334, 22);
            this.btnBuscarAfiliado.Name = "btnBuscarAfiliado";
            this.btnBuscarAfiliado.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarAfiliado.TabIndex = 2;
            this.btnBuscarAfiliado.Text = "Buscar";
            this.btnBuscarAfiliado.UseVisualStyleBackColor = true;
            this.btnBuscarAfiliado.Click += new System.EventHandler(this.btnBuscarAfiliado_Click);
            // 
            // tbAfiliado
            // 
            this.tbAfiliado.Location = new System.Drawing.Point(47, 24);
            this.tbAfiliado.Name = "tbAfiliado";
            this.tbAfiliado.ReadOnly = true;
            this.tbAfiliado.Size = new System.Drawing.Size(280, 20);
            this.tbAfiliado.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Afiliado";
            // 
            // btnBuscarTurno
            // 
            this.btnBuscarTurno.Location = new System.Drawing.Point(334, 46);
            this.btnBuscarTurno.Name = "btnBuscarTurno";
            this.btnBuscarTurno.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarTurno.TabIndex = 4;
            this.btnBuscarTurno.Text = "Buscar";
            this.btnBuscarTurno.UseVisualStyleBackColor = true;
            this.btnBuscarTurno.Click += new System.EventHandler(this.btnBuscarTurno_Click);
            // 
            // tbTurno
            // 
            this.tbTurno.Location = new System.Drawing.Point(47, 46);
            this.tbTurno.Name = "tbTurno";
            this.tbTurno.ReadOnly = true;
            this.tbTurno.Size = new System.Drawing.Size(280, 20);
            this.tbTurno.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turno";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnValidarBono);
            this.groupBox2.Controls.Add(this.btnRegistrar);
            this.groupBox2.Controls.Add(this.tbBonoConsulta);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bono consulta";
            // 
            // btnValidarBono
            // 
            this.btnValidarBono.Location = new System.Drawing.Point(334, 31);
            this.btnValidarBono.Name = "btnValidarBono";
            this.btnValidarBono.Size = new System.Drawing.Size(75, 23);
            this.btnValidarBono.TabIndex = 6;
            this.btnValidarBono.Text = "Validar";
            this.btnValidarBono.UseVisualStyleBackColor = true;
            this.btnValidarBono.Click += new System.EventHandler(this.btnValidarBono_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(9, 71);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 7;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // tbBonoConsulta
            // 
            this.tbBonoConsulta.Location = new System.Drawing.Point(78, 34);
            this.tbBonoConsulta.Name = "tbBonoConsulta";
            this.tbBonoConsulta.Size = new System.Drawing.Size(249, 20);
            this.tbBonoConsulta.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nro de bono";
            // 
            // FrmRegistroDeLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 215);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRegistroDeLlegada";
            this.Text = "Clinica FRBA - Registro de llegada";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarTurno;
        private System.Windows.Forms.TextBox tbTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBonoConsulta;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnValidarBono;
        private System.Windows.Forms.Button btnBuscarAfiliado;
        private System.Windows.Forms.TextBox tbAfiliado;
        private System.Windows.Forms.Label label3;
    }
}