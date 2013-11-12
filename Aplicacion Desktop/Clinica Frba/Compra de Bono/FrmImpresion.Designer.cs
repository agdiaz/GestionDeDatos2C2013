namespace Clinica_Frba.Compra_de_Bono
{
    partial class FrmImpresion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstBonosConsulta = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstBonosFarmacia = new System.Windows.Forms.ListBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNroAfiliado = new System.Windows.Forms.TextBox();
            this.tbNombreCompleto = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(642, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clinica FRBA - Impresión de bonos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbNombreCompleto);
            this.groupBox1.Controls.Add(this.tbNroAfiliado);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 93);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del afiliado";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstBonosConsulta);
            this.groupBox2.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(19, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(628, 140);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bonos de consulta";
            // 
            // lstBonosConsulta
            // 
            this.lstBonosConsulta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBonosConsulta.FormattingEnabled = true;
            this.lstBonosConsulta.ItemHeight = 17;
            this.lstBonosConsulta.Location = new System.Drawing.Point(6, 19);
            this.lstBonosConsulta.Name = "lstBonosConsulta";
            this.lstBonosConsulta.Size = new System.Drawing.Size(616, 102);
            this.lstBonosConsulta.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstBonosFarmacia);
            this.groupBox3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(18, 294);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(628, 140);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bonos de farmacia";
            // 
            // lstBonosFarmacia
            // 
            this.lstBonosFarmacia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBonosFarmacia.FormattingEnabled = true;
            this.lstBonosFarmacia.ItemHeight = 16;
            this.lstBonosFarmacia.Location = new System.Drawing.Point(6, 19);
            this.lstBonosFarmacia.Name = "lstBonosFarmacia";
            this.lstBonosFarmacia.Size = new System.Drawing.Size(616, 96);
            this.lstBonosFarmacia.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(565, 440);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(537, 35);
            this.label2.TabIndex = 5;
            this.label2.Text = "Recuerde que deberá presentar estos números para continuar con los procedimientos" +
                " en la clínica.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nº de afiliado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nombre completo";
            // 
            // tbNroAfiliado
            // 
            this.tbNroAfiliado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNroAfiliado.Location = new System.Drawing.Point(248, 23);
            this.tbNroAfiliado.Name = "tbNroAfiliado";
            this.tbNroAfiliado.Size = new System.Drawing.Size(373, 24);
            this.tbNroAfiliado.TabIndex = 2;
            // 
            // tbNombreCompleto
            // 
            this.tbNombreCompleto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNombreCompleto.Location = new System.Drawing.Point(248, 60);
            this.tbNombreCompleto.Name = "tbNombreCompleto";
            this.tbNombreCompleto.Size = new System.Drawing.Size(373, 24);
            this.tbNombreCompleto.TabIndex = 3;
            // 
            // FrmImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(659, 481);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FrmImpresion";
            this.Text = "Clinica Frba : Impresión de bonos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmImpresion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstBonosConsulta;
        private System.Windows.Forms.ListBox lstBonosFarmacia;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombreCompleto;
        private System.Windows.Forms.TextBox tbNroAfiliado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}