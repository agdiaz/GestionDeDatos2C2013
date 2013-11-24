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
using GestionGUIHelper.Helpers;
using Clinica_Frba.Profesionales;
using GestionCommon.Entidades;
using GestionDomain;
using GestionDomain.Resultados;

namespace Clinica_Frba.Agendas
{
    public partial class FrmAgendaAlta : FormularioBaseAlta
    {
        #region Atributos
        private AgendaDomain _agendaDomain;
        #endregion

        #region Constructor
        public FrmAgendaAlta()
        {
            _agendaDomain = new AgendaDomain(Program.ContextoActual.Logger);

            InitializeComponent();
        }
        #endregion

        #region Load
        private void FrmAgendaAlta_Load(object sender, EventArgs e)
        {
            //this.AccionLimpiar();
            this.AgregarValidacion(new ValidadorString(tbProfesional, 1, 255));
            this.AgregarValidacion(new ValidadorCombobox(cbDia));
            this.dpFechaDesde.Value = FechaHelper.Ahora();
            this.dpFechaHasta.Value = FechaHelper.Ahora();
            this.dpExcepcion.Value = FechaHelper.Ahora();
            this.CargarDiasSemana();
            this.gbDatosAgenda.Enabled = true;
            this.gbDetalleDiario.Enabled = false;
            this.gbExcepciones.Enabled = false;
            this.btnGuardar.Enabled = false;
        }

        private void CargarDiasSemana()
        {
            ListaDiaSemana diasSemana = new ListaDiaSemana();
            this.cbDia.DataSource = diasSemana.Todos;
            this.cbDia.DisplayMember = "Nombre";
            this.cbDia.ValueMember = "Id";
        }
        #endregion

        #region BtnAgregarDia
        private void AgregarDia_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validarCargaHorarioDia())
                {
                    this.agregarDiaACronograma();
                }
            }
            catch (Exception)
            {
                MensajePorPantalla.MensajeError(this, "Ocurrió un error al cargar el día.");
            }
        }

        private void agregarDiaACronograma()
        {
            DiaSemana diaSemana = new DiaSemana();
            DiaSemana diaSeleccionado = cbDia.SelectedItem as DiaSemana;
            diaSemana.Id = diaSeleccionado.Id;
            diaSemana.Nombre = diaSeleccionado.Nombre;
            diaSemana.HoraDesde = new DateTime(2013, 1, 1, (int)nudDesde.Value, (int)nudDesdeMinuto.Value, 0);
            diaSemana.HoraHasta = new DateTime(2013, 1, 1, (int)nudHasta.Value, (int)nudHastaMinuto.Value, 0);
            listCronograma.Items.Add(diaSemana);

            this.actualizarTotalHoras();            
        }

        private void actualizarTotalHoras()
        {
            double totalHorasSemanales = 0;
            foreach (DiaSemana dia in listCronograma.Items)
            {
                TimeSpan th = new TimeSpan(dia.HoraHasta.Hour, dia.HoraHasta.Minute, 0);
                TimeSpan td = new TimeSpan(dia.HoraDesde.Hour, dia.HoraDesde.Minute, 0);
                totalHorasSemanales += th.Subtract(td).TotalHours;
            }
            tbHorasSemanales.Text = totalHorasSemanales.ToString();
        }

        private Boolean validarCargaHorarioDia()
        {
            Boolean resultado = true;
            DiaSemana diaSeleccionado = cbDia.SelectedItem as DiaSemana;
            
            DateTime horaDesdeSeleccionado = new DateTime(2013, 1, 1, (int)nudDesde.Value, (int)nudDesdeMinuto.Value, 0);
            DateTime horaHastaSeleccionado = new DateTime(2013, 1, 1, (int)nudHasta.Value, (int)nudHastaMinuto.Value, 0);
            if (horaDesdeSeleccionado == horaHastaSeleccionado)
            {
                resultado = false;
                MensajePorPantalla.MensajeError(this, "No puede cargar la misma hora de inicio que de finalización");
                return resultado;
            }
            if (horaDesdeSeleccionado < diaSeleccionado.HoraDesdeLimite)
            {
                resultado = false;
                MensajePorPantalla.MensajeError(this, string.Format("La hora de inicio debe ser mayor o igual que {0}", FechaHelper.Format(diaSeleccionado.HoraDesdeLimite, FechaHelper.TimeFormat)));
                return resultado;
            }

            if (horaHastaSeleccionado > diaSeleccionado.HoraHastaLimite)
            {
                resultado = false;
                MensajePorPantalla.MensajeError(this, string.Format("La hora de finalización debe ser menor o igual que {0}", FechaHelper.Format(diaSeleccionado.HoraHastaLimite, FechaHelper.TimeFormat)));
                return resultado;
            }

            if (horaDesdeSeleccionado > horaHastaSeleccionado)
            {
                resultado = false;
                MensajePorPantalla.MensajeError(this, "La hora de inicio debe ser menor que la hora de finalización");
                return resultado;
            }

            if (horaHastaSeleccionado < horaDesdeSeleccionado)
            {
                resultado = false;
                MensajePorPantalla.MensajeError(this, "La hora de finalización debe ser mayor que la hora de inicio");
                return resultado;
            }

            List<DiaSemana> otrosDias = listCronograma.Items.Cast<DiaSemana>().Where( s => s.Id == diaSeleccionado.Id).ToList();
            foreach (DiaSemana otro in otrosDias)
            {
                if (horaDesdeSeleccionado >= otro.HoraDesde && horaDesdeSeleccionado <= otro.HoraHasta)
                {
                    MensajePorPantalla.MensajeError(this, "Ya existe un horario para ese día en esas horas. Revise la hora de inicio");
                    resultado = false;
                    return resultado;
                }
                if (horaHastaSeleccionado <= otro.HoraHasta && horaHastaSeleccionado >= otro.HoraDesde)
                {
                    MensajePorPantalla.MensajeError(this, "Ya existe un horario para ese día en esas horas. Revise la hora de finalización");
                    resultado = false;
                    return resultado;
                }
                
            }
           
            return resultado;
        }
        #endregion
        
        #region BtnQuitarDia
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
        #endregion
        
        #region BtnBuscar Profesional
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
                tbProfesional.Text = profesional.NombreCompleto;
                tbProfesional.Tag = profesional;
            }
        }
        #endregion
        
        #region BtnGuardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        protected override void AccionAceptar()
        {
            Agenda nuevaAgenda = this.CrearAgenda();
            IList<DiaAgenda> diasAgenda = this.ObtenerCronograma();
            IList<FechaExcepcion> excepciones = this.listExcepciones.Items.Cast<FechaExcepcion>().ToList();
            
            try
            {
                IResultado<Agenda> resAgenda = _agendaDomain.Alta(nuevaAgenda, diasAgenda, excepciones);

                if (!resAgenda.Correcto)
                    throw new ResultadoIncorrectoException<Agenda>(resAgenda);

                MensajePorPantalla.MensajeInformativo(this, string.Format("Se dió de alta la agenda: (IdAgenda: {0})", nuevaAgenda.Id.ToString()));
                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
                this.Close();
            }
        }
        private IList<DiaAgenda> ObtenerCronograma()
        {
            IList<DiaAgenda> retorno = new List<DiaAgenda>(this.listCronograma.Items.Count);

            foreach (DiaSemana diaSemana in this.listCronograma.Items.Cast<DiaSemana>())
            {
                DiaAgenda diaAgenda = new DiaAgenda();

                diaAgenda.NroDiaSemana = diaSemana.Id;
                diaAgenda.NombreDiaSemana = diaSemana.Nombre;

                diaAgenda.HoraDesde = diaSemana.HoraDesde.Hour;
                diaAgenda.MinutoDesde = diaSemana.HoraDesde.Minute;

                diaAgenda.HoraHasta = diaSemana.HoraHasta.Hour;
                diaAgenda.MinutoHasta = diaSemana.HoraHasta.Minute;

                retorno.Add(diaAgenda);
            }
            return retorno;
        }

        private Agenda CrearAgenda()
        {
            Agenda nuevaAgenda = new Agenda();
            Profesional profesional = tbProfesional.Tag as Profesional;

            nuevaAgenda.IdProfesional = profesional.IdProfesional;
            nuevaAgenda.FechaDesde = dpFechaDesde.Value;
            nuevaAgenda.FechaHasta = dpFechaHasta.Value;

            return nuevaAgenda;
        }

        #endregion
        
        #region Dias y horas
        private void cbDia_SelectedValueChanged(object sender, EventArgs e)
        {
            DiaSemana dia = cbDia.SelectedItem as DiaSemana;
            if (dia != null)
            {
                nudDesde.Minimum = dia.HoraDesdeLimite.Hour;
                nudDesde.Maximum = dia.HoraHastaLimite.Hour;
                nudDesde.Value = dia.HoraDesdeLimite.Hour;

                nudHasta.Minimum = dia.HoraDesdeLimite.Hour;
                nudHasta.Maximum = dia.HoraHastaLimite.Hour;
                nudHasta.Value = nudHasta.Maximum;
            }
        }

        private void nudDesdeMinuto_ValueChanged(object sender, EventArgs e)
        {
            nudHastaMinuto.Value = nudDesdeMinuto.Value;
        }

        private void nudHastaMinuto_ValueChanged(object sender, EventArgs e)
        {
            nudDesdeMinuto.Value = nudHastaMinuto.Value;
        }
        #endregion

        #region btnCargarDetalles
        private void btnCargarDetalles_Click(object sender, EventArgs e)
        {

            if (dpFechaDesde.Value >= dpFechaHasta.Value)
            {
                MensajePorPantalla.MensajeError(this, "La fecha de inicio no puede ser mayor ni igual que la fecha de fin");
            }
            else if (dpFechaHasta.Value <= dpFechaDesde.Value)
            {
                MensajePorPantalla.MensajeError(this, "La fecha de fin no puede ser menor ni igual que la fecha de inicio");
            }
            else if (validacionFechas(dpFechaDesde, dpFechaHasta))
            {
                this.gbDatosAgenda.Enabled = false;
                this.gbDetalleDiario.Enabled = true;
                this.dpExcepcion.Value = dpFechaDesde.Value;
                this.dpExcepcion.MinDate = dpFechaDesde.Value;
                this.dpExcepcion.MaxDate = dpFechaHasta.Value;
            }

        }
        private bool validacionFechas(DateTimePicker dpFechaDesde, DateTimePicker dpFechaHasta)
        {
            bool resultado = new ValidadorDateTimeFrom(dpFechaDesde, FechaHelper.Ahora()).Validar()
                            & new ValidadorDateTimeUntil(dpFechaHasta, dpFechaDesde.Value.AddDays(120)).Validar()
                            & new ValidadorDateTimeFrom(dpFechaHasta, dpFechaDesde.Value).Validar();
            return resultado;
        }
        #endregion
        
        #region btnCargarExc
        
        private void btnCargarExc_Click(object sender, EventArgs e)
        {
            bool cronogramaEstaVacio = this.validarCronogramaEstaVacio(listCronograma);
            double horas_semanales = Convert.ToDouble(tbHorasSemanales.Text);
            
            if (cronogramaEstaVacio){
                MensajePorPantalla.MensajeInformativo(this, "Agregue días al cronograma.");
            }
            else if (horas_semanales > 48)
            {
                MensajePorPantalla.MensajeInformativo(this, "El total de horas laborales no debe pasar las 48hs.\nModifique el cronograma adecuadamente.");
            }
            else
            {
                this.gbDetalleDiario.Enabled = false;
                this.gbExcepciones.Enabled = true;
            }
        }
        private bool validarCronogramaEstaVacio(ListBox listCronograma)
        {
            return listCronograma.Items.Count == 0 ? true : false;
        }
        #endregion

        #region BtnExcepciones
        private void btnAgregarExc_Click(object sender, EventArgs e)
        {
            FechaExcepcion fechaExcepcion = new FechaExcepcion(dpExcepcion.Value);
            
            List<FechaExcepcion> otras = listExcepciones.Items.Cast<FechaExcepcion>().ToList();
            if (otras.Count(d => fechaExcepcion.Equals(d)) > 0)
            {
                MensajePorPantalla.MensajeError(this, "No se puede cargar esa fecha porque ya se encuentra cargada");
            }
            else
            {
                List<int> diasSemanaElegidos = listCronograma.Items.Cast<DiaSemana>().Select(d => d.Id).ToList();
                if (diasSemanaElegidos.Count(d => d == (int)fechaExcepcion.Dia.DayOfWeek) == 0)
                {
                    MensajePorPantalla.MensajeError(this, "Está intentando cargar una excepción a un día que no tiene horas cargadas");
                }
                else
                {
                    listExcepciones.Items.Add(fechaExcepcion);
                }
            }
        }

        private void btnQuitarExc_Click(object sender, EventArgs e)
        {
            if (listExcepciones.SelectedItems.Count > 0)
            {
                var item = listExcepciones.SelectedItem as FechaExcepcion;
                if (item != null)
                    listExcepciones.Items.Remove(item);
            }
        }
        #endregion

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.btnGuardar.Enabled = true;
            this.gbExcepciones.Enabled = false;
        }
    }
}
