using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionDomain;
using GestionGUIHelper.Helpers;
using GestionDomain.Resultados;
using GestionCommon.Entidades;
using Clinica_Frba.Recetas;
using Clinica_Frba.Agendas;
using Clinica_Frba.Profesionales;
using GestionCommon.Helpers;
using GestionGUIHelper.Formularios;
using GestionGUIHelper.Validaciones;

namespace Clinica_Frba.ResultadosAtencion
{
    public partial class FrmRegistroDeResultado : FormularioBase
    {
        private Profesional _profesional;
        private Afiliado _afiliado;
        private Turno _turno;
        private DateTime _fecha;
        private AfiliadoDomain _afiliadoDomain;
        private TurnoDomain _domain;

        public FrmRegistroDeResultado(Profesional prof)
            :this()
        {
            this.CargarProfesional(prof);
        }

        public FrmRegistroDeResultado()
            :base()
        {
            _afiliadoDomain = new AfiliadoDomain(Program.ContextoActual.Logger);
            _domain = new TurnoDomain(Program.ContextoActual.Logger);
            
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ResultadoTurno rt = this.ObtenerResultadoTurno();
            try
            {
                IResultado<ResultadoTurno> resultado = _domain.RegistrarResultadoTurno(rt);
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<ResultadoTurno>(resultado);
                // Le asigna el id:
                rt.IdResultadoTurno = resultado.Retorno.IdResultadoTurno;

                DialogResult altaReceta = MensajePorPantalla.MensajeInterrogativo(this, "¿Desea hacer recetas?", MessageBoxButtons.YesNo);
                if (altaReceta == DialogResult.Yes)
                {
                    using (FrmRecetaAlta frm = new FrmRecetaAlta(rt, _profesional, _afiliado))
                    {
                        frm.ShowDialog(this);
                    }
                }
                MensajePorPantalla.MensajeInformativo(this, "Resultado de la consulta guardado correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        private ResultadoTurno ObtenerResultadoTurno()
        {
            ResultadoTurno rt = new ResultadoTurno();
            rt.Diagnostico = tbDiagnostico.Text;
            rt.FechaDiagnostico = _fecha;
            rt.IdTurno = _turno.IdTurno;
            rt.Sintoma = tbSintomas.Text;

            return rt;
        }

        private void btnBuscarTurno_Click(object sender, EventArgs e)
        {
            using (FrmAgendaConsultar frm = new FrmAgendaConsultar(_profesional, 3))
            {
                frm.ShowDialog(this);
                if (frm.TurnoSeleccionado != null)
                {
                    this._turno = frm.TurnoSeleccionado;
                }
            }
            if (_turno != null)
            {
                tbTurno.Text = _turno.ToString();
                try
                {
                    IResultado<Afiliado> resultadoAfiliado = _afiliadoDomain.Obtener(_turno.IdAfiliado);
                    if (!resultadoAfiliado.Correcto)
                        throw new ResultadoIncorrectoException<Afiliado>(resultadoAfiliado);

                    _afiliado = resultadoAfiliado.Retorno;
                    tbAfiliado.Text = _afiliado.NombreCompleto;
                    
                    this.dpFecha.Enabled = true;
                    this.dpFecha.Value = _turno.Fecha;
                    this.btnConfirmarHorario.Enabled = true;
                    this.button1.Enabled = true;
                    
                }
                catch (Exception ex)
                {
                    MensajePorPantalla.MensajeError(ex.Message);
                    this.Close();
                }
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
            _profesional = profesional;
            tbProfesional.Text = _profesional.NombreCompleto;
            btnBuscarProfesional.Enabled = false;
            btnBuscarTurno.Enabled = true;
        }

        private void btnConfirmarHorario_Click(object sender, EventArgs e)
        {
            if (dpFecha.Value <= _turno.HoraInicio)
            {
                MensajePorPantalla.MensajeInformativo(this, "Fecha confirmada");
                this.gbResultado.Enabled = true;
                this.btnAceptar.Enabled = true;
            }
            else
            {
                MensajePorPantalla.MensajeError(this, "No se puede atender después del turno");
                this.Close();
            }
        }

        private void FrmRegistroDeResultado_Load(object sender, EventArgs e)
        {
            dpFecha.Value = FechaHelper.Ahora();
            dpFecha.Format = DateTimePickerFormat.Custom;
            dpFecha.CustomFormat = "dd/MM/yyyy, hh:mm";
            this.AgregarValidacion(new ValidadorString(tbDiagnostico, 1, 255));
            this.AgregarValidacion(new ValidadorString(tbSintomas, 1, 255));
            this.btnConfirmarHorario.Enabled = false;
            this.button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirma = MensajePorPantalla.MensajeInterrogativo(this, "¿Confirma que el paciente no llego al turno?", MessageBoxButtons.YesNo);
                if (confirma == DialogResult.Yes)
                {
                    this._fecha = dpFecha.Value;
                    IResultado<Turno> resultado = _domain.RegistrarTurnoNoCorrecto(_turno, _fecha);
                    if (!resultado.Correcto)
                        throw new ResultadoIncorrectoException<Turno>(resultado);

                    MensajePorPantalla.MensajeInformativo(this, "Se ha guardado registro de que el paciente no ha llegado");
                }

            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
            this.Close();
        }
    }
}
