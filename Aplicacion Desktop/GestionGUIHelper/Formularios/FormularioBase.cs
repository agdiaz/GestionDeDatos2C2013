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
    }
}
