using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;
using GestionCommon.Entidades;
using GestionDomain;
using GestionDomain.Resultados;
using GestionGUIHelper.Helpers;
using GestionGUIHelper.Validaciones;

namespace Clinica_Frba.Roles
{
    public partial class FrmRolListado : FormularioBaseListado
    {
        private RolDomain _rolDomain;

        public FrmRolListado()
            :base()
        {
            _rolDomain = new RolDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }
        protected override void AccionIniciar()
        {
            AccionLimpiar();
            //this.AgregarValidacion(new ValidadorString(tbRol, 1, 255));
            //this.AgregarValidacion(new ValidadorCombobox(cbFuncionalidad));
            this.CargarFuncionalidades();
        }

        private void CargarFuncionalidades()
        {
            FuncionalidadDomain funDomain = new FuncionalidadDomain(Program.ContextoActual.Logger);
            IResultado<IList<Funcionalidad>> funcionalidades = funDomain.ObtenerTodos();
            
            this.cbFuncionalidad.DataSource = funcionalidades.Retorno;
            this.cbFuncionalidad.DisplayMember = "Descripcion";
            this.cbFuncionalidad.ValueMember = "IdFuncionalidad";
        }

        protected override void AccionAlta()
        {
            using (FrmRolAlta frm = new FrmRolAlta())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionModificar()
        {
            Rol seleccionado = this.EntidadSeleccionada as Rol;
            using (FrmRolModificar frm = new FrmRolModificar(seleccionado))
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionFiltrar()
        {
            try
            {
                IResultado<IList<Rol>> obtenerTodos = _rolDomain.ObtenerTodos();
                if (!obtenerTodos.Correcto)
                    throw new ResultadoIncorrectoException<IList<Rol>>(obtenerTodos);

                IList<Rol> roles = obtenerTodos.Retorno;
                dgvBusqueda.DataSource = roles;

            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }            
        }

        protected override void AccionBorrar()
        {
            Rol rol = this.EntidadSeleccionada as Rol;
            try
            {
                IResultado<bool> baja = _rolDomain.Borrar(rol);
                if (!baja.Correcto)
                {
                    throw new ResultadoIncorrectoException<bool>(baja);
                }
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        protected override void AccionLimpiar()
        {
            tbRol.Text = string.Empty;

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {

        }

        private void gbFiltros_Enter(object sender, EventArgs e)
        {

        }

        
    }
}
