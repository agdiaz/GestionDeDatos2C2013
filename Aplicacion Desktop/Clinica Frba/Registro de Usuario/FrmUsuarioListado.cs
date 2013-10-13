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
using GestionGUIHelper.Validaciones;

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

        private void FrmUsuarioListado_Load(object sender, EventArgs e)
        {
            AccionLimpiar();
            this.AgregarValidacion(new ValidadorString(tbUsername, 1, 255));
            this.AgregarValidacion(new ValidadorCombobox(cbRol));
        }
    }
}
