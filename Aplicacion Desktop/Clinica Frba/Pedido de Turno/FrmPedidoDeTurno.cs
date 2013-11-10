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
using GestionCommon.Enums;
using Clinica_Frba.Profesionales;
using GestionCommon.Helpers;

namespace Clinica_Frba.PedidosDeTurno
{
    public partial class FrmPedidoDeTurno : Form
    {
        private Afiliado _afiliado;
        private Profesional _profesional;
        private DateTime _fechaSeleccionado;
        
        public FrmPedidoDeTurno()
        {
            _fechaSeleccionado = FechaHelper.Ahora();
            InitializeComponent();
        }
        
        #region [Buscar afiliado]
        private void btnBuscarAfiliado_Click(object sender, EventArgs e)
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

        private void CargarAfiliado(Afiliado afiliado)
        {
            this._afiliado = afiliado;
            this.tbAfiliado.Text = afiliado.NombreCompleto;
        }
        #endregion 
        
        #region [Buscar profesional]
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
            this._profesional = profesional;
            this.tbProfesional.Text = profesional.NombreCompleto;
        }
        #endregion

        #region [Load]
        private void FrmPedidoDeTurno_Load(object sender, EventArgs e)
        {
            this.CargarDias();
            this.dtpDesde.Value = FechaHelper.Ahora();
            this.dtpHasta.Value = this.dtpDesde.Value.AddMonths(1);
        }

        private void CargarDias()
        {
            IList<DiaSemana> dias = new ListaDiaSemana().Todos;
            cbDias.DataSource = dias;
            cbDias.DisplayMember = "Nombre";
            cbDias.ValueMember = "Id";
        }

        #endregion
        #region [Filtrar]
        private void btnFiltrar_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Turno t = new Turno();
            t.IdAfiliado = _afiliado.IdAfiliado;
            t.IdProfesional = _profesional.IdProfesional;
            t.Fecha = _fechaSeleccionado;

            
        }

    }
}
