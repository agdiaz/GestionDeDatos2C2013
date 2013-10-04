using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Validaciones;

namespace GestionGUIHelper.Formularios
{
    public class FormularioBase : Form
    {
        #region Propiedades
        public IList<IValidador> Validaciones { get; set; }
        #endregion

        #region Constructor
        public FormularioBase()
        {
            Validaciones = new List<IValidador>();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        #endregion

        #region Métodos protegidos
        protected void AgregarValidacion(IValidador validacion)
        {
            this.Validaciones.Add(validacion);
        }
        protected virtual bool Validar()
        {
            bool datosCorrectos = true;

            for (int i = 0; i < Validaciones.Count && datosCorrectos; i++)
            {
                datosCorrectos = Validaciones[i].Validar();
            }

            return datosCorrectos;
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormularioBase
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "FormularioBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }
    }
}
