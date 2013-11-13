using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionCommon.Entidades;
using Clinica_Frba.Afiliados;
using GestionDomain;
using GestionGUIHelper.Helpers;
using GestionDomain.Resultados;

namespace Clinica_Frba.Cancelaciones
{
    public partial class FrmCancelarAfiliado : Form
    {
        private Afiliado _afiliado;
        private TipoCancelacionDomain _tipoCancDomain;

        public FrmCancelarAfiliado(Afiliado af)
            :this()
        {
            this.CargarAfiliado(af);
        }

        private void CargarAfiliado(Afiliado af)
        {
            this._afiliado = af;
            this.btnBuscarAfiliado.Enabled = false;
            this.tbAfiliado.Text = _afiliado.NombreCompleto;
        }

        public FrmCancelarAfiliado()
        {
            _tipoCancDomain = new TipoCancelacionDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FrmAfiliadoListado frm = new FrmAfiliadoListado(true))
            {
                frm.ShowDialog(this);
                if (frm.EntidadSeleccionada as Afiliado != null)
                {
                    this.CargarAfiliado((Afiliado)frm.EntidadSeleccionada);
                }
            }
        }

        private void FrmCancelarAfiliado_Load(object sender, EventArgs e)
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
