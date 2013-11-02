using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;
using Clinica_Frba.Especialidades;
using GestionCommon.Entidades;

namespace Clinica_Frba.Profesionales
{
    public partial class FrmProfesionalListado : FormularioBaseListado
    {
        public FrmProfesionalListado()
            :base()
        {
            InitializeComponent();
        }

        public FrmProfesionalListado(bool modoSeleccion)
            : base(modoSeleccion)
        {
            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            using (FrmProfesionalAlta frm = new FrmProfesionalAlta())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionModificar()
        {
            using (FrmProfesionalModificar frm = new FrmProfesionalModificar())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnBuscarEspecialidad_Click(object sender, EventArgs e)
        {
            Especialidad especialidad = null;
            using (FrmEspecialidadListado frm = new FrmEspecialidadListado(true))
            {
                frm.ShowDialog(this);
                especialidad = frm.EntidadSeleccionada as Especialidad;
            }

            if (especialidad != null)
            {
                tbEspecialidad.Text = especialidad.Nombre;
                tbEspecialidad.Tag = especialidad;
            }
        }
    }
}
