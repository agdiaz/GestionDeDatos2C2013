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
using Clinica_Frba.Planes;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using GestionDomain.Resultados;
using GestionDomain;

namespace Clinica_Frba.Afiliados
{
    public partial class FrmAfiliadoListado : FormularioBaseListado
    {
        AfiliadoDomain _domain = new AfiliadoDomain(Program.ContextoActual.Logger);

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

        protected override void AccionFiltrar()
        {
            FiltroAfiliado filtro = new FiltroAfiliado();

            filtro.Nombre = tbNombre.Text;
            filtro.Apellido = tbApellido.Text;
            filtro.IdPlanMedico = (tbPlanMedico.Tag as PlanMedico).IdPlan;
            filtro.NroAfiliado = Convert.ToDecimal(tbNroAfiliado);
            //filtro.IdTipoDocumento = 
            filtro.Documento = Convert.ToDecimal(tbDocumento);

            IResultado<IList<Afiliado>> resultado = _domain.Filtrar(filtro);

            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<IList<Afiliado>>(resultado);

            this.dgvBusqueda.DataSource = resultado.Retorno;
        }

        protected override void AccionIniciar()
        {
            
        }

        protected override void AccionLimpiar()
        {
            tbNroAfiliado.Text = string.Empty;
            tbPlanMedico.Tag = null;
            tbPlanMedico.Text = string.Empty;
            cbTipoDoc.SelectedIndex = 0;
            tbDocumento.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbApellido.Text = string.Empty;
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

        private void btnBuscarPlanMedico_Click(object sender, EventArgs e)
        {
            using (FrmPlanListado frm = new FrmPlanListado() )
            {
                frm.ShowDialog(this);
                PlanMedico plan = frm.EntidadSeleccionada as PlanMedico;
                if (plan != null)
                {
                    tbPlanMedico.Tag = plan;
                    tbPlanMedico.Text = plan.Descripcion;
                }
            }
        }

    }
}
