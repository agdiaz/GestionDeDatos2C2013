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
using Clinica_Frba.Especialidades;

namespace Clinica_Frba.Profesionales
{
    public partial class FrmProfesionalModificar : FormularioBaseModificacion
    {
        private ProfesionalDomain _profesionalDomain;
        private EspecialidadDomain _especialidadDomain;

        private Profesional _profesional;

        public FrmProfesionalModificar(Profesional profesional)
            : base()
        {
            _profesionalDomain = new ProfesionalDomain(Program.ContextoActual.Logger);
            _especialidadDomain = new EspecialidadDomain(Program.ContextoActual.Logger);

            _profesional = profesional;

            InitializeComponent();
        }


        protected override void AccionAceptar()
        {
            try
            {
                Profesional prof = this.ObtenerProfesional();
                IResultado<Profesional> resultado = _profesionalDomain.Modificar(prof);
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<Profesional>(resultado);

                var resultadoLimpiarEspecialidades = _profesionalDomain.LimpiarEspecialidades(prof);
                if (!resultadoLimpiarEspecialidades.Correcto)
                    throw new ResultadoIncorrectoException<bool>(resultadoLimpiarEspecialidades);

                foreach (Especialidad especialidad in lstEspecialidades.Items.Cast<Especialidad>())
                {
                    var resultadoAsociar = _profesionalDomain.AsociarProfesionalEspecialidad(prof, especialidad);
                    throw new ResultadoIncorrectoException<bool>(resultadoAsociar);
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
            profesional.IdProfesional = _profesional.IdProfesional;
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
            try
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

                IResultado<IList<Especialidad>> resultadoEspecialidades = _especialidadDomain.ObtenerPorProfesional(this._profesional);
                if (!resultadoEspecialidades.Correcto)
                    throw new ResultadoIncorrectoException<IList<Especialidad>>(resultadoEspecialidades);
                
                foreach (Especialidad esp in resultadoEspecialidades.Retorno)
                {
                    lstEspecialidades.Items.Add(esp);
                }
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(ex.Message);
            }
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

        }
    }
}
