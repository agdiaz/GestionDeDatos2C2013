﻿using System;
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

namespace Clinica_Frba.ResultadosAtencion
{
    public partial class FrmRegistroDeResultado : Form
    {
        private TurnoDomain _domain;
        private Turno _turno;
        private DateTime _fecha;

        public FrmRegistroDeResultado()
        {
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
                    using (FrmRecetaAlta frm = new FrmRecetaAlta())
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
    }
}
