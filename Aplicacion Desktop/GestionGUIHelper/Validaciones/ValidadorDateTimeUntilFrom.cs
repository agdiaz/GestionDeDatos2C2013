using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Helpers;

namespace GestionGUIHelper.Validaciones
{
    public class ValidarDateTimeUntilFrom : IValidador
    {
        private DateTimePicker _control;
        DateTime _from;
        DateTime _until;

        public ValidarDateTimeUntilFrom(DateTimePicker control, DateTime from, DateTime until)
        {
            _control = control;
            _from = from;
            _until = until;
        }

        #region Miembros de IValidador

        public bool Validar()
        {
            if (_control.Value >= _from && _control.Value <= _until)
            {
                return true;
            }
            else
            {
                MensajePorPantalla.MensajeValidacionDateTime(_control.Name, _from, _until);
                return false;
            }
        }

        #endregion
    }
}
