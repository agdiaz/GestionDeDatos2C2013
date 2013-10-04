using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;

namespace Clinica_Frba.Afiliados
{
    public partial class FrmAfiliadoListado : FormularioBaseListado
    {
        public FrmAfiliadoListado()
            :base()
        {
            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            using (FrmAfiliadoAlta frm = new FrmAfiliadoAlta())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionModificar()
        {
            using (FrmAfiliadoModificar frm = new FrmAfiliadoModificar())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionBorrar()
        {
            base.AccionBorrar();
        }
    }
}
