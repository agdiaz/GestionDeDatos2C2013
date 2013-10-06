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
using GestionGUIHelper.Validaciones;

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
            ndCantHijos.Value = 0;
            tbDireccion.Text = string.Empty;
            tbMail.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbNroAfiliado.Text = string.Empty;
            tbNroDocumento.Text = string.Empty;
            tbTelefono.Text = string.Empty;

            cbPlanMedico.SelectedIndex = 0;
            cbTipoDocumento.SelectedIndex = 0;

            rbEstadoCivilSoltero.Checked = true;

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
            this.AgregarValidacion(new ValidadorString(tbNombre, 1, 255));
            this.AgregarValidacion(new ValidadorString(tbApellido, 1, 255));
            this.AgregarValidacion(new ValidadorCombobox(cbTipoDocumento));
            this.AgregarValidacion(new ValidadorNumerico(tbNroDocumento));
            this.AgregarValidacion(new ValidadorDateTimeUntil(dpFechaNacimiento,FechaHelper.Ahora()));
            this.AgregarValidacion(new ValidadorString(tbDireccion, 1, 255));
            this.AgregarValidacion(new ValidadorNumerico(tbTelefono));
            this.AgregarValidacion(new ValidadorString(tbMail,1 ,255));
            this.AgregarValidacion(new ValidadorMail(tbMail));

        }

    }
}
