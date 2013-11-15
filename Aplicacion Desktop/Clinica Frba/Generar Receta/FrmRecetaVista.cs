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

namespace Clinica_Frba.Generar_Receta
{
    public partial class FrmRecetaVista : Form
    {
        private Receta _receta;
        private string _afiliadoNombre;
        private string _profesionalNombre;

        public FrmRecetaVista(Receta r, string nAfiliado, string nProf)
        {
            _receta = r;
            _afiliadoNombre = nAfiliado;
            _profesionalNombre = nProf;

            InitializeComponent();
        }

        private void FrmRecetaVista_Load(object sender, EventArgs e)
        {
            this.lblFecha.Text = FechaHelper.Format(_receta.Fecha, FechaHelper.DateFormat);
            this.lblNombreAfiliado.Text = _afiliadoNombre;
            this.lblProfesional.Text = _profesionalNombre;
            StringBuilder sb = new StringBuilder();
            foreach (ItemReceta item in _receta.Items)
            {
                sb.Append(item.ToString()).Append(Environment.NewLine); 
            }
            this.lblItems.Text = sb.ToString();
        }



    }
}
