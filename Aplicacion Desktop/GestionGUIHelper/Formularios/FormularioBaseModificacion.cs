using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Helpers;

namespace GestionGUIHelper.Formularios
{
    public partial class FormularioBaseModificacion : FormularioBase
    {
        #region [Constructor]
        public FormularioBaseModificacion() : 
            base() 
        {
            InitializeComponent();
        }
        #endregion

        #region [FormularioBaseModificacion_Load]
        private void FormularioBaseModificacion_Load(object sender, EventArgs e)
        {
            this.CargarEntidad();
        }
        
        /// <summary>
        /// Carga en la pantalla los datos de la entidad poniendo sus propiedades en los campos correspondientes
        /// </summary>
        protected virtual void CargarEntidad()
        {
            MensajePorPantalla.MensajeInformativo(this, "Implementar CargarEntidad");
        }
        #endregion

        #region [Aceptar]
        protected virtual void Aceptar()
        {
            DialogResult dr = MensajePorPantalla.MensajeInformativo(this, "¿Confirma la modificación del registro?", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                if (base.Validar())
                {
                    this.AccionAceptar();
                }
            }

        }
        /// <summary>
        /// Acción que se dispara desde el botón Aceptar luego de validar todos los campos.
        /// </summary>
        protected virtual void AccionAceptar()
        {
            throw new NotImplementedException("Debe implementar la acción aceptar");
        }
        #endregion

        #region [Cancelar]
        protected virtual void Cancelar()
        {
            DialogResult result = MensajePorPantalla.MensajeInterrogativo(this, "Sus cambios no han sido guardados ¿Está seguro que desea cancelar?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region [Limpiar]
        protected void Limpiar()
        {
            DialogResult result = MensajePorPantalla.MensajeInterrogativo(this, "¿Está seguro que desea limpiar los campos?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.AccionLimpiar();
            }
        }

        protected virtual void AccionLimpiar()
        {
            throw new NotImplementedException("Implementar AcciónLimpiar");
        }
        #endregion

        private void FormularioBaseModificacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cancelar();
        }
    }
}
