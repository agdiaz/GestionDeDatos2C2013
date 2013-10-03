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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }


    }
}
