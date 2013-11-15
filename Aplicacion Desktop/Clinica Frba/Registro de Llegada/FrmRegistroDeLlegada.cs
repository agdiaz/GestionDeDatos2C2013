using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionDomain;
using GestionCommon.Entidades;
using GestionDomain.Resultados;
using GestionGUIHelper.Formularios;
using GestionGUIHelper.Helpers;
using GestionCommon.Helpers;
using Clinica_Frba.Agendas;
using Clinica_Frba.Afiliados;

namespace Clinica_Frba.RegistrosDeLLegada
{
    public partial class FrmRegistroDeLlegada : FormularioBase
    {
        private Afiliado _afiliado;
        private Turno _turno;
        private BonoConsulta _bono;

        private CompraDomain _domain;

        public FrmRegistroDeLlegada()
            :base()
        {
            _domain = new CompraDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DateTime ahora = FechaHelper.Ahora();
            if (_turno.HoraInicio.Subtract(ahora).TotalMinutes < 0 )
            {
                this.Registrar();
            }
            else
            {
                MensajePorPantalla.MensajeError(this, "Debería haberse presentado por lo menos 15 minutos antes del comienzo del turno");
            }
        }

        private bool ValidarNroBono()
        {
            try
            {
                IResultado<BonoConsulta> resultado = _domain.ObtenerBonoConsulta(Convert.ToDecimal(this.tbBonoConsulta.Text));
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<BonoConsulta>(resultado);

                return true;
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
                return false;
            }
        }

        private void Registrar()
        {
            try
            {
                decimal idBono = Convert.ToDecimal(this.tbBonoConsulta.Text);
                IResultado<bool> resultado = _domain.RegistrarLlegada(idBono, _turno.IdTurno, FechaHelper.Ahora());
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<bool>(resultado);

                MensajePorPantalla.MensajeInformativo(this, "La llegada al turno ha sido registrada");
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
            
        }

        private void btnBuscarTurno_Click(object sender, EventArgs e)
        {
            using (FrmAgendaConsultar frm = new FrmAgendaConsultar(1))
            {
                frm.AfiliadoBuscador = _afiliado;
                frm.ShowDialog(this);
                if (frm.TurnoSeleccionado != null)
                {
                    this._turno = frm.TurnoSeleccionado;
                    tbTurno.Text = _turno.ToString();
                    btnBuscarTurno.Enabled = false;
                    this.btnValidarBono.Enabled = true;
                }
            }
        }

        private void btnValidarBono_Click(object sender, EventArgs e)
        {
            try
            {
                IResultado<BonoConsulta> resultado = _domain.ValidarBonoConsulta(Convert.ToDecimal(tbBonoConsulta.Text), _afiliado.NroPrincipal, _afiliado.IdPlanMedico);
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<BonoConsulta>(resultado);

                this._bono = resultado.Retorno;
                this.btnValidarBono.Enabled = false;
                this.btnRegistrar.Enabled = true;
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

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
            this.btnBuscarAfiliado.Enabled = false;
            this.tbAfiliado.Text = _afiliado.NombreCompleto;
            this.btnBuscarTurno.Enabled = true;
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
