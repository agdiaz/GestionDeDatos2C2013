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
            MensajePorPantalla.MensajeError("Implementar");
            this.Close();
        }
    }
}
