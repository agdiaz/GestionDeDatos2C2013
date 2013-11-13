using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionCommon.Entidades;

namespace Clinica_Frba.Cancelaciones
{
    public partial class FrmCancelarProfesional : Form
    {
        private Profesional _profesional;

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
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
