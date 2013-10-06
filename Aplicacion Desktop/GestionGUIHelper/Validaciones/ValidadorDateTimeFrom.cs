using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Helpers;

namespace GestionGUIHelper.Validaciones
{
    public class ValidadorDateTimeFrom : IValidador
    {
        private DateTimePicker _control;
        private DateTime _from;

        public ValidadorDateTimeFrom(DateTimePicker control, DateTime from)
        {
            _control = control;
            _from = from;
        }

        #region Miembros de IValidador

        public bool Validar()
        {
            if (_control.Value >= _from)
            {
                return true;
            }
            else
            {
                MensajePorPantalla.MensajeValidacionDateTimeFrom(_control.Name, _from);
                return false;
            }
        }

        #endregion
    }
}
