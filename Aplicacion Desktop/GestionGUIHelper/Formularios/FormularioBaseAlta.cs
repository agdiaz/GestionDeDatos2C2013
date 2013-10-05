using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestionGUIHelper.Formularios
{
    public class FormularioBaseAlta : FormularioBase
    {
        protected virtual void Aceptar()
        {
            if (base.Validar())
            {
                this.AccionAceptar();
            }
        }

        protected virtual void AccionAceptar()
        {
            throw new NotImplementedException();
        }

        protected virtual void Cancelar()
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormularioBaseAlta
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "FormularioBaseAlta";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormularioBaseAlta_KeyPress);
            this.ResumeLayout(false);

        }

        private void FormularioBaseAlta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si apretó ESC
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Cancelar();
            }
        }
    }
}
