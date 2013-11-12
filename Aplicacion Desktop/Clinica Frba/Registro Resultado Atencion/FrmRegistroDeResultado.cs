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

namespace Clinica_Frba.ResultadosAtencion
{
    public partial class FrmRegistroDeResultado : Form
    {
        private Profesional _profesional;
        private Afiliado _afiliado;
        private Turno _turno;
        private DateTime _fecha;
        private AfiliadoDomain _afiliadoDomain;
        private TurnoDomain _domain;

        public FrmRegistroDeResultado()
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
                IResultado<bool> resultado = _domain.RegistrarResultadoTurno(rt);
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<bool>(resultado);

                DialogResult altaReceta = MensajePorPantalla.MensajeInterrogativo(this, "¿Desea hacer recetas?", MessageBoxButtons.YesNo);
                if (altaReceta == DialogResult.Yes)
                {
                    using (FrmRecetaAlta frm = new FrmRecetaAlta(_afiliado))
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
            using (FrmAgendaConsultar frm = new FrmAgendaConsultar(_profesional))
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
    }
}
