using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;
using GestionGUIHelper.Validaciones;
using GestionGUIHelper.Helpers;
using GestionDomain;
using GestionCommon.Entidades;
using GestionDomain.Resultados;

namespace Clinica_Frba.Roles
{
    public partial class FrmRolAlta : FormularioBaseAlta
    {
        private RolDomain _rolDomain;
        private FuncionalidadDomain _funcionalidadDomain;

        public FrmRolAlta()
        {
            _rolDomain = new RolDomain(Program.ContextoActual.Logger);
            _funcionalidadDomain = new FuncionalidadDomain(Program.ContextoActual.Logger);

            InitializeComponent();
        }

        #region [FrmRolAlta_Load]
        private void FrmRolAlta_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorString(tbNombre, 1, 50));
            this.CargarListaFuncionalidades();
        }

        private void CargarListaFuncionalidades()
        {
            try
            {
                IResultado<IList<Funcionalidad>> resObtenerTodos = _funcionalidadDomain.ObtenerTodos();
                if (!resObtenerTodos.Correcto)
                    throw new ResultadoIncorrectoException<IList<Funcionalidad>>(resObtenerTodos);
                
                IList<Funcionalidad> roles = resObtenerTodos.Retorno;
                this.clsFuncionalidades.DataSource = roles;
                this.clsFuncionalidades.DisplayMember = "Descripcion";
                this.clsFuncionalidades.ValueMember = "IdFuncionalidad";

            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
                this.Close();
            }
        }
        
        
        #endregion

        #region [btnAceptar]
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }
        protected override void AccionAceptar()
        {
            Rol nuevoRol = this.CrearRol();
            IList<Funcionalidad> funcionalidades = this.ObtenerFuncionalidades();

            try
            {
                IResultado<Rol> resAlta = _rolDomain.Alta(nuevoRol, funcionalidades);

                if (!resAlta.Correcto)
                    throw new ResultadoIncorrectoException<Rol>(resAlta);

                MensajePorPantalla.MensajeInformativo(this, string.Format("Se dió de alta el rol: {0} (IdRol: {1})", nuevoRol.Nombre, nuevoRol.Id.ToString()));
                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        private IList<Funcionalidad> ObtenerFuncionalidades()
        {
            IList<Funcionalidad> retorno = new List<Funcionalidad>();
            foreach (var f in this.clsFuncionalidades.CheckedItems)
            {
                retorno.Add((Funcionalidad)f);
            }
            return retorno;
        }

        private Rol CrearRol()
        {
            Rol nuevoRol = new Rol();
            
            nuevoRol.Nombre = tbNombre.Text;
            nuevoRol.Activo = this.chkActivo.Checked;
            
            return nuevoRol;
        }
        #endregion
        
        #region [btnCancelar]
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion
        
        #region [btnLimpiar]
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
        private void LimpiarControles()
        {
            this.tbNombre.Text = string.Empty;
            this.chkActivo.Checked = false;

            foreach (int i in clsFuncionalidades.CheckedIndices)
            {
                clsFuncionalidades.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        #endregion
    }
}
