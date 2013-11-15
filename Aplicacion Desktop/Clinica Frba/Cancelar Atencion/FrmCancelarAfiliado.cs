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
using GestionDomain;
using GestionGUIHelper.Helpers;
using GestionDomain.Resultados;
using Clinica_Frba.Agendas;
using GestionCommon.Helpers;

namespace Clinica_Frba.Cancelaciones
{
    public partial class FrmCancelarAfiliado : Form
    {
        private CancelacionDomain _domain;
        private Afiliado _afiliado;
        private Turno _turno;
        private TipoCancelacionDomain _tipoCancDomain;

        public FrmCancelarAfiliado(Afiliado af)
            :this()
        {
            _domain = new CancelacionDomain(Program.ContextoActual.Logger);
            this.CargarAfiliado(af);
        }

        private void CargarAfiliado(Afiliado af)
        {
            this._afiliado = af;
            this.btnBuscarAfiliado.Enabled = false;
            this.tbAfiliado.Text = _afiliado.NombreCompleto;
        }

        public FrmCancelarAfiliado()
        {
            _domain = new CancelacionDomain(Program.ContextoActual.Logger);
            _tipoCancDomain = new TipoCancelacionDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void FrmCancelarAfiliado_Load(object sender, EventArgs e)
        {
            try
            {
                IResultado<IList<TipoCancelacion>> resultado = _tipoCancDomain.ObtenerTodos();
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<IList<TipoCancelacion>>(resultado);

                this.cbTipo.DataSource = resultado.Retorno;
                this.cbTipo.DisplayMember = "Nombre";
                this.cbTipo.ValueMember = "IdTipoCancelacion";
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
                frm.ShowDialog(this);
                if (frm.TurnoSeleccionado != null)
                {
                    this._turno = frm.TurnoSeleccionado;
                    this.tbTurno.Text = _turno.ToString();
                    this.cbTipo.Enabled = true;
                    this.tbMotivo.Enabled = true;
                    this.button3.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Cancelacion c = new Cancelacion();
                c.Fecha = FechaHelper.Ahora();
                c.IdTipoCancelacion = ((TipoCancelacion)cbTipo.SelectedItem).IdTipoCancelacion;
                c.IdTurno = _turno.IdTurno;
                c.Motivo = tbMotivo.Text;
                c.CanceladoPor = 'A';

                IResultado<Cancelacion> resultado = _domain.CancelarAfiliado(c);
                if (!resultado.Correcto)
                {
                    throw new ResultadoIncorrectoException<Cancelacion>(resultado);
                }
                MensajePorPantalla.MensajeInformativo(this, "Su turno ha sido cancelado con éxito.");
                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
