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
    public partial class FrmRolAlta : FormularioBaseAlta
    {
        public FrmRolAlta()
        {
            InitializeComponent();
        }

        private void FrmRolAlta_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorString(tbNombre, 1, 50));
        }
        
        #region [btnAceptar]
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }
        protected override void AccionAceptar()
        {
            MensajePorPantalla.MensajeInformativo(this, "Falta Implementar");
            this.Close();
        }
        #endregion
        
        #region [btnCancelar]
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion
        
        #region [btnLimpiar]
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
        #endregion

        private void LimpiarControles()
        {
            this.tbNombre.Text = string.Empty;
            this.chkHabilitado.Checked = false;

            foreach (int i in clsFuncionalidades.CheckedIndices)
            {
                clsFuncionalidades.SetItemCheckState(i, CheckState.Unchecked);
            }
        }


    }
}
