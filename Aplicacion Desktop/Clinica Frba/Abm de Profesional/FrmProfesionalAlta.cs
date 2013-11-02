using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;
using GestionCommon.Helpers;
using GestionGUIHelper.Validaciones;
using GestionDomain;
using GestionCommon.Entidades;
using GestionDomain.Resultados;

namespace Clinica_Frba.Profesionales
{
    public partial class FrmProfesionalAlta : FormularioBaseAlta
    {
        private EspecialidadDomain _especialidadDomain;
        private ProfesionalDomain _profesionalDomain;

        public FrmProfesionalAlta()
        {
            _especialidadDomain = new EspecialidadDomain(Program.ContextoActual.Logger);
            _profesionalDomain = new ProfesionalDomain(Program.ContextoActual.Logger);

            InitializeComponent();
        }

        protected override void AccionAceptar()
        {
            base.AccionAceptar();
        }

        protected override void AccionLimpiar()
        {
            tbApellido.Text = string.Empty;
            tbDireccion.Text = string.Empty;
            tbMail.Text = string.Empty;
            tbMatriculaProfesional.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbNroDocumento.Text = string.Empty;
            tbTelefono.Text = string.Empty;

            cbSexo.SelectedIndex = 0;
            cbTipoDocumento.SelectedIndex = 0;

            dpFechaNacimiento.Value = FechaHelper.Ahora();

            foreach (int i in clbEspecialidades.CheckedIndices)
            {
                clbEspecialidades.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            base.Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }

        private void FrmProfesionalAlta_Load(object sender, EventArgs e)
        {
            AccionLimpiar();
            this.AgregarValidacion(new ValidadorString(tbNombre, 1, 255));
            this.AgregarValidacion(new ValidadorString(tbApellido, 1, 255));
            this.AgregarValidacion(new ValidadorCombobox(cbTipoDocumento));
            this.AgregarValidacion(new ValidadorNumerico(tbNroDocumento));
            this.AgregarValidacion(new ValidadorString(tbDireccion, 1, 255));
            this.AgregarValidacion(new ValidadorNumerico(tbTelefono));
            this.AgregarValidacion(new ValidadorString(tbMail, 1, 255));
            this.AgregarValidacion(new ValidadorDateTimeUntil(dpFechaNacimiento, FechaHelper.Ahora()));
            this.AgregarValidacion(new ValidadorCombobox(cbSexo));
            this.AgregarValidacion(new ValidadorNumerico(tbMatriculaProfesional));

            this.CargarEspecialidades();
        }

        private void CargarEspecialidades()
        {
            IResultado<IList<Especialidad>> resultado = _especialidadDomain.ObtenerTodos();

            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<IList<Especialidad>>(resultado);

            clbEspecialidades.DataSource = resultado.Retorno;
            clbEspecialidades.DisplayMember = "Nombre";
            clbEspecialidades.ValueMember = "IdEspecialidad";
            
        }
    }
}
