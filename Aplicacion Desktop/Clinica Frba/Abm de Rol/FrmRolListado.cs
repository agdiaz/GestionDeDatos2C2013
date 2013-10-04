using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;

namespace Clinica_Frba.Roles
{
    public partial class FrmRolListado : FormularioBaseListado
    {
        public FrmRolListado()
            :base()
        {
            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            using (FrmRolAlta frm = new FrmRolAlta())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionModificar()
        {
            using (FrmRolModificar frm = new FrmRolModificar())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
