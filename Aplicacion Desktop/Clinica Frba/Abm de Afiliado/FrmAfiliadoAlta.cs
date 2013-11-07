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
using GestionCommon.Helpers;
using GestionGUIHelper.Validaciones;
using GestionCommon.Entidades;
using GestionCommon.Enums;
using GestionDomain;
using GestionDomain.Resultados;
using Clinica_Frba.Planes;

namespace Clinica_Frba.Afiliados
{
    public partial class FrmAfiliadoAlta : FormularioBaseAlta
    {
        #region [Atributos privados]
        private bool _primeraVez;
        private PlanMedico _plan;
        private Afiliado _afiliadoAnterior;
        private AfiliadoDomain _domain;
        #endregion

        #region [Constructor]
        public FrmAfiliadoAlta(Afiliado afiliado)
            :this(false)
        {
            _afiliadoAnterior = afiliado;
        }

        public FrmAfiliadoAlta(bool primeraVez)
            :base()
        {
            _primeraVez = primeraVez;
            _afiliadoAnterior = null;
            _domain = new AfiliadoDomain(Program.ContextoActual.Logger);

            InitializeComponent();
        }
        #endregion

        #region AccionAceptar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        protected override void AccionAceptar()
        {
            Afiliado afiliado = this.ObtenerAfiliado();
            if (_primeraVez)
            {
                try
                {
                    AltaAfiliado(afiliado);
                    AltaDelGrupoFamiliar(afiliado);
                    this.Cancelar();
                }
                catch (Exception ex)
                {
                    MensajePorPantalla.MensajeError(ex.Message);
                }
            }
            else
            {
                try
                {
                    AltaAfiliado(afiliado);
                    this.Cancelar();
                }
                catch (Exception ex)
                {
                    MensajePorPantalla.MensajeError(ex.Message);
                }
            }
        }

        private void AltaAfiliado(Afiliado afiliado)
        {
            if (!_primeraVez && this._afiliadoAnterior != null)
            {
                afiliado.NroPrincipal = _afiliadoAnterior.NroPrincipal;
            }

            IResultado<Afiliado> resultadoCrear = _domain.Crear(afiliado);
            if (!resultadoCrear.Correcto)
                throw new ResultadoIncorrectoException<Afiliado>(resultadoCrear);

            afiliado = resultadoCrear.Retorno;
        }

        private void AltaDelGrupoFamiliar(Afiliado afiliado)
        {
            if (afiliado.TienePareja)
            {
                DialogResult registraPareja = MensajePorPantalla.MensajeInterrogativo(this, "¿Desea registrar a su pareja?", MessageBoxButtons.YesNo);
                if (registraPareja == DialogResult.Yes)
                {
                    using (FrmAfiliadoAlta frmAltaPareja = new FrmAfiliadoAlta(afiliado))
                    {
                        frmAltaPareja.ShowDialog(this);
                    }
                }
            }

            if (afiliado.CantidadHijos > 0)
            {
                DialogResult registraPareja = MensajePorPantalla.MensajeInterrogativo(this, "¿Desea registrar a sus hijos?", MessageBoxButtons.YesNo);
                for (int hijo = 0; (registraPareja == DialogResult.Yes) && (hijo < afiliado.CantidadHijos); hijo++)
                {
                    using (FrmAfiliadoAlta frmAltaHijo = new FrmAfiliadoAlta(afiliado))
                    {
                        frmAltaHijo.ShowDialog(this);
                    }
                }
            }
        }
        
        private Afiliado ObtenerAfiliado()
        {
            Afiliado afiliado = new Afiliado();

            afiliado.Apellido = tbApellido.Text;
            afiliado.Direccion = tbDireccion.Text;
            afiliado.Documento = Convert.ToDecimal(tbNroDocumento.Text);
            afiliado.EstadoCivil = (EstadoCivil)cbEstadoCivil.SelectedItem;
            afiliado.FechaNacimiento = dpFechaNacimiento.Value;
            afiliado.IdPlanMedico = (_plan != null) ? _plan.IdPlan : 0;
            afiliado.Mail = tbMail.Text;
            afiliado.Nombre = tbNombre.Text;
            afiliado.Sexo = (Sexo)cbSexo.SelectedItem;
            afiliado.Telefono = Convert.ToDecimal(tbTelefono.Text);
            afiliado.TipoDocumento = (TipoDocumento)cbTipoDocumento.SelectedItem;
            afiliado.CantidadHijos = (int)ndCantHijos.Value;
            return afiliado;
        }
        #endregion

        #region AccionLimpiar
        protected override void AccionLimpiar()
        {
            tbApellido.Text = string.Empty;
            ndCantHijos.Value = 0;
            tbDireccion.Text = string.Empty;
            tbMail.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbNroAfiliado.Text = string.Empty;
            tbNroDocumento.Text = string.Empty;
            tbTelefono.Text = string.Empty;
            cbTipoDocumento.SelectedIndex = 0;
            dpFechaNacimiento.Value = FechaHelper.Ahora();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            base.Limpiar();
        }
        #endregion

        #region AccionCancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion

        #region AccionIniciar
        private void FrmAfiliadoAlta_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorString(tbNombre, 1, 255));
            this.AgregarValidacion(new ValidadorString(tbApellido, 1, 255));
            this.AgregarValidacion(new ValidadorCombobox(cbTipoDocumento));
            this.AgregarValidacion(new ValidadorNumerico(tbNroDocumento));
            this.AgregarValidacion(new ValidadorDateTimeUntil(dpFechaNacimiento,FechaHelper.Ahora()));
            this.AgregarValidacion(new ValidadorString(tbDireccion, 1, 255));
            this.AgregarValidacion(new ValidadorNumerico(tbTelefono));
            this.AgregarValidacion(new ValidadorString(tbMail,1 ,255));
            this.AgregarValidacion(new ValidadorMail(tbMail));

            this.CargarCombos();

            if (_afiliadoAnterior != null)
            {
                tbApellido.Text = _afiliadoAnterior.Apellido;
                tbDireccion.Text = _afiliadoAnterior.Direccion;
                tbTelefono.Text = _afiliadoAnterior.Telefono.ToString();
                cbEstadoCivil.SelectedItem = (_afiliadoAnterior.TienePareja) ? _afiliadoAnterior.EstadoCivil : new Soltero();
            }
        }

        private void CargarCombos()
        {
            ListaSexo sexos = new ListaSexo();
            cbSexo.DataSource = sexos.Todos;
            cbSexo.DisplayMember = "Nombre";
            cbSexo.ValueMember = "Id";

            ListaEstadoCivil estados = new ListaEstadoCivil();
            cbEstadoCivil.DataSource = estados.Todos;
            cbEstadoCivil.DisplayMember = "Nombre";
            cbEstadoCivil.ValueMember = "Id";

            ListaTipoDocumento documentos = new ListaTipoDocumento();
            cbTipoDocumento.DataSource = documentos.Todos;
            cbTipoDocumento.DisplayMember = "Nombre";
            cbTipoDocumento.ValueMember = "Id";

        }
        #endregion

        private void btnBuscarPlan_Click(object sender, EventArgs e)
        {
            PlanMedico plan = null;
            using (FrmPlanListado frm = new FrmPlanListado(true))
            {
                frm.ShowDialog(this);
                plan = frm.EntidadSeleccionada as PlanMedico;
            }

            if (plan != null)
            {
                _plan = plan;
                this.tbPlanMedico.Text = _plan.Descripcion;
            }
        }

    }
}
