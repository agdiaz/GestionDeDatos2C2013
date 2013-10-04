using System;
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
using Clinica_Frba.Agenda;
using Clinica_Frba.Planes;
using Clinica_Frba.Cancelaciones;

namespace Clinica_Frba
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        #region [frmPrincipal_Load]
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.frmPrincipal_Load_CargarBarraEstado();
        }

        private void frmPrincipal_Load_CargarBarraEstado()
        {
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
            using (FrmLogin frm = new FrmLogin())
            {
                frm.ShowDialog(this);
            }
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
            MensajePorPantalla.MensajeInformativo(this, "Sesión cerrada con éxito");
        }
        #endregion

        #region [estadísticasToolStripMenuItem]
        private void estadísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmEstadisticas frm = new FrmEstadisticas())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion
        #endregion

        #region [Menu Gestión de usuarios]
        #region [tsmUsuarios]
        private void tsmUsuarios_Click(object sender, EventArgs e)
        {
            using (FrmUsuarioListado frm = new FrmUsuarioListado())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region [tsmRoles]
        private void tsmRoles_Click(object sender, EventArgs e)
        {
            using (FrmRolListado frm = new FrmRolListado())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion
        #endregion

        #region [Menu Gestión de afiliados]
        #region [tsmAfiliados]
        private void tsmAfiliados_Click(object sender, EventArgs e)
        {
            using (FrmAfiliadoListado frm = new FrmAfiliadoListado())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region [tsmCompraDeBonos]
        private void tsmCompraDeBonos_Click(object sender, EventArgs e)
        {
            using (FrmCompraBonos frm = new FrmCompraBonos())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region [tsmPedirTurno]
        private void tsmPedirTurno_Click(object sender, EventArgs e)
        {
            using (FrmPedidoDeTurno frm = new FrmPedidoDeTurno())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region [tsmRegistroDeLlegada]
        private void tsmRegistroDeLlegada_Click(object sender, EventArgs e)
        {
            using (FrmRegistroDeLlegada frm = new FrmRegistroDeLlegada())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region [tsmRegistroDeResultados]
        private void tsmRegistroDeResultados_Click(object sender, EventArgs e)
        {
            using (FrmRegistroDeResultado frm = new FrmRegistroDeResultado())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region [tsmRecetar]
        private void tsmRecetar_Click(object sender, EventArgs e)
        {
            using (FrmRecetaAlta frm = new FrmRecetaAlta())
            {
                frm.ShowDialog();
            }
        }
        #endregion

        #endregion

        #region [Gestión de profesionales]
        #region [tsmProfesionales]
        private void tsmProfesionales_Click(object sender, EventArgs e)
        {
            using (FrmProfesionalListado frm = new FrmProfesionalListado())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region [tsmEspecialidades]
        private void tsmEspecialidades_Click(object sender, EventArgs e)
        {
            using (FrmEspecialidadListado frm = new FrmEspecialidadListado())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region [tsmAgenda_Registrar]
        private void tsmAgenda_Registrar_Click(object sender, EventArgs e)
        {
            using (FrmAgendaAlta frm = new FrmAgendaAlta())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region [tsmAgenda_Consultar]
        private void tsmAgenda_Consultar_Click(object sender, EventArgs e)
        {
            using (FrmAgendaConsultar frm = new FrmAgendaConsultar())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #endregion

        #region [Gestión de planes]
        private void tsmPlanes_Click(object sender, EventArgs e)
        {
            using (FrmPlanListado frm = new FrmPlanListado())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region [Cancelaciones]

        #region [tsmCancelacionAfiliado]
        private void tsmCancelacionAfiliado_Click(object sender, EventArgs e)
        {
            using (FrmCancelarAfiliado frm = new FrmCancelarAfiliado())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion
        
        #region [tsmCancelacionProfesional]
        private void tsmCancelacionProfesional_Click(object sender, EventArgs e)
        {
            using (FrmCancelarProfesional frm = new FrmCancelarProfesional())
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #endregion
    }
}
