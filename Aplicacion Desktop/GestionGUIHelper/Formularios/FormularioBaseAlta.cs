﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Helpers;

namespace GestionGUIHelper.Formularios
{
    public class FormularioBaseAlta : FormularioBase
    {
        private bool _cerrado;

        #region [Constructor]
        public FormularioBaseAlta()
            : base()
        {
            _cerrado = false;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormularioBaseAlta
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "FormularioBaseAlta";
            this.ResumeLayout(false);

        }
        #endregion
        
        #region [Aceptar]
        protected virtual void Aceptar()
        {
            DialogResult dr = MensajePorPantalla.MensajeInformativo(this, "¿Confirma la creación del registro?", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                if (base.Validar())
                {
                    this.AccionAceptar();
                }
            }

        }

        protected virtual void AccionAceptar()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region [Cancelar]
        protected virtual void Cancelar()
        {
            DialogResult result = MensajePorPantalla.MensajeInterrogativo(this, "Sus cambios no han sido guardados ¿Está seguro que desea cancelar?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _cerrado = true;
                this.Close();
            }
            else
            {
                _cerrado = false;
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

    }
}
