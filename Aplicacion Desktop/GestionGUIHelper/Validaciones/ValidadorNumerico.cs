using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Helpers;

namespace GestionGUIHelper.Validaciones
{
    public class ValidadorNumerico : IValidador 
    {
        private Control _control;
        public ValidadorNumerico(Control control)
        {
            _control = control;
        }

        #region Miembros de IValidador

        public bool Validar()
        {
            try
            {
                int valor = Convert.ToInt32(_control.Text);
                return true;
            }
            catch (Exception)
            {
                MensajePorPantalla.MensajeValidacionNumerico(_control.Name);
                return false;
            }
        }

        #endregion
    }
}
