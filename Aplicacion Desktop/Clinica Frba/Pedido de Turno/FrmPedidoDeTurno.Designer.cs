namespace Clinica_Frba.PedidosDeTurno
{
    partial class FrmPedidoDeTurno
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
            this.gbBusquedaProfesional = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cbDias = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarProfesional = new System.Windows.Forms.Button();
            this.tbProfesional = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscarAfiliado = new System.Windows.Forms.Button();
            this.tbAfiliado = new System.Windows.Forms.TextBox();
            this.gbBusquedaProfesional.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBusquedaProfesional
            // 
            this.gbBusquedaProfesional.Controls.Add(this.btnFiltrar);
            this.gbBusquedaProfesional.Controls.Add(this.checkedListBox1);
            this.gbBusquedaProfesional.Controls.Add(this.btnAceptar);
            this.gbBusquedaProfesional.Controls.Add(this.cbDias);
            this.gbBusquedaProfesional.Controls.Add(this.label4);
            this.gbBusquedaProfesional.Controls.Add(this.dtpHasta);
            this.gbBusquedaProfesional.Controls.Add(this.label3);
            this.gbBusquedaProfesional.Controls.Add(this.dtpDesde);
            this.gbBusquedaProfesional.Controls.Add(this.label2);
            this.gbBusquedaProfesional.Controls.Add(this.btnBuscarProfesional);
            this.gbBusquedaProfesional.Controls.Add(this.tbProfesional);
            this.gbBusquedaProfesional.Controls.Add(this.label1);
            this.gbBusquedaProfesional.Location = new System.Drawing.Point(12, 65);
            this.gbBusquedaProfesional.Name = "gbBusquedaProfesional";
            this.gbBusquedaProfesional.Size = new System.Drawing.Size(689, 408);
            this.gbBusquedaProfesional.TabIndex = 0;
            this.gbBusquedaProfesional.TabStop = false;
            this.gbBusquedaProfesional.Text = "Búsqueda de profesional";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(227, 89);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 9;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(9, 129);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(667, 244);
            this.checkedListBox1.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(9, 379);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar turno";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbDias
            // 
            this.cbDias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDias.FormattingEnabled = true;
            this.cbDias.Location = new System.Drawing.Point(100, 89);
            this.cbDias.Name = "cbDias";
            this.cbDias.Size = new System.Drawing.Size(121, 21);
            this.cbDias.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Día de la semana";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(346, 59);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "hasta";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(100, 59);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Disponible desde";
            // 
            // btnBuscarProfesional
            // 
            this.btnBuscarProfesional.Location = new System.Drawing.Point(601, 24);
            this.btnBuscarProfesional.Name = "btnBuscarProfesional";
            this.btnBuscarProfesional.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarProfesional.TabIndex = 2;
            this.btnBuscarProfesional.Text = "Buscar";
            this.btnBuscarProfesional.UseVisualStyleBackColor = true;
            this.btnBuscarProfesional.Click += new System.EventHandler(this.btnBuscarProfesional_Click);
            // 
            // tbProfesional
            // 
            this.tbProfesional.Location = new System.Drawing.Point(71, 26);
            this.tbProfesional.Name = "tbProfesional";
            this.tbProfesional.ReadOnly = true;
            this.tbProfesional.Size = new System.Drawing.Size(524, 20);
            this.tbProfesional.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profesional";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnBuscarAfiliado);
            this.groupBox1.Controls.Add(this.tbAfiliado);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 46);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Afiliado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Afiliado";
            // 
            // btnBuscarAfiliado
            // 
            this.btnBuscarAfiliado.Location = new System.Drawing.Point(601, 20);
            this.btnBuscarAfiliado.Name = "btnBuscarAfiliado";
            this.btnBuscarAfiliado.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarAfiliado.TabIndex = 1;
            this.btnBuscarAfiliado.Text = "Buscar";
            this.btnBuscarAfiliado.UseVisualStyleBackColor = true;
            this.btnBuscarAfiliado.Click += new System.EventHandler(this.btnBuscarAfiliado_Click);
            // 
            // tbAfiliado
            // 
            this.tbAfiliado.Location = new System.Drawing.Point(71, 20);
            this.tbAfiliado.Name = "tbAfiliado";
            this.tbAfiliado.ReadOnly = true;
            this.tbAfiliado.Size = new System.Drawing.Size(524, 20);
            this.tbAfiliado.TabIndex = 0;
            // 
            // FrmPedidoDeTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 485);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbBusquedaProfesional);
            this.Name = "FrmPedidoDeTurno";
            this.Text = "Clinica FRBA - Pedido de turno";
            this.Load += new System.EventHandler(this.FrmPedidoDeTurno_Load);
            this.gbBusquedaProfesional.ResumeLayout(false);
            this.gbBusquedaProfesional.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBusquedaProfesional;
        private System.Windows.Forms.ComboBox cbDias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarProfesional;
        private System.Windows.Forms.TextBox tbProfesional;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscarAfiliado;
        private System.Windows.Forms.TextBox tbAfiliado;
        private System.Windows.Forms.Button btnFiltrar;
    }
}