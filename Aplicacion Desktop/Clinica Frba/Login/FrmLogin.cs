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

        private Boolean control_mas_de_un_rol;
        private Boolean elegir_un_rol;

        #endregion
        
        #region [Propiedades]
        public Usuario UsuarioIniciado { get; private set; }
        public Rol RolUsuario { get; private set; }
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
            //this.AgregarValidacion(new ValidadorCombobox(cbRol));

            //this.FrmLogin_Load_CargarListaRoles();
        }

        //private void FrmLogin_Load_CargarListaRoles()
        //{
        //    RolDomain rolDomain = new RolDomain(Program.ContextoActual.Logger);
        //    IList<Rol> roles = rolDomain.ObtenerTodos().Retorno;
        //    this.cbRol.DataSource = roles;
        //    this.cbRol.DisplayMember = "Nombre";
        //    this.cbRol.ValueMember = "Id";

        //    this.control_mas_de_un_rol = true;
        //    this.elegir_un_rol = true;
        //}
        #endregion
        
        #region [btnAceptar]
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.AccionAceptar();
        }
        protected override void AccionAceptar()
        {
            try
            {
                if (IdentificarUsuario())
                {
                    IList<Rol> roles_usuario = _usuarioDomain.ObtenerRoles(tbUsuario.Text).Retorno;
                    
                    if (roles_usuario.Count > 1 && elegir_un_rol)
                    {
                        this.tbUsuario.Enabled = false;
                        this.tbPassword.Enabled = false;
                        this.lblRol.Visible = true;
                        this.cbRol.Visible = true;
                        this.cbRol.DataSource = roles_usuario;
                        this.cbRol.SelectedIndex = 0;
                        
                        MensajePorPantalla.MensajeInformativo(this, "Seleccione un rol");
                        elegir_un_rol = false;
                    }
                    else if (roles_usuario.Count > 1 && !elegir_un_rol)
                    {
                        this.RolUsuario = (Rol)this.cbRol.SelectedItem;
                        this.ObtenerUsuario();
                    } 
                    else 
                    {
                        this.RolUsuario = roles_usuario.First();
                        this.ObtenerUsuario();
                    }
                }

            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
                this.LimpiarCampos();
            }
        }

        private bool IdentificarUsuario()
        {
            IResultado<IdentificacionUsuario> resRealizarIdenticacion = _usuarioDomain.RealizarIdentificacion(tbUsuario.Text, tbPassword.Text);
            if (!resRealizarIdenticacion.Correcto)
                throw new ResultadoIncorrectoException<IdentificacionUsuario>(resRealizarIdenticacion);

            IdentificacionUsuario identificacion = resRealizarIdenticacion.Retorno;

            if (PasswordHelper.IdentificacionExitosa(identificacion))
            {
                return true;
            }
            else
            {
                MensajePorPantalla.MensajeError(this, PasswordHelper.Mensaje(resRealizarIdenticacion.Retorno));
                return false;
            }
        }

        private void LimpiarCampos()
        {
            this.tbPassword.Text = string.Empty;
            this.tbUsuario.Text = string.Empty;
        }

        private void ObtenerUsuario()
        {
            IResultado<Usuario> resultado = _usuarioDomain.ObtenerSegunNombreUsuario(tbUsuario.Text);
            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<Usuario>(resultado);

            this.UsuarioIniciado = resultado.Retorno;
            this.Close();
        }
        #endregion

        #region [btnCancelar]
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        protected override void Cancelar()
        {
            this.Close();
        }
        #endregion
    }
}
