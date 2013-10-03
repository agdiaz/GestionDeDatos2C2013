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

namespace Clinica_Frba.Login
{
    public partial class FrmLogin : FormularioBaseAlta
    {
        public FrmLogin(): base()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorString(tbUsuario, 1, 10));
            this.AgregarValidacion(new ValidadorString(tbPassword, 1, 10));
            this.AgregarValidacion(new ValidadorCombobox(cbRol));
        }

        protected override void AccionAceptar()
        {
            MensajePorPantalla.MensajeInformativo(this, "Iniciando sesión");
            this.Close();
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
