﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;
using Clinica_Frba.Especialidades;
using GestionCommon.Entidades;
using GestionDomain.Resultados;
using GestionDomain;
using GestionCommon.Filtros;
using GestionGUIHelper.Helpers;
using GestionCommon.Enums;

namespace Clinica_Frba.Profesionales
{
    public partial class FrmProfesionalListado : FormularioBaseListado
    {
        private ProfesionalDomain _domain;

        public FrmProfesionalListado()
            :base()
        {
            _domain = new ProfesionalDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }

        public FrmProfesionalListado(bool modoSeleccion)
            : base(modoSeleccion)
        {
            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            using (FrmProfesionalAlta frm = new FrmProfesionalAlta())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionModificar()
        {
            using (FrmProfesionalModificar frm = new FrmProfesionalModificar())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionFiltrar()
        {
            FiltroProfesional filtro = this.ObtenerFiltro();
            try
            {
                IResultado<IList<Profesional>> resultadoFiltrar = _domain.Filtrar(filtro);
                if (!resultadoFiltrar.Correcto)
                    throw new ResultadoIncorrectoException<IList<Profesional>>(resultadoFiltrar);
                
                dgvBusqueda.DataSource = resultadoFiltrar.Retorno;
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(ex.Message);
            }

        }

        protected override void AccionIniciar()
        {
            ListaSexo sexos = new ListaSexo();
            this.cbSexo.DataSource = sexos.Todos;
            this.cbSexo.DisplayMember = "Nombre";
            this.cbSexo.ValueMember = "Id";

            ListaTipoDocumento documentos = new ListaTipoDocumento();
            this.cbTipoDoc.DataSource = documentos.Todos;
            this.cbTipoDoc.DisplayMember = "Nombre";
            this.cbTipoDoc.ValueMember = "Id";

            this.CargarTodosLosProfesionales();
        }

        private void CargarTodosLosProfesionales()
        {
            try
            {
                IResultado<IList<Profesional>> resultado = _domain.ObtenerTodos();
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<IList<Profesional>>(resultado);

                this.dgvBusqueda.DataSource = resultado.Retorno;
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(ex.Message);
            }
        }
        
        private FiltroProfesional ObtenerFiltro()
        {
            FiltroProfesional filtro = new FiltroProfesional();
            
            filtro.Apellido = tbApellido.Text;
            filtro.Nombre = tbNombre.Text;
            filtro.Direccion = tbDireccion.Text;
            
            if (!string.IsNullOrEmpty(tbDni.Text))
                filtro.Dni = Convert.ToDecimal(tbDni.Text);

            if (!string.IsNullOrEmpty(tbTelefono.Text))
                filtro.Telefono = Convert.ToDecimal(tbTelefono.Text);

            filtro.TipoDni = cbTipoDoc.SelectedValue as string;
            
            if (chFechaNacimiento.Checked)
                filtro.FechaNacimiento = dtpFechaNacimiento.Value;

            if (!string.IsNullOrEmpty(tbEspecialidad.Text))
                filtro.IdTipoEspecialidad = ((TipoEspecialidad)tbEspecialidad.Tag).Id;

            filtro.Mail = tbMail.Text;
            if (!string.IsNullOrEmpty(tbMatricula.Text))
                filtro.Matricula = Convert.ToDecimal(tbMatricula.Text);

            filtro.Sexo = (int)cbSexo.SelectedValue ;

            return filtro;
        }

        private void btnBuscarEspecialidad_Click(object sender, EventArgs e)
        {
            Especialidad especialidad = null;
            using (FrmEspecialidadListado frm = new FrmEspecialidadListado(true))
            {
                frm.ShowDialog(this);
                especialidad = frm.EntidadSeleccionada as Especialidad;
            }

            if (especialidad != null)
            {
                tbEspecialidad.Text = especialidad.Nombre;
                tbEspecialidad.Tag = especialidad;
            }
        }
    }
}
