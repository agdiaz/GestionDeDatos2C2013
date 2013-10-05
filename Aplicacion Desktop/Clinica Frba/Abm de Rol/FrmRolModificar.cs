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
using GestionCommon.Entidades;
using GestionDomain;
using GestionDomain.Resultados;

namespace Clinica_Frba.Roles
{
    public partial class FrmRolModificar : FormularioBaseModificacion
    {
        #region [Atributos]
        private RolDomain _rolDomain;
        private FuncionalidadDomain _funcionalidadDomain;
        private Rol _rol;
        #endregion 

        public FrmRolModificar(Rol rol)
            :base()
        {
            _rol = rol;
            _rolDomain = new RolDomain(Program.ContextoActual.Logger);
            _funcionalidadDomain = new FuncionalidadDomain(Program.ContextoActual.Logger);

            InitializeComponent();
        }
        
        #region [FrmRolModificar_Load]
        private void FrmRolModificar_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorString(tbNombre, 1, 50));
            CargarListaFuncionalidades();
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
                this.clsFuncionalidades.DisplayMember = "Nombre";
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
            Rol rolModificado = this.CrearRol();
            IList<Funcionalidad> funcionalidades = this.ObtenerFuncionalidades();

            try
            {
                IResultado<Rol> resModificacion = _rolDomain.Modificar(rolModificado, funcionalidades);

                if (!resModificacion.Correcto)
                    throw new ResultadoIncorrectoException<Rol>(resModificacion);

                MensajePorPantalla.MensajeInformativo(this, string.Format("Se modificó el rol: {0} (IdRol: {1})", _rol.Nombre, _rol.IdRol.ToString()));
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
            nuevoRol.IdRol = _rol.IdRol;
            nuevoRol.Nombre = tbNombre.Text;
            nuevoRol.Habilitado = this.chkHabilitado.Checked;

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
            this.LimpiarControles();
        }

        private void LimpiarControles()
        {
            this.tbNombre.Text = string.Empty;
            this.chkHabilitado.Checked = false;

            foreach (int i in clsFuncionalidades.CheckedIndices)
            {
                clsFuncionalidades.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        #endregion



    }
}
