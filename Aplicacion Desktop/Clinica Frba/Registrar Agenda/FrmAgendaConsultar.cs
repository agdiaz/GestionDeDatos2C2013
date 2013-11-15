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
        private int _opcionGrilla;

        private Profesional _profesional;
        public Afiliado AfiliadoBuscador { get; set; }

        public Turno TurnoSeleccionado { get; private set; }

        public FrmAgendaConsultar(int opcionGrilla)
        {
            _opcionGrilla = opcionGrilla;
            _turnoDomain = new TurnoDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }

        public FrmAgendaConsultar(Profesional profesional, int opcionGrilla)
            : this(opcionGrilla)
        {
            this.CargarProfesional(profesional);
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
                var turnos = resultado.Retorno;
                if (_opcionGrilla == 1)
                {
                    //solo los turnos ya asignados
                    turnos = resultado.Retorno.Where(t => t.Disponible == false).ToList();
                }
                else if (_opcionGrilla == 2)
                {
                    //todos los turnos disponibles
                    turnos = resultado.Retorno.Where(t => t.Disponible == true).ToList();
                }
                else if (_opcionGrilla == 3)
                {
                    //los turnos disponibles que no tienen resultado
                    turnos = resultado.Retorno.Where(t => t.Disponible == true && t.IdResultadoTurno != null).ToList();
                }

                if (AfiliadoBuscador != null)
                {
                    turnos = turnos.Where(t => t.IdAfiliado == AfiliadoBuscador.IdAfiliado).ToList();
                }
                this.dgvTurnos.DataSource = turnos;
                this.dgvTurnos.Columns["IdTurno"].Visible = false;
                this.btnAceptar.Enabled = true;
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
                this.tbProfesional.Text = profesional.NombreCompleto;
                IResultado<FechaTurno> resultado = _turnoDomain.ObtenerFechasParaTurnos(profesional.IdProfesional, FechaHelper.Ahora());
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<FechaTurno>(resultado);
                this.mcDesde.Enabled = true;
                this.btnTurnos.Enabled = true;
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
                t.HoraInicio = this.mcDesde.SelectionStart.Add(td.HoraDesde);
                t.HoraFin = this.mcDesde.SelectionStart.Add(td.HoraHasta);
                t.IdTurno = td.IdTurno; 
                t.NombreProfesional = _profesional.NombreCompleto;
                t.IdAfiliado = td.IdAfiliado;
                
                TurnoSeleccionado = t;
                this.Close();

          
            }
        }
    }
}
