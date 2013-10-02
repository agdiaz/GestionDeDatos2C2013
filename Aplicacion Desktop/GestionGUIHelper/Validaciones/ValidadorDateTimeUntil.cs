using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Helpers;

namespace GestionGUIHelper.Validaciones
{
    public class ValidadorDateTimeUntil :IValidador
    {
        private DateTimePicker _control;
        private DateTime _until;

        public ValidadorDateTimeUntil(DateTimePicker control, DateTime until)
        {
            _control = control;
            _until = until;
        }

        #region Miembros de IValidador

        public bool Validar()
        {
            if (_control.Value <= _until)
            {
                return true;
            }
            else
            {
                MensajePorPantalla.MensajeValidacionDateTime(_control.Name, _until);
                return false;
            }
        }

        #endregion
    }
}
