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
using Clinica_Frba.Especialidades;
using GestionGUIHelper.Helpers;
using GestionCommon.Enums;

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
            try
            {
                Profesional prof = this.ObtenerProfesional();
                IResultado<Profesional> resultado = _profesionalDomain.Crear(prof);

                foreach (Especialidad especialidad in lstEspecialidades.Items.Cast<Especialidad>())
                {
                    _profesionalDomain.AsociarProfesionalEspecialidad(prof, especialidad);
                }
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(ex.Message);
            }
        }

        private Profesional ObtenerProfesional()
        {
            Profesional profesional = new Profesional();
            profesional.Apellido = tbApellido.Text;
            profesional.Nombre = tbNombre.Text;
            profesional.Direccion = tbDireccion.Text;
            profesional.Dni = Convert.ToDecimal(tbNroDocumento.Text);
            profesional.FechaNacimiento = dpFechaNacimiento.Value;
            profesional.Mail = tbMail.Text;
            profesional.Matricula = Convert.ToDecimal(tbMatriculaProfesional.Text);
            profesional.Sexo = ((Sexo)cbSexo.SelectedItem);
            profesional.Telefono = Convert.ToDecimal(tbTelefono.Text);
            profesional.TipoDni = ((TipoDocumento)cbTipoDocumento.SelectedItem);

            return profesional;
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

            dpFechaNacimiento.Value = FechaHelper.Ahora();

            //foreach (int i in clbEspecialidades.CheckedIndices)
            //{
            //    clbEspecialidades.SetItemCheckState(i, CheckState.Unchecked);
            //}
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

            this.CargarCombo();

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

        }

        private void CargarCombo()
        {
            var sexos = new ListaSexo().Todos;
            cbSexo.DataSource = sexos;
            cbSexo.DisplayMember = "Nombre";
            cbSexo.ValueMember = "Id";

            var tipoDocs = new ListaTipoDocumento().Todos;
            cbTipoDocumento.DataSource = tipoDocs;
            cbTipoDocumento.DisplayMember = "Nombre";
            cbTipoDocumento.ValueMember = "Id";

        
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Especialidad esp = null;
            using (FrmEspecialidadListado frm = new FrmEspecialidadListado(true))
            {
                frm.ShowDialog(this);
                esp = frm.EntidadSeleccionada as Especialidad;
            }
            if (esp != null)
            {
                lstEspecialidades.Items.Add(esp);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            Especialidad esp = null;

            esp = lstEspecialidades.SelectedItem as Especialidad;
            if (esp != null)
            {
                lstEspecialidades.Items.Remove(esp);
            }
        }
    }
}
