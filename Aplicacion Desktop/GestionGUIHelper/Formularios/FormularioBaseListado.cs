﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Helpers;

namespace GestionGUIHelper.Formularios
{
    public partial class FormularioBaseListado : FormularioBase
    {
        public FormularioBaseListado(bool modoSeleccion)
            :base()
        {
            InitializeComponent();
            ModoSeleccion = modoSeleccion;
        }

        public FormularioBaseListado()
            :this(false)
        {
            
        }

        /// <summary>
        /// Permite indicar si se retornara un objeto de la grilla al salir
        /// del formulario.
        /// </summary>
        /// 
        public bool ModoSeleccion { get; set; }
        public object EntidadSeleccionada { get { return Seleccionar(); }}

        #region [FormularioBaseListado_Load]
        private void FormularioBaseListado_Load(object sender, EventArgs e)
        {
            this.btnSeleccionar.Visible = ModoSeleccion;
            this.btnAlta.Visible = !ModoSeleccion;
            this.btnModificacion.Visible = !ModoSeleccion;
            this.btnBaja.Visible = !ModoSeleccion;

            this.AccionIniciar();
            //this.Filtrar();
        }
        #endregion

        #region [btnLimpiar]
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MensajePorPantalla.MensajeInterrogativo(this, "¿Está seguro que desea limpiar los campos?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.AccionLimpiar();
            }
        }

        protected virtual void AccionLimpiar()
        {
            throw new NotImplementedException("Implementar acción del botón Limpiar");
        }
        #endregion

        #region [btnFiltrar]
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.Filtrar();
        }
        protected virtual void Filtrar()
        {
            if (base.Validar())
            {
                this.AccionFiltrar();
                //this.AgregarBotonSeleccionar();
            }
        }

        protected virtual void AccionIniciar()
        {

        }
        protected virtual void AccionFiltrar()
        {
        }

        private void AgregarBotonSeleccionar()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            this.dgvBusqueda.Columns.Add(buttonColumn);
        }
        #endregion

        #region [btnAlta]
        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.AccionAlta();
            this.Filtrar();
        }
        protected virtual void AccionAlta()
        {
            throw new NotImplementedException("Implementar acción del botón Alta");
        }
        #endregion

        #region [btnModificacion]
        private void btnModificacion_Click(object sender, EventArgs e)
        {
            if (this.EntidadSeleccionada == null)
            {
                MensajePorPantalla.MensajeError(this, "Debe seleccionar un registro primero");
            }
            else
            {
                DialogResult dr = MensajePorPantalla.MensajeInformativo(this, "¿Está seguro que desea modificar el registro?", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    this.AccionModificar();
                    this.Filtrar();
                }
            }
        }
        protected virtual void AccionModificar()
        {
            throw new NotImplementedException("Implementar acción del botón Modificar");
        }
        #endregion

        #region [btnBaja]
        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (this.EntidadSeleccionada == null)
            {
                MensajePorPantalla.MensajeError(this, "Debe seleccionar un registro primero");
            }
            else
            {
                DialogResult dr = MensajePorPantalla.MensajeInformativo(this, "¿Está seguro que desea borrar el registro?", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    this.AccionBorrar();
                    MensajePorPantalla.MensajeInformativo(this, "El registro ha sido borrado");
                    this.Filtrar();
                }
            }
        }
        protected virtual void AccionBorrar()
        {
            throw new NotImplementedException("Implementar acción del botón Borrar");
        }
        #endregion

        protected virtual object Seleccionar()
        {
            object seleccionado = null;

            if (dgvBusqueda.SelectedRows.Count > 0)
            {
                seleccionado = dgvBusqueda.SelectedRows[0].DataBoundItem;
            }

            return seleccionado;
        }
        protected virtual void Salir()
        {
            Seleccionar();
            this.Close();
        }

        private void FormularioBaseListado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Salir();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.Seleccionar();
            this.Close();
        }
        

    }
}
