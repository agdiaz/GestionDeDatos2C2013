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
using GestionCommon.Helpers;

namespace Clinica_Frba.Afiliados
{
    public partial class FrmAfiliadoAlta : FormularioBaseAlta
    {
        public FrmAfiliadoAlta()
            :base()
        {
            InitializeComponent();
        }

        protected override void AccionAceptar()
        {

        }

        protected override void AccionLimpiar()
        {
            tbApellido.Text = string.Empty;
            tbCantHijos.Text = string.Empty;
            tbDireccion.Text = string.Empty;
            tbMail.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbNroAfiliado.Text = string.Empty;
            tbNroDocumento.Text = string.Empty;
            tbTelefono.Text = string.Empty;

            cbPlanMedico.SelectedIndex = 0;
            cbTipoDocumento.SelectedIndex = 0;

            dpFechaNacimiento.Value = FechaHelper.Ahora();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            base.Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }

        private void FrmAfiliadoAlta_Load(object sender, EventArgs e)
        {
            AccionLimpiar();
        }

    }
}
