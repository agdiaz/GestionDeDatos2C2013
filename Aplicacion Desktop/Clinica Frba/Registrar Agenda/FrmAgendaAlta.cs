﻿using System;
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
using GestionGUIHelper.Helpers;
using Clinica_Frba.Profesionales;
using GestionCommon.Entidades;

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

        private void AgregarDia_Click(object sender, EventArgs e)
        {
            if (this.validarCargaHorarioDia())
            {
                this.agregarDiaACronograma();
            }
        }

        private void agregarDiaACronograma()
        {
            DiaSemana diaSemana = new DiaSemana();
            DiaSemana diaSeleccionado = cbDia.SelectedItem as DiaSemana;
            diaSemana.Id = diaSeleccionado.Id;
            diaSemana.Nombre = diaSeleccionado.Nombre;
            diaSemana.HoraDesde = new DateTime(2013, 1, 1, (int)nudDesde.Value, 0, 0);
            diaSemana.HoraHasta = new DateTime(2013, 1, 1, (int)nudHasta.Value, 0, 0);
            listCronograma.Items.Add(diaSemana);

            this.actualizarTotalHoras();
        }

        private void actualizarTotalHoras()
        {
            int totalHorasSemanales = 0;
            foreach (DiaSemana dia in listCronograma.Items)
            {
                totalHorasSemanales += dia.HoraHasta.Hour - dia.HoraDesde.Hour;
            }
            tbHorasSemanales.Text = totalHorasSemanales.ToString();
        }

        private Boolean validarCargaHorarioDia()
        {
            Boolean resultado = true;
            DiaSemana diaSeleccionado = cbDia.SelectedItem as DiaSemana;
            int horaDesdeSeleccionado = new DateTime(2013, 1, 1, (int)nudDesde.Value, 0, 0).Hour;
            int horaHastaSeleccionado = new DateTime(2013, 1, 1, (int)nudHasta.Value, 0, 0).Hour;

            if(diaSeleccionado.HoraDesdeLimite.Hour > horaDesdeSeleccionado ||
                diaSeleccionado.HoraHastaLimite.Hour < horaHastaSeleccionado){
                    MensajePorPantalla.MensajeInformativo(this,"Carga de horario incorrecta.\nHorario dia "
                        +diaSeleccionado.Nombre+" de "+diaSeleccionado.HoraDesdeLimite.Hour+"hs a "+diaSeleccionado.HoraHastaLimite.Hour+"hs.");
                    resultado = false;
                }
            else if ((int)nudDesde.Value >= (int)nudHasta.Value)
            {
                MensajePorPantalla.MensajeError(this, "Carga de horarios incorrecta.");
                resultado = false;
            }

            return resultado;
        }

        private void btnQuitarDia_Click(object sender, EventArgs e)
        {
            DiaSemana dia = null;

            dia = listCronograma.SelectedItem as DiaSemana;
            if (dia != null)
            {
                listCronograma.Items.Remove(dia);
                this.actualizarTotalHoras();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Profesional profesional = null;
            using (FrmProfesionalListado frmProfesional = new FrmProfesionalListado(true))
            {
                frmProfesional.ShowDialog(this);
                profesional = frmProfesional.EntidadSeleccionada as Profesional;
            }
            if (profesional != null)
            {
                tbProfesional.Text = profesional.Nombre;
                tbProfesional.Tag = profesional;
            }
        }

    }
}
