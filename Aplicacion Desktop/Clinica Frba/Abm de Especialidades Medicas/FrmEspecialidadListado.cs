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

namespace Clinica_Frba.Especialidades
{
    public partial class FrmEspecialidadListado : FormularioBaseListado
    {
        private EspecialidadDomain _domain;
        private TipoEspecialidadDomain _tipoEspecialidadDomain;

        public FrmEspecialidadListado()
            :base()
        {
            _domain = new EspecialidadDomain(Program.ContextoActual.Logger);
            _tipoEspecialidadDomain = new TipoEspecialidadDomain(Program.ContextoActual.Logger);

            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            using (FrmEspecialidadesAlta frm = new FrmEspecialidadesAlta())
            {
                frm.ShowDialog();
            }
        }

        protected override void AccionModificar()
        {
            using (FrmEspecialidadModificar frm = new FrmEspecialidadModificar())
            {
                frm.ShowDialog();
            }
        }

        protected override void AccionBorrar()
        {
            MensajePorPantalla.MensajeInformativo(this, "No se implementa");
        }

        private void FrmEspecialidadListado_Load(object sender, EventArgs e)
        {
            AccionLimpiar();
            //this.AgregarValidacion(new ValidadorString(tbNombreEspecialidad, 1, 255));
            //this.AgregarValidacion(new ValidadorCombobox(cbTipoEspecialidad)); 
        }

        protected override void AccionFiltrar()
        {
            FiltroEspecialidad filtro = CrearFiltro();

            try
            {
                IResultado<IList<Especialidad>> filtrar = _domain.Filtrar(filtro);
                if (!filtrar.Correcto)
                    throw new ResultadoIncorrectoException<IList<Especialidad>>(filtrar);

                this.dgvBusqueda.DataSource = filtrar.Retorno;
            }
            catch (ResultadoIncorrectoException<IList<Especialidad>> ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        private FiltroEspecialidad CrearFiltro()
        {
            FiltroEspecialidad filtro = new FiltroEspecialidad();
            var tipo = cbTipoEspecialidad.SelectedItem as TipoEspecialidad;
            if (tipo != null)
            {
                filtro.IdTipoEspecialidad = tipo.Id;
            }

            if (!string.IsNullOrEmpty(tbNombreEspecialidad.Text))
            {
                filtro.Nombre = tbNombreEspecialidad.Text;
            }
            return filtro;
        }

        protected override void AccionIniciar()
        {
            try
            {
                IResultado<IList<TipoEspecialidad>> obtenerTodos = _tipoEspecialidadDomain.ObtenerTodos();
                if (!obtenerTodos.Correcto)
                    throw new ResultadoIncorrectoException<IList<TipoEspecialidad>>(obtenerTodos);

                this.cbTipoEspecialidad.DataSource = obtenerTodos.Retorno;
                this.cbTipoEspecialidad.DisplayMember = "Nombre";
                this.cbTipoEspecialidad.ValueMember = "Id";
            }
            catch (ResultadoIncorrectoException<IList<TipoEspecialidad>> ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        protected override void AccionLimpiar()
        {
            this.tbNombreEspecialidad.Text = string.Empty;
        }
    }
}
