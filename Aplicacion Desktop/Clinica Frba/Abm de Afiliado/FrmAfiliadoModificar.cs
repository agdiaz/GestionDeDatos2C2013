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
using GestionCommon.Helpers;
using GestionCommon.Enums;
using GestionCommon.Entidades;
using GestionDomain;
using GestionDomain.Resultados;
using GestionGUIHelper.Helpers;
using Clinica_Frba.Planes;

namespace Clinica_Frba.Afiliados
{
    public partial class FrmAfiliadoModificar : FormularioBaseModificacion
    {
        #region Atributos
        private AfiliadoDomain _afiliadoDomain;
        private PlanMedicoDomain _planMedicoDomain;
        private PlanMedico _plan;
        public Afiliado AfiliadoModificado { get; private set; }
        #endregion

        #region Constructor
        public FrmAfiliadoModificar(Afiliado afiliadoModificado)
            :base()
        {
            AfiliadoModificado = afiliadoModificado;
            _afiliadoDomain = new AfiliadoDomain(Program.ContextoActual.Logger);
            _planMedicoDomain = new PlanMedicoDomain(Program.ContextoActual.Logger);

            InitializeComponent();

            this.CargarCombos();
        }
        #endregion
        
        #region Accion Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.AccionLimpiar();
        }

        protected override void AccionLimpiar()
        {
            this.CargarEntidad();
        }
        #endregion
        
        #region Accion Iniciar
        private void FrmAfiliadoModificar_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorString(tbNombre, 1, 255));
            this.AgregarValidacion(new ValidadorString(tbApellido, 1, 255));
            this.AgregarValidacion(new ValidadorCombobox(cbTipoDocumento));
            this.AgregarValidacion(new ValidadorNumerico(tbNroDocumento));
            this.AgregarValidacion(new ValidadorDateTimeUntil(dpFechaNacimiento, FechaHelper.Ahora()));
            this.AgregarValidacion(new ValidadorString(tbDireccion, 1, 255));
            this.AgregarValidacion(new ValidadorNumerico(tbTelefono));
            this.AgregarValidacion(new ValidadorString(tbMail, 1, 255));
            this.AgregarValidacion(new ValidadorMail(tbMail));
            this.dpFechaNacimiento.Value = FechaHelper.Ahora();
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

        protected override void CargarEntidad()
        {
            try
            {
                this.tbApellido.Text = AfiliadoModificado.Apellido;
                this.tbDireccion.Text = AfiliadoModificado.Direccion;
                this.tbMail.Text = AfiliadoModificado.Mail;
                this.tbNombre.Text = AfiliadoModificado.Nombre;
                this.tbNroAfiliado.Text = AfiliadoModificado.NroAfiliado.ToString();
                this.tbNroAfiliado.Enabled = false;
                this.tbNroDocumento.Text = AfiliadoModificado.Documento.ToString();
                this.tbNroDocumento.Enabled = false;
                IResultado<PlanMedico> resObtener = _planMedicoDomain.Obtener(AfiliadoModificado.IdPlanMedico);
                if (!resObtener.Correcto)
                    throw new ResultadoIncorrectoException<PlanMedico>(resObtener);
                _plan = resObtener.Retorno;

                this.tbPlanMedico.Text = _plan.Descripcion;
                this.tbTelefono.Text = AfiliadoModificado.Telefono.ToString();
                this.cbEstadoCivil.SelectedItem = AfiliadoModificado.EstadoCivil;
                this.cbSexo.SelectedItem = AfiliadoModificado.Sexo;
                this.cbTipoDocumento.SelectedItem = AfiliadoModificado.TipoDocumento;
                this.cbTipoDocumento.Enabled = false;
                this.dpFechaNacimiento.Value = AfiliadoModificado.FechaNacimiento;
                this.ndCantHijos.Visible = false;
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
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
        
        #region Accion Aceptar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.AccionAceptar();
        }
        protected override void AccionAceptar()
        {
            Afiliado modificado = this.ObtenerAfiliado();
            try
            {
                IResultado<Afiliado> resultado = _afiliadoDomain.Modificar(modificado);
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<Afiliado>(resultado);

                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        private Afiliado ObtenerAfiliado()
        {
            Afiliado afiliado = new Afiliado();
            
            afiliado.IdAfiliado = this.AfiliadoModificado.IdAfiliado;
            afiliado.Apellido = tbApellido.Text;
            afiliado.Direccion = tbDireccion.Text;
            afiliado.EstadoCivil = (EstadoCivil)cbEstadoCivil.SelectedItem;
            afiliado.FechaNacimiento = dpFechaNacimiento.Value;
            afiliado.IdPlanMedico = _plan.IdPlan;
            afiliado.Mail = tbMail.Text;
            afiliado.Nombre = tbNombre.Text;
            afiliado.NroPrincipal = AfiliadoModificado.NroPrincipal;
            afiliado.NroSecundario = AfiliadoModificado.NroSecundario;
            afiliado.Sexo = (Sexo)cbSexo.SelectedItem;
            afiliado.Telefono = Convert.ToDecimal(tbTelefono.Text);
            afiliado.TipoDocumento = (TipoDocumento)cbTipoDocumento.SelectedItem;
            afiliado.Documento = Convert.ToDecimal(tbNroDocumento.Text);
            
            return afiliado;
        }
        #endregion

        #region Accion Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
        #endregion

    } 
}
