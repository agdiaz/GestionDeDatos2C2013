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
using GestionCommon.Enums;
using GestionCommon.Helpers;

namespace Clinica_Frba.Login
{
    public partial class FrmLogin : FormularioBaseAlta
    {
        #region [Atributos]
        private UsuarioDomain _usuarioDomain;
        #endregion
        
        #region [Propiedades]
        public Usuario UsuarioIniciado { get; private set; }
        #endregion

        public FrmLogin(): base()
        {
            this._usuarioDomain = new UsuarioDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }

        #region [FrmLogin_Load]
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorString(tbUsuario, 1, 10));
            this.AgregarValidacion(new ValidadorString(tbPassword, 1, 10));
            this.AgregarValidacion(new ValidadorCombobox(cbRol));

            this.FrmLogin_Load_CargarListaRoles();
        }

        private void FrmLogin_Load_CargarListaRoles()
        {
            RolDomain rolDomain = new RolDomain(Program.ContextoActual.Logger);
            IList<Rol> roles = rolDomain.ObtenerTodos().Retorno;
            this.cbRol.DataSource = roles;
            this.cbRol.DisplayMember = "Nombre";
            this.cbRol.ValueMember = "IdRol";
            this.cbRol.SelectedIndex = 0;

        }
        #endregion
        
        #region [btnAceptar]
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }
        protected override void AccionAceptar()
        {
            try
            {
                IdentificarUsuario();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
                this.LimpiarCampos();
            }
        }

        private void IdentificarUsuario()
        {
            IResultado<IdentificacionUsuario> resRealizarIdenticacion = _usuarioDomain.RealizarIdentificacion(tbUsuario.Text, tbPassword.Text);
            if (!resRealizarIdenticacion.Correcto)
                throw new ResultadoIncorrectoException<IdentificacionUsuario>(resRealizarIdenticacion);

            IdentificacionUsuario identificacion = resRealizarIdenticacion.Retorno;

            if (PasswordHelper.IdentificacionExitosa(identificacion))
            {
                this.ObtenerUsuario();
            }
            else
            {
                this.LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            this.tbPassword.Text = string.Empty;
        }

        private void ObtenerUsuario()
        {
            IResultado<Usuario> resultado = _usuarioDomain.ObtenerSegunNombreUsuario(tbUsuario.Text);
            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<Usuario>(resultado);

            this.UsuarioIniciado = resultado.Retorno;
        }
        #endregion

        #region [btnCancelar]
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion

    }
}
