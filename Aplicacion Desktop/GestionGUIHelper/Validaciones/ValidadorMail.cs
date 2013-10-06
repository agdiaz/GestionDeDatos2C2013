using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionCommon.Helpers;
using GestionGUIHelper.Helpers;

namespace GestionGUIHelper.Validaciones
{
    public class ValidadorMail : IValidador
    {
        private Control _control;
        public ValidadorMail(Control control)
        {
            _control = control;
        }
        #region Miembros de IValidador

        public bool Validar()
        {
            bool esCorrecto = MailHelper.Validar(_control.Text);
            if (!esCorrecto)
            {
                MensajePorPantalla.MensajeError("Ingrese un mail válido");
            }
            return esCorrecto;
        }

        #endregion
    }
}
