using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;

namespace Clinica_Frba.Profesionales
{
    public partial class FrmProfesionalListado : FormularioBaseListado
    {
        public FrmProfesionalListado()
            :base()
        {
            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            using (FrmProfesionalAlta frm = new FrmProfesionalAlta())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionModificar()
        {
            using (FrmProfesionalModificar frm = new FrmProfesionalModificar())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
