using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionCommon.Entidades;
using GestionCommon.Helpers;

namespace Clinica_Frba.Compra_de_Bono
{
    public partial class FrmImpresion : Form
    {
        private Compra _compra;
        private Afiliado _afiliado;

        public FrmImpresion(Compra compra, Afiliado afiliado)
        {
            _compra = compra;
            _afiliado = afiliado;

            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmImpresion_Load(object sender, EventArgs e)
        {
            tbNombreCompleto.Text = _afiliado.NombreCompleto;
            tbNroAfiliado.Text = _afiliado.NroAfiliado.ToString();

            foreach (BonoConsulta bono in _compra.BonosConsulta)
            {
                string desc = string.Format("Bono Nº: {0} - Plan {1}", bono.IdBonoConsulta.ToString(), bono.NombrePlanMedico);
                lstBonosConsulta.Items.Add(desc);
            }

            foreach (BonoFarmacia bono in _compra.BonosFarmacia)
            {
                string desc = string.Format("Bono Nº: {0} - Plan {1}. Venc: {2}", bono.IdBonoFarmacia.ToString(), bono.NombrePlanMedico, FechaHelper.Format(bono.FechaVencimiento, FechaHelper.DateFormat));
                lstBonosFarmacia.Items.Add(desc);
            }

        }
    }
}
