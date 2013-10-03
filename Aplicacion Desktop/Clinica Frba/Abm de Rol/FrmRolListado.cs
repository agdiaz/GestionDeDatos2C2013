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
    public partial class FrmRolListado : Form
    {
        public FrmRolListado()
            :base()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            using (FrmRolAlta frm = new FrmRolAlta())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            using (FrmRolModificar frm = new FrmRolModificar())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
