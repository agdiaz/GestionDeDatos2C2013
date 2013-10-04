using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;
using GestionGUIHelper.Helpers;

namespace Clinica_Frba.Planes
{
    public partial class FrmPlanListado : FormularioBaseListado
    {
        public FrmPlanListado()
            :base()
        {
            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            using (FrmPlanAlta frm = new FrmPlanAlta())
            {
                frm.ShowDialog();
            }
        }

        protected override void AccionModificar()
        {
            using (frmPlanModificar frm = new frmPlanModificar())
            {
                frm.ShowDialog();
            }
        }

        protected override void AccionBorrar()
        {
            MensajePorPantalla.MensajeInformativo(this, "No se implementa");
        }
    }
}
