namespace Clinica_Frba.Compras
{
    partial class FrmCompraBonos
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tbAfiliado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPrecioTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lstBonos = new System.Windows.Forms.ListBox();
            this.btnFarmacia = new System.Windows.Forms.Button();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnComprar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.tbAfiliado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbPrecioTotal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compra de bonos";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(265, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tbAfiliado
            // 
            this.tbAfiliado.Location = new System.Drawing.Point(62, 29);
            this.tbAfiliado.Name = "tbAfiliado";
            this.tbAfiliado.ReadOnly = true;
            this.tbAfiliado.Size = new System.Drawing.Size(197, 20);
            this.tbAfiliado.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Afiliado";
            // 
            // tbPrecioTotal
            // 
            this.tbPrecioTotal.Location = new System.Drawing.Point(84, 268);
            this.tbPrecioTotal.Name = "tbPrecioTotal";
            this.tbPrecioTotal.ReadOnly = true;
            this.tbPrecioTotal.Size = new System.Drawing.Size(100, 20);
            this.tbPrecioTotal.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Precio total";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnQuitar);
            this.groupBox2.Controls.Add(this.lstBonos);
            this.groupBox2.Controls.Add(this.btnFarmacia);
            this.groupBox2.Controls.Add(this.btnConsulta);
            this.groupBox2.Location = new System.Drawing.Point(15, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 192);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar bono";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Location = new System.Drawing.Point(531, 132);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 3;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // lstBonos
            // 
            this.lstBonos.FormattingEnabled = true;
            this.lstBonos.Location = new System.Drawing.Point(6, 21);
            this.lstBonos.Name = "lstBonos";
            this.lstBonos.Size = new System.Drawing.Size(519, 160);
            this.lstBonos.TabIndex = 0;
            // 
            // btnFarmacia
            // 
            this.btnFarmacia.Enabled = false;
            this.btnFarmacia.Location = new System.Drawing.Point(531, 50);
            this.btnFarmacia.Name = "btnFarmacia";
            this.btnFarmacia.Size = new System.Drawing.Size(75, 23);
            this.btnFarmacia.TabIndex = 2;
            this.btnFarmacia.Text = "Farmacia";
            this.btnFarmacia.UseVisualStyleBackColor = true;
            this.btnFarmacia.Click += new System.EventHandler(this.btnFarmacia_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.Enabled = false;
            this.btnConsulta.Location = new System.Drawing.Point(531, 21);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(75, 23);
            this.btnConsulta.TabIndex = 1;
            this.btnConsulta.Text = "Consulta";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.Enabled = false;
            this.btnComprar.Location = new System.Drawing.Point(546, 268);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(75, 23);
            this.btnComprar.TabIndex = 9;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            // 
            // FrmCompraBonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 325);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCompraBonos";
            this.Text = "Clinica FRBA - Compras de bonos";
            this.Load += new System.EventHandler(this.FrmCompraBonos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstBonos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFarmacia;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox tbAfiliado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPrecioTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnComprar;
    }
}