using System;
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
        public FormularioBaseListado()
            :base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Permite indicar si se retornara un objeto de la grilla al salir
        /// del formulario.
        /// </summary>
        /// 
        public bool ModoSeleccion { get; set; }
        public object EntidadSeleccionada { get { return Seleccionar(); }}

        
        protected virtual object Seleccionar()
        {
            object seleccionado = null;
            
            if (dgvBusqueda.SelectedRows.Count > 0)
            {
                seleccionado = dgvBusqueda.SelectedRows[0].DataBoundItem;
            }

            return seleccionado;
        }

        #region [btnLimpiar]
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.AccionLimpiar();
        }

        protected void AccionLimpiar()
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
            }
        }
        protected virtual void AccionFiltrar()
        {
            throw new NotImplementedException("Implementar acción del botón Limpiar");
        }
        #endregion

        #region [btnAlta]
        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.AccionAlta();
        }
        protected virtual void AccionAlta()
        {
            throw new NotImplementedException("Implementar acción del botón Alta");
        }
        #endregion

        #region [btnModificacion]
        private void btnModificacion_Click(object sender, EventArgs e)
        {
            this.Modificar();
        }
        protected void Modificar()
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
                    this.AccionModificar();
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
            this.Borrar();
        }
        protected void Borrar()
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
                }
            }
        }
        protected virtual void AccionBorrar()
        {
            throw new NotImplementedException("Implementar acción del botón Borrar");
        }
        #endregion

        protected virtual void Salir()
        {
            this.Close();
        }

        private void FormularioBaseListado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Salir();
            }
        }

        
    }
}
