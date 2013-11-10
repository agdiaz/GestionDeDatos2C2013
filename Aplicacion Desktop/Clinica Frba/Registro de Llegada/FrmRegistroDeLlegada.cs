using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionDomain;
using GestionCommon.Entidades;
using GestionDomain.Resultados;
using GestionGUIHelper.Formularios;
using GestionGUIHelper.Helpers;
using GestionCommon.Helpers;

namespace Clinica_Frba.RegistrosDeLLegada
{
    public partial class FrmRegistroDeLlegada : FormularioBase
    {
        private Turno _turno;

        private CompraDomain _domain;

        public FrmRegistroDeLlegada()
            :base()
        {
            _domain = new CompraDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool validarNroBono = this.ValidarNroBono();
            if (validarNroBono)
            {
                this.Registrar();
            }
        }

        private bool ValidarNroBono()
        {
            try
            {
                IResultado<BonoConsulta> resultado = _domain.ObtenerBonoConsulta(Convert.ToDecimal(this.tbBonoConsulta.Text));
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<BonoConsulta>(resultado);

                return true;
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
                return false;
            }
        }

        private void Registrar()
        {
            try
            {
                decimal idBono = Convert.ToDecimal(this.tbBonoConsulta.Text);
                IResultado<bool> resultado = _domain.RegistrarLlegada(idBono, _turno.IdTurno, FechaHelper.Ahora());
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<bool>(resultado);

            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
            
        }

        private void btnBuscarTurno_Click(object sender, EventArgs e)
        {

        }
    }
}
