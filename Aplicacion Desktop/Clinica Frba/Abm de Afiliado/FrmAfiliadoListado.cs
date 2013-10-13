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

namespace Clinica_Frba.Afiliados
{
    public partial class FrmAfiliadoListado : FormularioBaseListado
    {
        public FrmAfiliadoListado()
            :base()
        {
            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            using (FrmAfiliadoAlta frm = new FrmAfiliadoAlta())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionModificar()
        {
            using (FrmAfiliadoModificar frm = new FrmAfiliadoModificar())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionBorrar()
        {
            base.AccionBorrar();
        }

        private void FrmAfiliadoListado_Load(object sender, EventArgs e)
        {
            AccionLimpiar();
            this.AgregarValidacion(new ValidadorNumerico(tbNroAfiliado));
            this.AgregarValidacion(new ValidadorCombobox(cbTipoDoc));
            this.AgregarValidacion(new ValidadorNumerico(tbPlanMedico));
            this.AgregarValidacion(new ValidadorString(tbNombre, 1, 255));
            this.AgregarValidacion(new ValidadorString(tbApellido, 1, 255));
        }
    }
}
