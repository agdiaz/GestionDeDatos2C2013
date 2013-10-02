using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestionGUIHelper.Formularios
{
    public class FormularioBaseModificacion : FormularioBase
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
    }
}
