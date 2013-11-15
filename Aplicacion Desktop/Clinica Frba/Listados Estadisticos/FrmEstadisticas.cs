using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionCommon.Filtros;
using GestionDomain;
using GestionDomain.Resultados;
using GestionGUIHelper.Helpers;
using GestionCommon.Entidades;
using GestionCommon.Helpers;

namespace Clinica_Frba.Estadisticas
{
    public partial class FrmEstadisticas : Form
    {
        private EstadisticaDomain _domain;

        public FrmEstadisticas()
        {
            _domain = new EstadisticaDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Semestre semestre = ObtenerSemestre();
            FiltroEstadistica filtro = new FiltroEstadistica();
            filtro.Periodo = semestre;
            try
            {
                Estadistica estadisticaSeleccionada = cbVista.SelectedItem as Estadistica;
                CargarListado(filtro, estadisticaSeleccionada);
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
            

        }

        private void CargarListado(FiltroEstadistica filtro, Estadistica estadisticaSeleccionada)
        {
            if (estadisticaSeleccionada != null)
            {
                if (estadisticaSeleccionada.IdEstadistica == 1)
                {
                    IResultado<IList<TopCancelacionesProfesionales>> resultado = _domain.ObtenerTopCancelacionesProfesionales(filtro);
                    if (!resultado.Correcto)
                        throw new ResultadoIncorrectoException<IList<TopCancelacionesProfesionales>>(resultado);

                    dgvResultado.DataSource = resultado.Retorno;

                }
                else if (estadisticaSeleccionada.IdEstadistica == 2)
                {
                    IResultado<IList<TopBonosFarmaciaVencidosPorAfiliado>> resultado = _domain.ObtenerTopBonosFarmaciaVencidosPorAfiliado(filtro);
                    if (!resultado.Correcto)
                        throw new ResultadoIncorrectoException<IList<TopBonosFarmaciaVencidosPorAfiliado>>(resultado);

                    dgvResultado.DataSource = resultado.Retorno;

                }
                else if (estadisticaSeleccionada.IdEstadistica == 3)
                {
                    IResultado<IList<TopEspecialidadesBonosFarmaciaRecetados>> resultado = _domain.ObtenerTopEspecialidadesBonosFarmaciaVencidos(filtro);
                    if (!resultado.Correcto)
                        throw new ResultadoIncorrectoException<IList<TopEspecialidadesBonosFarmaciaRecetados>>(resultado);

                    dgvResultado.DataSource = resultado.Retorno;

                }
                else if (estadisticaSeleccionada.IdEstadistica == 4)
                {
                    IResultado<IList<TopAfiliadosConBonosSinComprarPorEllos>> resultado = _domain.ObtenerTopAfiliadosConBonosSinComprarPorEllos(filtro);
                    if (!resultado.Correcto)
                        throw new ResultadoIncorrectoException<IList<TopAfiliadosConBonosSinComprarPorEllos>>(resultado);

                    dgvResultado.DataSource = resultado.Retorno;

                }
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            Semestre semestre = ObtenerSemestre();
            lblSemestre.Text = semestre.ToString();
        }

        private void FrmEstadisticas_Load(object sender, EventArgs e)
        {
            Semestre semestre = ObtenerSemestre();
            lblSemestre.Text = semestre.ToString();
            this.dtpFecha.Value = FechaHelper.Ahora();

            try
            {
                IResultado<IList<Estadistica>> resultadoObtenerNombres = _domain.ObtenerTodos();
                if (!resultadoObtenerNombres.Correcto)
                    throw new ResultadoIncorrectoException<IList<Estadistica>>(resultadoObtenerNombres);

                IList<Estadistica> vistas = resultadoObtenerNombres.Retorno;
                cbVista.DataSource = vistas;
                cbVista.DisplayMember = "NombreEstadistica";
                cbVista.ValueMember = "IdEstadistica";
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        private Semestre ObtenerSemestre()
        {
            DateTime fechaElegida = dtpFecha.Value;

            int anio = fechaElegida.Year;
            int mes = fechaElegida.Month;

            int mesInicio = (mes < 7) ? 1 : 7;
            DateTime fechaDesde = new DateTime(anio, mesInicio, 1, 0, 0, 0);

            int mesFin = (mes < 7) ? 6 : 12;
            int diaFin = (mes < 7) ? 30 : 31;
            DateTime fechaFin = new DateTime(anio, mesFin, diaFin, 23, 59, 59);

            Semestre semestre = new Semestre();
            semestre.Inicio = fechaDesde;
            semestre.Fin = fechaFin;

            return semestre;
        }

    }
}
