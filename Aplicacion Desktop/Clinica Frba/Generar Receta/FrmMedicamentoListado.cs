using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;
using GestionCommon.Entidades;
using GestionGUIHelper.Helpers;
using GestionDomain.Resultados;
using GestionDomain;

namespace Clinica_Frba.Generar_Receta
{
    public partial class FrmMedicamentoListado : FormularioBaseListado
    {
        private MedicamentoDomain _domain;
        public FrmMedicamentoListado()
            :base(true)
        {
            InitializeComponent();
            _domain = new MedicamentoDomain(Program.ContextoActual.Logger);
            this.btnAlta.Visible = false;
            this.btnBaja.Visible = false;
            this.btnModificacion.Visible = false;

        }

        protected override void AccionAlta()
        {
            ;
        }
        protected override void AccionBorrar()
        {
            ;
        }
        protected override void AccionModificar()
        {
            ;
        }

        protected override void AccionLimpiar()
        {
            this.tbNombre.Text = string.Empty;
        }

        protected override void AccionFiltrar()
        {
            try
            {
                Medicamento m = new Medicamento();
                m.Nombre = tbNombre.Text;

                IResultado<IList<Medicamento>> resultado = _domain.Filtrar(m);

                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<IList<Medicamento>>(resultado);

                this.dgvBusqueda.DataSource = resultado.Retorno;
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);

            }
        }
    }
}
