using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;
using GestionGUIHelper.Validaciones;
using GestionGUIHelper.Helpers;

namespace Clinica_Frba.Roles
{
    public partial class FrmRolModificar : FormularioBaseModificacion
    {
        public FrmRolModificar()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }
        protected override void AccionAceptar()
        {
            MensajePorPantalla.MensajeInformativo(this, "Falta Implementar");
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }

        private void LimpiarControles()
        {
            this.tbNombre.Text = string.Empty;
            this.chkHabilitado.Checked = false;

            foreach (int i in clsFuncionalidades.CheckedIndices)
            {
                clsFuncionalidades.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void FrmRolModificar_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorString(tbNombre, 1, 50));
        }

    }
}
