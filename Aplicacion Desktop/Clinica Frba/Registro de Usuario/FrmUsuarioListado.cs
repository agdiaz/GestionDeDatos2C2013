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

namespace Clinica_Frba.Usuarios
{
    public partial class FrmUsuarioListado : FormularioBaseListado
    {
        public FrmUsuarioListado()
        {
            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            using (FrmUsuarioAlta frm = new FrmUsuarioAlta())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionModificar()
        {
            using (FrmUsuarioModificacion frm = new FrmUsuarioModificacion())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionBorrar()
        {
            MensajePorPantalla.MensajeInformativo(this, "No se implementa");
        }
    }
}
