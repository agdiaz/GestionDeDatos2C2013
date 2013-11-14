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
using GestionDomain;
using GestionCommon.Entidades;
using GestionDomain.Resultados;
using GestionCommon.Filtros;

namespace Clinica_Frba.Planes
{
    public partial class FrmPlanListado : FormularioBaseListado
    {
        private PlanMedicoDomain _domain;

        public FrmPlanListado(bool modoSeleccion)
            : base(modoSeleccion)
        {
            _domain = new PlanMedicoDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }

        public FrmPlanListado()
            : this(false)
        {
        }



        protected override void AccionAlta()
        {
            using (FrmPlanAlta frm = new FrmPlanAlta())
            {
                frm.ShowDialog();
            }
        }

        protected override void AccionModificar()
        {
            using (frmPlanModificar frm = new frmPlanModificar())
            {
                frm.ShowDialog();
            }
        }

        protected override void AccionBorrar()
        {
            MensajePorPantalla.MensajeInformativo(this, "No se implementa");
        }

        protected override void AccionFiltrar()
        {
            FiltroPlanMedico filtro = new FiltroPlanMedico();

            filtro.Nombre = tbNombrePlan.Text;
            if (!string.IsNullOrEmpty(tbBonoConsulta.Text))
                filtro.BonoConsulta = Convert.ToDecimal(tbBonoConsulta.Text);
            
            if (!string.IsNullOrEmpty(tbBonoFarmacia.Text))
                filtro.BonoFarmacia = Convert.ToDecimal(tbBonoFarmacia.Text);

            IResultado<IList<PlanMedico>> resultado = _domain.Filtrar(filtro);

            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<IList<PlanMedico>>(resultado);

            this.dgvBusqueda.DataSource = resultado.Retorno;

            this.dgvBusqueda.Columns["IdPlan"].Visible = false;
            this.dgvBusqueda.Columns["Habilitado"].Visible = false;
        }

        protected override void AccionIniciar()
        {
            
        }

        protected override void AccionLimpiar()
        {
            this.tbNombrePlan.Text = string.Empty;
            this.tbBonoConsulta.Text = string.Empty;
            this.tbBonoFarmacia.Text = string.Empty;
        }

        private void FrmPlanListado_Load(object sender, EventArgs e)
        {
            AccionLimpiar();
            //this.AgregarValidacion(new ValidadorNumerico(tbNombrePlan));
        }
    }
}
