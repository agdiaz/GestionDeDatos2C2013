using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionCommon.Entidades;
using Clinica_Frba.Afiliados;
using GestionCommon.Helpers;
using GestionDomain;
using GestionDomain.Resultados;
using GestionGUIHelper.Helpers;
using Clinica_Frba.Compra_de_Bono;

namespace Clinica_Frba.Compras
{
    public partial class FrmCompraBonos : Form
    {
        private Afiliado _afiliado;
        private PlanMedico _plan;

        private PlanMedicoDomain _planMedicoDomain;
        private CompraDomain _compraDomain;

        public FrmCompraBonos(Afiliado af)
            :this()
        {
            this.CargarAfiliado(af);
        }
        public FrmCompraBonos()
        {
            _planMedicoDomain = new PlanMedicoDomain(Program.ContextoActual.Logger);
            _compraDomain = new CompraDomain(Program.ContextoActual.Logger);

            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (FrmAfiliadoListado frm = new FrmAfiliadoListado(true))
            {
                frm.ShowDialog(this);
                if (frm.EntidadSeleccionada != null)
                    CargarAfiliado((Afiliado)frm.EntidadSeleccionada);
            }
        }

        private void CargarAfiliado(Afiliado af)
        {
            this._afiliado = af;
            this.tbAfiliado.Text = _afiliado.NombreCompleto;
            this.CargarPlan();
            //this.btnComprar.Enabled = true;
            this.btnConsulta.Enabled = true;
            this.btnFarmacia.Enabled = true;
            this.btnQuitar.Enabled = true;
            this.btnBuscar.Enabled = false;
        }

        private void CargarPlan()
        {
            IResultado<PlanMedico> resultado = _planMedicoDomain.Obtener(_afiliado.IdPlanMedico);
            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<PlanMedico>(resultado);

            this._plan = resultado.Retorno;
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            BonoConsulta consulta = new BonoConsulta();
            consulta.IdPlanMedico = _afiliado.IdPlanMedico;
            consulta.NombrePlanMedico = _plan.Descripcion;

            this.lstBonos.Items.Add(consulta);

            Decimal subtotal = Convert.ToDecimal(tbPrecioTotal.Text);
            subtotal += _plan.PrecioBonoConsulta;
            tbPrecioTotal.Text = subtotal.ToString();

            this.btnComprar.Enabled = true;
        }

        private void btnFarmacia_Click(object sender, EventArgs e)
        {
            BonoFarmacia farmacia = new BonoFarmacia();
            farmacia.IdPlanMedico = _afiliado.IdPlanMedico;
            farmacia.NombrePlanMedico = _plan.Descripcion;
            farmacia.FechaVencimiento = FechaHelper.Ahora().AddDays(60);

            this.lstBonos.Items.Add(farmacia);

            Decimal subtotal = Convert.ToDecimal(tbPrecioTotal.Text);
            subtotal += _plan.PrecioBonoFarmacia;
            tbPrecioTotal.Text = subtotal.ToString();
            
            this.btnComprar.Enabled = true;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            var selectedItem = lstBonos.SelectedItem;
            if (selectedItem != null)
            {
                lstBonos.Items.Remove(selectedItem);

                if (selectedItem as BonoConsulta != null)
                {
                    Decimal subtotal = Convert.ToDecimal(tbPrecioTotal.Text);
                    subtotal -= _plan.PrecioBonoConsulta;
                    tbPrecioTotal.Text = subtotal.ToString();
                }
                else if(selectedItem as BonoFarmacia != null)
                {
                    Decimal subtotal = Convert.ToDecimal(tbPrecioTotal.Text);
                    subtotal -= _plan.PrecioBonoFarmacia;
                    tbPrecioTotal.Text = subtotal.ToString();
                }

                 
            }
            this.btnComprar.Enabled = (lstBonos.Items.Count > 0);
        }

        private void FrmCompraBonos_Load(object sender, EventArgs e)
        {
            this.tbPrecioTotal.Text = "0";
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            List<BonoConsulta> bonosConsulta = new List<BonoConsulta>();
            foreach (Bono b in lstBonos.Items)
            {
                if (b as BonoConsulta != null)
                {
                    bonosConsulta.Add((BonoConsulta)b);
                }
            }

            List<BonoFarmacia> bonosFarmacia = new List<BonoFarmacia>();
            foreach (Bono b in lstBonos.Items)
            {
                if (b as BonoFarmacia != null)
                {
                    bonosFarmacia.Add((BonoFarmacia)b);
                }
            }
            try
            {
                Decimal subtotal = Convert.ToDecimal(tbPrecioTotal.Text);
                IResultado<Compra> resultado = _compraDomain.Comprar(_afiliado, subtotal, bonosConsulta, bonosFarmacia);
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<Compra>(resultado);

                using (FrmImpresion frm = new FrmImpresion(resultado.Retorno, _afiliado))
                {
                    frm.ShowDialog(this);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
            
        }
    }
}
