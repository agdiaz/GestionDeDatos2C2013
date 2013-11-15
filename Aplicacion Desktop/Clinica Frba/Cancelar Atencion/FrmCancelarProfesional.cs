using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionCommon.Entidades;
using GestionDomain.Resultados;
using GestionDomain;
using GestionGUIHelper.Helpers;
using GestionCommon.Helpers;
using Clinica_Frba.Profesionales;
using GestionGUIHelper.Validaciones;

namespace Clinica_Frba.Cancelaciones
{
    public partial class FrmCancelarProfesional : Form
    {
        private Profesional _profesional;
        private TipoCancelacionDomain _tipoCancDomain;
        private CancelacionDomain _domain;

        public FrmCancelarProfesional(Profesional prof)
            : this()
        {
            this.CargarProfesional(prof);
        }

        private void CargarProfesional(Profesional prof)
        {
            this._profesional = prof;
            this.textBox1.Text = prof.NombreCompleto;
            this.monthCalendar1.Enabled = true;
            this.cbTipo.Enabled = true;
            this.textBox2.Enabled = true;
            this.button1.Enabled = false;
            this.button3.Enabled = true;
        }
        public FrmCancelarProfesional()
        {
            _domain = new CancelacionDomain(Program.ContextoActual.Logger);
            _tipoCancDomain = new TipoCancelacionDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmCancelarProfesional_Load(object sender, EventArgs e)
        {
            try
            {
                IResultado<IList<TipoCancelacion>> resultado = _tipoCancDomain.ObtenerTodos();
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<IList<TipoCancelacion>>(resultado);

                this.cbTipo.DataSource = resultado.Retorno;
                this.cbTipo.DisplayMember = "Nombre";
                this.cbTipo.ValueMember = "IdTipoCancelacion";

                this.monthCalendar1.SelectionStart = FechaHelper.Ahora();
                this.monthCalendar1.SelectionEnd = FechaHelper.Ahora();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                CancelarTurnos();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        private void CancelarTurnos()
        {
            IValidador vMotivo = new ValidadorString(textBox2, 1, 255);
            if (vMotivo.Validar())
            {
                StringBuilder sb = new StringBuilder("Se cancelaran los siguientes días: ").Append(Environment.NewLine);
                for (DateTime dia = monthCalendar1.SelectionStart; dia <= monthCalendar1.SelectionEnd; dia = dia.AddDays(1))
                {
                    sb.Append(FechaHelper.Format(dia, FechaHelper.DateFormat)).Append(Environment.NewLine);
                }
                DialogResult ds = MensajePorPantalla.MensajeInterrogativo(this, sb.ToString(), MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    for (DateTime dia = monthCalendar1.SelectionStart; dia <= monthCalendar1.SelectionEnd; dia = dia.AddDays(1))
                    {
                        IList<Turno> turnosDelDia = _domain.BuscarTurnos(_profesional.IdProfesional, dia).Retorno;
                        foreach (Turno turno in turnosDelDia)
                        {
                            Cancelacion c = new Cancelacion();
                            c.CanceladoPor = 'P';
                            c.Fecha = FechaHelper.Ahora();
                            c.IdTipoCancelacion = ((TipoCancelacion)cbTipo.SelectedItem).IdTipoCancelacion;
                            c.IdTurno = turno.IdTurno;
                            c.Motivo = textBox2.Text;

                            IResultado<Cancelacion> resultado = _domain.Cancelar(c);
                            if (!resultado.Correcto)
                                throw new ResultadoIncorrectoException<Cancelacion>(resultado);
                        }
                    }
                    MensajePorPantalla.MensajeInformativo(this, "Se han cancelado los turnos");
                    this.Close();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}