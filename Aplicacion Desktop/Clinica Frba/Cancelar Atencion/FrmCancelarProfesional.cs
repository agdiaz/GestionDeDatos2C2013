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

namespace Clinica_Frba.Cancelaciones
{
    public partial class FrmCancelarProfesional : Form
    {
        private Profesional _profesional;
        private TipoCancelacionDomain _tipoCancDomain;
        public FrmCancelarProfesional(Profesional prof)
            : this()
        {
            this.CargarProfesional(prof);
        }

        private void CargarProfesional(Profesional prof)
        {
            this._profesional = prof;
        }
        public FrmCancelarProfesional()
        {
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
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }
    }
}
