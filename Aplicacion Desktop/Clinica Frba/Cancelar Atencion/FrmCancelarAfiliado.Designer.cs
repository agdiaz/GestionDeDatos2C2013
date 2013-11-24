namespace Clinica_Frba.Cancelaciones
{
    partial class FrmCancelarAfiliado
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
            this.tbMotivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTurno = new System.Windows.Forms.TextBox();
            this.btnBuscarTurno = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbAfiliado = new System.Windows.Forms.TextBox();
            this.btnBuscarAfiliado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbMotivo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbTipo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbTurno);
            this.groupBox1.Controls.Add(this.btnBuscarTurno);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tbAfiliado);
            this.groupBox1.Controls.Add(this.btnBuscarAfiliado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 319);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cancelación de afiliado";
            // 
            // tbMotivo
            // 
            this.tbMotivo.Enabled = false;
            this.tbMotivo.Location = new System.Drawing.Point(58, 134);
            this.tbMotivo.Multiline = true;
            this.tbMotivo.Name = "tbMotivo";
            this.tbMotivo.Size = new System.Drawing.Size(453, 108);
            this.tbMotivo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Motivo";
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.Enabled = false;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(58, 84);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(172, 21);
            this.cbTipo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Turno";
            // 
            // tbTurno
            // 
            this.tbTurno.Location = new System.Drawing.Point(58, 57);
            this.tbTurno.Name = "tbTurno";
            this.tbTurno.ReadOnly = true;
            this.tbTurno.Size = new System.Drawing.Size(172, 20);
            this.tbTurno.TabIndex = 3;
            // 
            // btnBuscarTurno
            // 
            this.btnBuscarTurno.Location = new System.Drawing.Point(248, 61);
            this.btnBuscarTurno.Name = "btnBuscarTurno";
            this.btnBuscarTurno.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarTurno.TabIndex = 4;
            this.btnBuscarTurno.Text = "Buscar";
            this.btnBuscarTurno.UseVisualStyleBackColor = true;
            this.btnBuscarTurno.Click += new System.EventHandler(this.btnBuscarTurno_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(248, 290);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Aceptar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(166, 290);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbAfiliado
            // 
            this.tbAfiliado.Location = new System.Drawing.Point(58, 31);
            this.tbAfiliado.Name = "tbAfiliado";
            this.tbAfiliado.ReadOnly = true;
            this.tbAfiliado.Size = new System.Drawing.Size(172, 20);
            this.tbAfiliado.TabIndex = 1;
            // 
            // btnBuscarAfiliado
            // 
            this.btnBuscarAfiliado.Location = new System.Drawing.Point(248, 31);
            this.btnBuscarAfiliado.Name = "btnBuscarAfiliado";
            this.btnBuscarAfiliado.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarAfiliado.TabIndex = 2;
            this.btnBuscarAfiliado.Text = "Buscar";
            this.btnBuscarAfiliado.UseVisualStyleBackColor = true;
            this.btnBuscarAfiliado.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Afiliado";
            // 
            // FrmCancelarAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 344);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCancelarAfiliado";
            this.Text = "Clinica FRBA - Cancelaciones de afiliado";
            this.Load += new System.EventHandler(this.FrmCancelarAfiliado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbAfiliado;
        private System.Windows.Forms.Button btnBuscarAfiliado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTurno;
        private System.Windows.Forms.Button btnBuscarTurno;
        private System.Windows.Forms.TextBox tbMotivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label3;
    }
}