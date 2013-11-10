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
using GestionCommon.Enums;
using GestionGUIHelper.Helpers;

namespace Clinica_Frba.Afiliados
{
    public partial class FrmAfiliadoListado : FormularioBaseListado
    {
        AfiliadoDomain _domain = new AfiliadoDomain(Program.ContextoActual.Logger);
        public FrmAfiliadoListado()
            : this(false) { }
        
        public FrmAfiliadoListado(bool modoSeleccion)
            :base(modoSeleccion)
        {
            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            using (FrmAfiliadoAlta frm = new FrmAfiliadoAlta(true))
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionModificar()
        {
            try
            {
                Afiliado a = this.EntidadSeleccionada as Afiliado;
                using (FrmAfiliadoModificar frm = new FrmAfiliadoModificar(a))
                {
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        protected override void AccionBorrar()
        {
            try
            {
                var afiliado = EntidadSeleccionada as Afiliado;
                IResultado<bool> resultado = _domain.Borrar(afiliado);
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<bool>(resultado);

                this.Filtrar();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        protected override void AccionFiltrar()
        {
            try
            {
                FiltroAfiliado filtro = ObtenerFiltro();

                IResultado<IList<Afiliado>> resultado = _domain.Filtrar(filtro);

                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<IList<Afiliado>>(resultado);

                this.dgvBusqueda.DataSource = resultado.Retorno;
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
               
            }
        }

        private FiltroAfiliado ObtenerFiltro()
        {
            FiltroAfiliado filtro = new FiltroAfiliado();
            if(!string.IsNullOrEmpty(tbNroPrincipal.Text))
                filtro.NroPrincipal = Convert.ToDecimal(tbNroPrincipal.Text);

            if (!string.IsNullOrEmpty(tbNroSecundario.Text))
                filtro.NroSecundario = Convert.ToDecimal(tbNroSecundario.Text);
            
            filtro.Nombre = tbNombre.Text;
            filtro.Apellido = tbApellido.Text;
            filtro.Direccion = tbDireccion.Text;

            if (!string.IsNullOrEmpty(tbTelefono.Text))
                filtro.Telefono = Convert.ToDecimal(tbTelefono.Text);
            
            filtro.Mail = tbMail.Text;

            if (!string.IsNullOrEmpty(tbPlanMedico.Text))
                filtro.IdPlanMedico = (tbPlanMedico.Tag as PlanMedico).IdPlan;

            if (!string.IsNullOrEmpty(tbDocumento.Text))
                filtro.Documento = Convert.ToDecimal(tbDocumento.Text);

            if (chSexo.Checked)
            {
                filtro.IdSexo = (Sexo)cbSexo.SelectedItem;
            }

            if (chEstadoCivil.Checked)
            {
                filtro.IdEstadoCivil = (EstadoCivil)cbEstadoCivil.SelectedItem;
            }

            if (chFechaNac.Checked)
            {
                filtro.FechaNacimiento = dtpFechaNac.Value;
            }

            if (chTipoDoc.Checked)
            {
                filtro.IdTipoDocumento = (TipoDocumento)cbTipoDoc.SelectedItem;
            }

            return filtro;
        }

        protected override void AccionIniciar()
        {
            this.CargarCombos();   
        }

        protected override void AccionLimpiar()
        {
            tbNroPrincipal.Text = string.Empty;
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
            this.AgregarValidacion(new ValidadorNumerico(tbNroPrincipal));
            this.AgregarValidacion(new ValidadorCombobox(cbTipoDoc));
            this.AgregarValidacion(new ValidadorNumerico(tbPlanMedico));
            this.AgregarValidacion(new ValidadorString(tbNombre, 1, 255));
            this.AgregarValidacion(new ValidadorString(tbApellido, 1, 255));

            this.CargarCombos();
        }

        private void CargarCombos()
        {
            var sexos = new ListaSexo();
            cbSexo.DataSource = sexos.Todos;
            cbSexo.DisplayMember = "Nombre";
            cbSexo.ValueMember = "Id";

            var estadosCiviles = new ListaEstadoCivil();
            cbEstadoCivil.DataSource = estadosCiviles.Todos;
            cbEstadoCivil.DisplayMember = "Nombre";
            cbEstadoCivil.ValueMember = "Id";

            var tipoDocumentos = new ListaTipoDocumento();
            cbTipoDoc.DataSource = tipoDocumentos.Todos;
            cbTipoDoc.DisplayMember = "Nombre";
            cbTipoDoc.ValueMember = "Id";

        }

        private void btnBuscarPlanMedico_Click(object sender, EventArgs e)
        {
            using (FrmPlanListado frm = new FrmPlanListado(true) )
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

        private void gbBusqueda_Enter(object sender, EventArgs e)
        {

        }

        private void cbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
