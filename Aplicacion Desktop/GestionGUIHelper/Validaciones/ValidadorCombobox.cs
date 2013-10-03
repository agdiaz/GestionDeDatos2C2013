using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Helpers;

namespace GestionGUIHelper.Validaciones
{
    public class ValidadorCombobox : IValidador
    {
        private ComboBox _control;

        public ValidadorCombobox(ComboBox control)
        {
            this._control = control;
        }
        #region Miembros de IValidador

        public bool Validar()
        {
            if (_control.SelectedIndex > 0)
            {
                return true;
            }
            else
            {
                MensajePorPantalla.MensajeValidacionCombobox(_control.Name);
                return false;
            }
        }

        #endregion
    }
}
