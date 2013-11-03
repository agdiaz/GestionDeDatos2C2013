using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;
using GestionDomain;
using GestionCommon.Entidades;
using GestionDomain.Resultados;
using GestionGUIHelper.Helpers;
using GestionCommon.Enums;
using GestionCommon.Helpers;

namespace Clinica_Frba.Profesionales
{
    public partial class FrmProfesionalModificar : FormularioBaseModificacion
    {
        private ProfesionalDomain _profesionalDomain;
        private Profesional _profesional;

        public FrmProfesionalModificar(Profesional profesional)
            : base()
        {
            _profesionalDomain = new ProfesionalDomain(Program.ContextoActual.Logger);
            _profesional = profesional;

            InitializeComponent();
        }


        protected override void AccionAceptar()
        {
            try
            {
                Profesional prof = this.ObtenerProfesional();
                IResultado<Profesional> resultado = _profesionalDomain.Modificar(prof);

                _profesionalDomain.LimpiarEspecialidades(prof);
            
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
        }

        protected override void CargarEntidad()
        {
            tbApellido.Text = _profesional.Apellido;
            tbNombre.Text = _profesional.Nombre;
            tbDireccion.Text = _profesional.Direccion;
            tbNroDocumento.Text = _profesional.Dni.ToString();
            dpFechaNacimiento.Value = _profesional.FechaNacimiento;
            tbMail.Text = _profesional.Mail;
            tbMatriculaProfesional.Text = _profesional.Matricula.ToString();
            tbTelefono.Text = _profesional.Telefono.ToString();
            cbSexo.SelectedItem = _profesional.Sexo;
            cbTipoDocumento.SelectedItem = _profesional.TipoDni;
        }

        private void FrmProfesionalModificar_Load(object sender, EventArgs e)
        {
            ListaSexo sexos = new ListaSexo();
            this.cbSexo.DataSource = sexos.Todos;
            this.cbSexo.DisplayMember = "Nombre";
            this.cbSexo.ValueMember = "Id";

            ListaTipoDocumento documentos = new ListaTipoDocumento();
            this.cbTipoDocumento.DataSource = documentos.Todos;
            this.cbTipoDocumento.DisplayMember = "Nombre";
            this.cbTipoDocumento.ValueMember = "Id";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            base.Limpiar();
        }
    }
}
