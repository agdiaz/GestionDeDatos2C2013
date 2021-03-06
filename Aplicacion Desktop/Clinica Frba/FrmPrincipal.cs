﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Helpers;
using Clinica_Frba.Login;
using Clinica_Frba.Usuarios;
using Clinica_Frba.Roles;
using GestionCommon.Helpers;
using Clinica_Frba.Estadisticas;
using Clinica_Frba.Afiliados;
using Clinica_Frba.Compras;
using Clinica_Frba.PedidosDeTurno;
using Clinica_Frba.RegistrosDeLLegada;
using Clinica_Frba.ResultadosAtencion;
using Clinica_Frba.Recetas;
using Clinica_Frba.Profesionales;
using Clinica_Frba.Especialidades;
using Clinica_Frba.Agendas;
using Clinica_Frba.Planes;
using Clinica_Frba.Cancelaciones;
using GestionDomain;
using GestionDomain.Resultados;
using GestionCommon.Entidades;

namespace Clinica_Frba
{
    public partial class FrmPrincipal : Form
    {
        private AfiliadoDomain _afiliadoDomain;
        private ProfesionalDomain _profesionalDomain;

        public FrmPrincipal()
        {
            _afiliadoDomain = new AfiliadoDomain(Program.ContextoActual.Logger);
            _profesionalDomain = new ProfesionalDomain(Program.ContextoActual.Logger);

            InitializeComponent();
        }

        #region [frmPrincipal_Load]
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //Hack para ocultar los menues hasta que no me logueé:
            frmPrincipal_Load_CargarFuncionalidadesBase(new List<Funcionalidad>());
            this.frmPrincipal_Load_MostrarLogin();           
            this.frmPrincipal_Load_CargarMenues();
            this.frmPrincipal_Load_CargarBarraEstado();
        }

        private void frmPrincipal_Load_CargarMenues()
        {
            //Obtengo el rol del usuario actual:
            if (true)
            {
                //Obtengo las funcionalidades del rol:
                FuncionalidadDomain funcionalidadDomain = new FuncionalidadDomain(Program.ContextoActual.Logger);
                IResultado<IList<Funcionalidad>> resultadoObtenerFuncionalidades = funcionalidadDomain.ObtenerFuncionalidades(Program.ContextoActual.RolActual.Id);

                if (resultadoObtenerFuncionalidades.Correcto)
                {
                    //Cargo las funcionalidades
                    frmPrincipal_Load_CargarFuncionalidadesBase(resultadoObtenerFuncionalidades.Retorno);
                }
            }
        }

        private void frmPrincipal_Load_CargarFuncionalidadesBase(IList<Funcionalidad> funcionalidades)
        {
            foreach (ToolStripItem item in mnuPrincipal.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    item.Enabled = false;
                    item.Visible = false;
                }
                estadísticasToolStripMenuItem.Enabled = false;
                estadísticasToolStripMenuItem.Visible = false;
            }

            if (funcionalidades != null)
            {
                var nombresFuncionalidad = funcionalidades.Select(f => f.Nombre);
                frmPrincipal_Load_CargarFuncionalidades(mnuPrincipal.Items, nombresFuncionalidad);
            }

            this.tsmArchivo.Visible = true;
            this.tsmArchivo.Enabled = true;

            this.tsmSesion.Visible = true;
            this.tsmSesion.Enabled = true;

            this.tsmSalir.Visible = true;
            this.tsmSalir.Enabled = true;

            if (Program.ContextoActual.SesionIniciada)
            {
                this.tsmSesion_CerrarSesion.Enabled = true;
                this.tsmSesion_CerrarSesion.Visible = true;

                this.tsmSesion_IniciarSesion.Enabled = false;
                this.tsmSesion_IniciarSesion.Visible = false;
            }
            else
            {
                this.tsmSesion_CerrarSesion.Enabled = false;
                this.tsmSesion_CerrarSesion.Visible = false;

                this.tsmSesion_IniciarSesion.Enabled = true;
                this.tsmSesion_IniciarSesion.Visible= true;
            }
        }

        private void frmPrincipal_Load_CargarFuncionalidades(ToolStripItemCollection items, IEnumerable<string> nombresFuncionalidad)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem)
                {
                    item.Enabled = nombresFuncionalidad.Contains(item.Name);
                    item.Visible = item.Enabled;
                    frmPrincipal_Load_CargarFuncionalidades(((ToolStripMenuItem)item).DropDown.Items, nombresFuncionalidad);
                }
            }
        }

        private void frmPrincipal_Load_CargarUsuarioGenerico()
        {
            UsuarioDomain usuarioDomain = new UsuarioDomain(Program.ContextoActual.Logger);
            IResultado<Usuario> resultadoObtenerUsuario = usuarioDomain.ObtenerUsuarioGenerico();
            if (resultadoObtenerUsuario.Correcto)
            {
                Program.ContextoActual.RegistrarUsuario(resultadoObtenerUsuario.Retorno);
            }
        }

        private void frmPrincipal_Load_MostrarLogin()
        {
            Usuario usuario = null;
            Rol rol = null;
            using (FrmLogin frm = new FrmLogin())
            {
                frm.ShowDialog(this);
                usuario = frm.UsuarioIniciado;
                rol = frm.RolUsuario;
            }

            if (usuario != null)
            {
                Program.ContextoActual.RegistrarUsuario(usuario);
            }
            if (rol != null)
            {
                Program.ContextoActual.RegistrarRol(rol);
                this.tstNombre.Text = "Sin Afiliado/Profesional asociado al usuario";
                if (rol.Id == 1) //Afiliado
                {
                    try
                    {
                        IResultado<Afiliado> resultadoAfiliado = _afiliadoDomain.ObtenerPorUsuario(usuario);
                        if (!resultadoAfiliado.Correcto)
                            throw new ResultadoIncorrectoException<Afiliado>(resultadoAfiliado);

                        Program.ContextoActual.RegistrarAfiliado(resultadoAfiliado.Retorno);
                        this.tstNombre.Text = "AFILIADO: " + Program.ContextoActual.AfiliadoDelUsuario.NombreCompleto;
                    }
                    catch (Exception ex)
                    {
                        MensajePorPantalla.MensajeError(this, ex.Message);
                    }
                }
                if (rol.Id == 3) //Profesional
                {
                    try
                    {
                        IResultado<Profesional> resultadoProfesional = _profesionalDomain.ObtenerPorUsuario(usuario);
                        if (!resultadoProfesional.Correcto)
                            throw new ResultadoIncorrectoException<Profesional>(resultadoProfesional);

                        Program.ContextoActual.RegistrarProfesional(resultadoProfesional.Retorno);
                        this.tstNombre.Text = "PROFESIONAL: " + Program.ContextoActual.ProfesionalDelUsuario.NombreCompleto;
                    }
                    catch (Exception ex)
                    {
                        MensajePorPantalla.MensajeError(this, ex.Message);
                    }
                }
            }
        }

        private void frmPrincipal_Load_CargarBarraEstado()
        {
            this.lblUsuario.Text = "Usuario: " + Program.ContextoActual.UsuarioActual.Username;
            this.lblLogPath.Text = "Almacenando log en: " + Program.ContextoActual.LogPath;
            this.lblFechaSistema.Text = "Fecha: " + FechaHelper.Format(Program.ContextoActual.FechaActual);
            this.lblConnectionString.Text = "Conectado: " + AppConfigReader.Get("connection_string");
        }

        #endregion

        #region [frmPrincipal_FormClosed]
        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        #endregion

        #region [frmPrincipal_FormClosing]
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MensajePorPantalla.MensajeInterrogativo(this, "¿Está seguro que desea salir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region [Menu Archivo]
        
        #region [tsmSalir]
        private void tsmSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region [tsmSesion_IniciarSesion]
        private void tsmSesion_IniciarSesion_Click(object sender, EventArgs e)
        {
            this.frmPrincipal_Load_MostrarLogin();
            this.frmPrincipal_Load_CargarMenues();
            this.frmPrincipal_Load_CargarBarraEstado();
        }
        #endregion

        #region [tsmSesion_CerrarSesion]
        private void tsmSesion_CerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MensajePorPantalla.MensajeInterrogativo(this, "¿Está seguro que desea cerrar su sesión?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.tsmSesion_CerrarSesion_Aceptado();
            }
        }

        private void tsmSesion_CerrarSesion_Aceptado()
        {
            Program.ContextoActual.DesregistrarUsuario();
            Program.ContextoActual.DesregistrarRol();

            this.frmPrincipal_Load_CargarFuncionalidadesBase(null);
            this.frmPrincipal_Load_CargarBarraEstado();
        }
        #endregion

        #region [estadísticasToolStripMenuItem]
        private void estadísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
	        {
                FrmEstadisticas frm = new FrmEstadisticas();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
    	    }
	        catch (Exception ex)
	        {
                MensajePorPantalla.MensajeError(this, ex.Message);
	        }
        }
        #endregion
        #endregion

        #region [Menu Gestión de usuarios]
        #region [tsmUsuarios]
        private void tsmUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                FrmUsuarioListado frm = new FrmUsuarioListado();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region [tsmRoles]
        private void tsmRoles_Click(object sender, EventArgs e)
        {
            try 
            {
                FrmRolListado frm = new FrmRolListado();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }        
        }
        #endregion
        #endregion

        #region [Menu Gestión de afiliados]
        #region [tsmAfiliados]
        private void tsmAfiliados_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAfiliadoListado frm = new FrmAfiliadoListado();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region [tsmCompraDeBonos]
        private void tsmCompraDeBonos_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCompraBonos frm = (Program.ContextoActual.AfiliadoDelUsuario != null) ? new FrmCompraBonos(Program.ContextoActual.AfiliadoDelUsuario) : new FrmCompraBonos();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region [tsmPedirTurno]
        private void tsmPedirTurno_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPedidoDeTurno frm = (Program.ContextoActual.AfiliadoDelUsuario != null) ? new FrmPedidoDeTurno(Program.ContextoActual.AfiliadoDelUsuario) : new FrmPedidoDeTurno();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region [tsmRegistroDeLlegada]
        private void tsmRegistroDeLlegada_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRegistroDeLlegada frm = new FrmRegistroDeLlegada();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region [tsmRegistroDeResultados]
        private void tsmRegistroDeResultados_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRegistroDeResultado frm = (Program.ContextoActual.ProfesionalDelUsuario != null) ? new FrmRegistroDeResultado(Program.ContextoActual.ProfesionalDelUsuario) : new FrmRegistroDeResultado();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region [tsmRecetar]
        private void tsmRecetar_Click(object sender, EventArgs e)
        {
            try
            {
                //FrmRecetaAlta frm = new FrmRecetaAlta();
                //frm.StartPosition = FormStartPosition.CenterParent;
                //frm.WindowState = FormWindowState.Maximized;
                //frm.MdiParent = this;
                //frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #endregion

        #region [Gestión de profesionales]
        #region [tsmProfesionales]
        private void tsmProfesionales_Click(object sender, EventArgs e)
        {
            try
            {
                FrmProfesionalListado frm = new FrmProfesionalListado();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region [tsmEspecialidades]
        private void tsmEspecialidades_Click(object sender, EventArgs e)
        {
            try
            {
                FrmEspecialidadListado frm = new FrmEspecialidadListado();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region [tsmAgenda_Registrar]
        private void tsmAgenda_Registrar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAgendaAlta frm = new FrmAgendaAlta();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region [tsmAgenda_Consultar]
        private void tsmAgenda_Consultar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAgendaConsultar frm = (Program.ContextoActual.ProfesionalDelUsuario == null) ? new FrmAgendaConsultar(0) : new FrmAgendaConsultar(Program.ContextoActual.ProfesionalDelUsuario, 0);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #endregion

        #region [Gestión de planes]
        private void tsmPlanes_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPlanListado frm = new FrmPlanListado();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region [Cancelaciones]

        #region [tsmCancelacionAfiliado]
        private void tsmCancelacionAfiliado_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCancelarAfiliado frm = (Program.ContextoActual.AfiliadoDelUsuario != null) ? new FrmCancelarAfiliado(Program.ContextoActual.AfiliadoDelUsuario) : new FrmCancelarAfiliado();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion
        
        #region [tsmCancelacionProfesional]
        private void tsmCancelacionProfesional_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCancelarProfesional frm = (Program.ContextoActual.ProfesionalDelUsuario != null) ? new FrmCancelarProfesional(Program.ContextoActual.ProfesionalDelUsuario) : new FrmCancelarProfesional();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
        #endregion

        private void tsmCancelaciones_Profesional_Click(object sender, EventArgs e)
        {

            FrmCancelarProfesional frm = new FrmCancelarProfesional();
            frm.Show();
        }

        #endregion
    }
}
