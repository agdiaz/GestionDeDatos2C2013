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
using Clinica_Frba.Profesionales;
using GestionCommon.Helpers;
using GestionDomain.Resultados;
using GestionGUIHelper.Helpers;

namespace Clinica_Frba.Agendas
{
    public partial class FrmAgendaConsultar : Form
    {
        private TurnoDomain _turnoDomain;

        private Profesional _profesional;
        public Turno TurnoSeleccionado { get; private set; }
        
        public FrmAgendaConsultar()
        {
            _turnoDomain = new TurnoDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }

        public FrmAgendaConsultar(Profesional profesional)
            :this()
        {
            _profesional = profesional;    
        }

        private void FrmAgendaConsultar_Load(object sender, EventArgs e)
        {

        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            try
            {
                IResultado<IList<TurnoDisponible>> resultado = _turnoDomain.ObtenerHorasParaTurno(mcDesde.SelectionRange.Start, _profesional.IdProfesional);
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<IList<TurnoDisponible>>(resultado);

                this.dgvTurnos.DataSource = resultado.Retorno;
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        private void btnBuscarProfesional_Click(object sender, EventArgs e)
        {
            using (FrmProfesionalListado frm = new FrmProfesionalListado(true))
            {
                frm.ShowDialog(this);
                if (frm.EntidadSeleccionada as Profesional != null)
                {
                    this.CargarProfesional((Profesional)frm.EntidadSeleccionada);
                }
            }
        }

        private void CargarProfesional(Profesional profesional)
        {
            try
            {
                this._profesional = profesional;
                IResultado<FechaTurno> resultado = _turnoDomain.ObtenerFechasParaTurnos(profesional.IdProfesional, FechaHelper.Ahora());
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<FechaTurno>(resultado);

                this.mcDesde.MinDate = resultado.Retorno.FechaDesde;
                this.mcDesde.MaxDate = resultado.Retorno.FechaHasta;
                
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.SelectedRows.Count > 0)
            {
                TurnoDisponible td = dgvTurnos.SelectedRows[0].DataBoundItem as TurnoDisponible;
                Turno t = new Turno();
                t.IdProfesional = _profesional.IdProfesional;
                t.Fecha = mcDesde.SelectionRange.Start;
                t.HoraInicio = td.HoraDesde;
                t.HoraFin = td.HoraHasta;
            }
        }
    }
}
