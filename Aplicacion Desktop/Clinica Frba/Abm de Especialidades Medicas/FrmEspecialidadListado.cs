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

namespace Clinica_Frba.Especialidades
{
    public partial class FrmEspecialidadListado : FormularioBaseListado
    {
        public FrmEspecialidadListado()
            :base()
        {
            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            using (FrmEspecialidadesAlta frm = new FrmEspecialidadesAlta())
            {
                frm.ShowDialog();
            }
        }

        protected override void AccionModificar()
        {
            using (FrmEspecialidadModificar frm = new FrmEspecialidadModificar())
            {
                frm.ShowDialog();
            }
        }

        protected override void AccionBorrar()
        {
            MensajePorPantalla.MensajeInformativo(this, "No se implementa");
        }

        private void FrmEspecialidadListado_Load(object sender, EventArgs e)
        {
            AccionLimpiar();
            //this.AgregarValidacion(new ValidadorString(tbNombreEspecialidad, 1, 255));
            //this.AgregarValidacion(new ValidadorCombobox(cbTipoEspecialidad)); 
        }
    }
}
