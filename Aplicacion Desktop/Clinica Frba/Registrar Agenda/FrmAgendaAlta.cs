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
using GestionCommon.Helpers;
using GestionCommon.Enums;

namespace Clinica_Frba.Agenda
{
    public partial class FrmAgendaAlta : FormularioBaseAlta

    {
        public FrmAgendaAlta()
        {
            InitializeComponent();
        }

        private void FrmAgendaAlta_Load(object sender, EventArgs e)
        {
            //this.AccionLimpiar();
            this.AgregarValidacion(new ValidadorString(tbProfesional, 1, 255));
            this.AgregarValidacion(new ValidadorDateTimeFrom(dpFechaDesde, FechaHelper.Ahora()));
            this.AgregarValidacion(new ValidadorDateTimeFrom(dpFechaHasta,dpFechaDesde.Value));
            this.AgregarValidacion(new ValidadorDateTimeUntil(dpFechaHasta,dpFechaDesde.Value.AddDays(120)));
            this.AgregarValidacion(new ValidadorCombobox(cbDia));
            this.AgregarValidacion(new ValidadorNumerico(tbHorasSemanales));

            this.CargarDiasSemana();
        }

        private void CargarDiasSemana()
        {
            ListaDiaSemana diasSemana = new ListaDiaSemana();
            this.cbDia.DataSource = diasSemana.Todos;
            this.cbDia.DisplayMember = "Nombre";
            this.cbDia.ValueMember = "Id";
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
