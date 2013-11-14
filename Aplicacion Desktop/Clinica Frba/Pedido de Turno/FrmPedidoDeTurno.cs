using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionCommon.Entidades;
using Clinica_Frba.Afiliados;
using GestionCommon.Enums;
using Clinica_Frba.Profesionales;
using GestionCommon.Helpers;
using GestionGUIHelper.Helpers;
using GestionDomain.Resultados;
using GestionDomain;
using Clinica_Frba.Agendas;

namespace Clinica_Frba.PedidosDeTurno
{
    public partial class FrmPedidoDeTurno : Form
    {
        private Afiliado _afiliado;
        private Profesional _profesional;
        private Turno _turno;

        private TurnoDomain _domain;

        public FrmPedidoDeTurno(Afiliado af)
            :this()
        {
            this.CargarAfiliado(af);
        }
        public FrmPedidoDeTurno()
        {
            _domain = new TurnoDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }
        
        #region [Buscar afiliado]
        private void btnBuscarAfiliado_Click(object sender, EventArgs e)
        {
            using (FrmAfiliadoListado frm = new FrmAfiliadoListado(true))
            {
                frm.ShowDialog(this);
                if (frm.EntidadSeleccionada as Afiliado != null)
                {
                    this.CargarAfiliado((Afiliado)frm.EntidadSeleccionada);
                }
            }
        }

        private void CargarAfiliado(Afiliado afiliado)
        {
            this._afiliado = afiliado;
            this.tbAfiliado.Text = afiliado.NombreCompleto;
            this.gbBusquedaHorario.Enabled = true;
            this.btnBuscarAfiliado.Enabled = false;
        }
        #endregion 
        
        #region [Buscar profesional]
        
        
        #endregion

        #region [Load]
        private void FrmPedidoDeTurno_Load(object sender, EventArgs e)
        {
        }

        #endregion
        #region [Filtrar]
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.btnAceptar.Enabled = true;
        }
        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
         try
            {
                _turno.IdAfiliado = _afiliado.IdAfiliado;
                IResultado<bool> resultado = _domain.RegistrarTurno(_turno);
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<bool>(resultado);

                MensajePorPantalla.MensajeInformativo(this, "Se realizo pedido de turno con éxito");
                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        private void gbBusquedaHorario_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscarTurno_Click(object sender, EventArgs e)
        {
            using (FrmAgendaConsultar frm = new FrmAgendaConsultar(2))
            {
                frm.ShowDialog(this);

                if (frm.TurnoSeleccionado != null)
                {
                    this._turno = frm.TurnoSeleccionado;
                    this.textBox1.Text = _turno.ToString();
                    this.btnAceptar.Enabled = true;
                }

            }
        }

    }
}
